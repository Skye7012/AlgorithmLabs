using System;
using System.Collections.Generic;
using System.Linq;

namespace GenerateUniqueArray
{
	static class Program
	{
		private const int length = 10000000; //10 000 000
		private static Random rnd = new Random();
		private static int count = 0;
		private static void Main(string[] args)
		{
			int[] array = GenerateUniqueArray();
		}
		private static int[] GenerateUniqueArray()
		{
			HashSet<int> res = new HashSet<int>(length);

			for (int i = 0; i < length; i++)
			{
				res.Add(rnd.Next());
				count++;
				while(res.Count != count)
				{
					res.Add(rnd.Next());
					Console.WriteLine("aaa" + count + "\n" + i);
				}
			}

			Console.WriteLine("Generate Done \n\n\n " + count);

			return res.ToArray();
		}
	}
}
