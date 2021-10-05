using System;
using System.Collections.Generic;
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
		}

		void FillMaxFloors()
		{
			maxFloors = new int[tries, balls];
			FillFirstColAndRow();

			for (int i = 1; i < tries; i++)
			{
				for (int j = 1; j < balls; j++)
				{
					maxFloors[i, j] = maxFloors[i - 1, j - 1]
						+ maxFloors[i - 1, j] + 1;
				}
			}
		}

		void FillFirstColAndRow()
		{
			for (int i = 0; i < balls; i++)
			{
				maxFloors[0, i] = 1;
				maxFloors[i, 0] = i + 1;
			}
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
