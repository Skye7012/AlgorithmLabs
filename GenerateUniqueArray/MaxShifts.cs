using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxShifts
{
	static class MaxShifts
	{
		private const int length = 10000000; //10 000 000
		public static void GetMaxShifts(int tries)
		{
			int[] maxShifts = new int[tries];

			for (int i = 0; i < tries; i++)
			{
				maxShifts[i] = GetMaxShifts();
				Console.WriteLine($"Shifts in {i + 1}th try = {maxShifts[i]}\n");
			}

			Console.WriteLine($"\n\nAverage Shifts = {maxShifts.Average()}");
		}
		public static int GetMaxShifts()
		{
			int max = 0;
			int countMaxChanges = 0;
			var array = ToGenerateUniqueArray();

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
		private static int[] ToGenerateUniqueArray()
		{
			Random rnd = new Random();
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
	}
}
