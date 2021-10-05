using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlassBallsLab
{
	//сделать через Action delegate
	class GlassBalls
	{
		int tries;
		int balls;
		int floors;
		//int[,] maxFloors;
		DynamicMatrix maxFloors;

		public GlassBalls(int balls, int floors)
		{
			this.balls = balls;
			this.floors = floors;
			tries = 1;
		}

		bool FillMaxFloors()
		{
			//maxFloors = new int[tries, balls];
			maxFloors = new DynamicMatrix();
			FillFirtRow();
			return maxFloors[0].Any(x => x >= floors);

			for (int i = 1; i < tries; i++)
			{
				for (int j = 1; j < balls; j++)
				{
					maxFloors[i, j] = maxFloors[i - 1, j - 1]
						+ maxFloors[i - 1, j] + 1;
				}
			}
		}

		void FillFirtRow()
			=> maxFloors.AddRow(Enumerable.Repeat(1, balls).ToArray());

		int InitializeNewRow()
		{
			maxFloors.AddZeroRow();
			return ++tries;
		}

		void PrintMaxFloors()
		{
			for (int i = 0; i < tries; i++)
			{
				for (int j = 0; j < balls; j++)
				{
					Console.Write(maxFloors[i,j] + " ");
				}
				Console.WriteLine();
			}
		}
	}
}
