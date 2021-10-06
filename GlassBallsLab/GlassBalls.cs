using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlassBallsLab
{
	public class GlassBalls
	{
		const int _width = 3;
		int _tries;
		List<int[]> _maxFloors;
		public int Balls { get; set; }
		public int Floors { get; set; }

		public GlassBalls(int balls, int floors)
		{
			Balls = balls;
			Floors = floors;
			_tries = 1;
		}
		public (int tries, int floor) GetSolution()
		{
			int neededBalls = (int)Math.Ceiling(Math.Log2(Floors)) + 1;

			if (Balls == 0)
				return (-1, -1);
			else if (Balls == 1)
				return (Floors, 1);
			else if (Balls >= neededBalls)
				return GetSolutionByBinarySearch();
			else
				return GetSolutionByOwnMethod();
		}

		public (int tries, int floor) GetSolutionByOwnMethod()
		{
			_maxFloors = new List<int[]>();
			FillFirtRow();

			if (Floors <= 1)
				return (1, 1);

			var res = (tries: -1, floor: -1);
			while (res.tries < 0)
				res = AddNewRow();

			return res;
		}

		public (int tries, int floor) GetSolutionByBinarySearch()
		{
			int tries = (int)Math.Ceiling(Math.Log2(Floors));
			int floor = (int)Math.Ceiling((double)Floors / 2);
			return (tries, floor);
		}

		void FillFirtRow()
			=> _maxFloors.Add(Enumerable.Repeat(1, Balls).ToArray());

		(int tries, int floor) AddNewRow()
		{
			int[] res = new int[Balls];
			res[0] = ++_tries;
			int row = _tries - 1;
			int y = 0;

			for (int i = 1; i < Balls; i++)
			{
				y = _maxFloors[row - 1][i - 1] + 1;
				res[i] = y + _maxFloors[row - 1][i];

				if (res[i] >= Floors)
					return (_tries, y);
			}

			_maxFloors.Add(res);

			return (-1, -1);
		}

		public void PrintMaxFloors()
		{
			for (int i = 0; i < _tries - 1; i++)
			{
				for (int j = 0; j < Balls; j++)
				{
					Console.Write(_maxFloors[i][j] + " ");
				}
				Console.WriteLine();
			}
		}
	}
}
