using MyTimer;
using System;
using System.Linq;

namespace MaxShifts
{
	public class Program
	{
		private static void Main(string[] args)
		{
			using (var timer = new Timer())
			{
				const int tries = 10;

				int[] maxShifts = new int[tries];

				for (int i = 0; i < tries; i++)
				{
					maxShifts[i] = MaxShifts.GetMaxShifts();
					Console.WriteLine($"Shifts in {i + 1}th try = {maxShifts[i]}\n");
				}

				Console.WriteLine($"\n\nAverage Shifts = {maxShifts.Average()}");
			}
		}
	}
}
