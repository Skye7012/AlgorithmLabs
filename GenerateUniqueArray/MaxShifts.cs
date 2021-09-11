﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxShifts
{
	static class MaxShifts
	{
		private const int length = 10000000; //10 000 000

		public static void MakeExperiment(int tries)
		{
			int[] maxShifts = new int[tries];

			for (int i = 0; i < tries; i++)
			{
				maxShifts[i] = GetMaxShifts();
				Console.WriteLine($"Shifts in {i + 1}th try = {maxShifts[i]}\n");
			}

			Console.WriteLine($"\n\nAverage Shifts = {maxShifts.Average()}");
		}

		private static int GetMaxShifts()
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

		private static int[] GenerateUniqueArray()
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

			return MixArray(res.ToArray());
		}

		private static int[] MixArray(int[] array)
		{
			Random rnd = new Random();

			for (int i = array.Length - 1; i >= 1; i--)
			{
				int j = rnd.Next(i + 1);
				var temp = array[j];
				array[j] = array[i];
				array[i] = temp;
			}

			Console.WriteLine("Mixing complete");

			return array;
		}
	}
}
