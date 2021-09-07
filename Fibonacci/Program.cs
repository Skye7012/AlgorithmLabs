using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace GenerateUniqueArray
{
	static class Program
	{
		private const int length = 10000000; //10 000 000
		private const int tries = 100;
		private static Random rnd = new Random();
		private static void Main(string[] args)
		{
			var was = DateTime.Now;

			List<BigInteger> integers = new List<BigInteger>() { 0, 1 };
			
			for(int i = 2; i < 1000; i++)
			{
				integers.Add(integers[i - 2] + integers[i - 1]);
				Console.WriteLine(integers[i]+ "\n");
			}

			Console.WriteLine("\n1000th = " + integers.Last());

			Console.WriteLine(DateTime.Now - was);
		}
		private static int[] GenerateUniqueArray()
		{
			HashSet<int> res = new HashSet<int>(length);
			int count = 0;

			for (int i = 0; i < length; i++)
			{
				res.Add(rnd.Next());
				count++;
				while (res.Count != count)
				{
					res.Add(rnd.Next());
				}
			}

			Console.WriteLine("Generate Done");
			Console.WriteLine("Array Length = " + count);

			return res.ToArray();
		}
		private static int GetShiftsOnMax()
		{
			int max = 0;
			int countMaxChanges = 0;
			var array = GenerateUniqueArray();

			foreach (var arr in array)
			{
				if (arr > max)
				{
					max = arr;
					countMaxChanges++;
				}
			}

			return countMaxChanges;
		}

	}
}
