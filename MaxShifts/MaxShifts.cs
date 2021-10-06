using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxShiftsLab
{
	public class MaxShifts
	{
		private readonly int _length;
		private readonly int _tries;

		public MaxShifts(int arrayLength = 10000000, int tries = 10)
		{
			_length = arrayLength;
			_tries = tries;
		}

		public void MakeExperiment()
		{
			int[] maxShifts = new int[_tries];

			for (int i = 0; i < _tries; i++)
			{
				maxShifts[i] = GetMaxShifts();
				Console.WriteLine($"Shifts in {i + 1}th try = {maxShifts[i]}\n");
			}

			Console.WriteLine($"\n\nAverage Shifts = {maxShifts.Average()}");
		}

		private int GetMaxShifts()
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

		public int[] GenerateUniqueArray(int randomUpperBound = int.MaxValue)
		{
			Random rnd = new Random();
			HashSet<int> uniqueNumbers = new HashSet<int>(_length);
			int count = 0;

			for (int i = 0; i < _length; i++)
			{
				uniqueNumbers.Add(rnd.Next(randomUpperBound));
				count++;
				while (uniqueNumbers.Count != count)
				{
					uniqueNumbers.Add(rnd.Next(randomUpperBound));
				}
			}

			Console.WriteLine("Array generate Done");

			var res = uniqueNumbers.ToArray();
			MixArray(res);

			return res;
		}

		public static void MixArray(int[] array)
		{
			Random rnd = new Random();

			for (int i = array.Length - 1; i >= 1; i--)
			{
				int j = rnd.Next(i);
				var temp = array[j];
				array[j] = array[i];
				array[i] = temp;
			}

			Console.WriteLine("Mixing complete");
		}
	}
}
