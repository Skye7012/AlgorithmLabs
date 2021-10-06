using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlassBallsLab
{
	//сделать через Action delegate
	class GlassBalls
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

		public int GetTries()
		{
			_maxFloors = new List<int[]>();
			FillFirtRow();

			if (Floors <= 1)
				return 1;

			int res = -1;
			while (res < 0)
				res = AddNewRow();

			return res;
		}
		void FillFirtRow()
			=> _maxFloors.Add(Enumerable.Repeat(1, Balls).ToArray());

		int AddNewRow()
		{
			int[] res = new int[Balls];
			res[0] = ++_tries;
			int row = _tries - 1;

			for (int i = 1; i < Balls; i++)
			{
				res[i] = _maxFloors[row - 1][i - 1]
					+ _maxFloors[row - 1][i] + 1;

				if (res[i] >= Floors)
					return _tries;
			}

			_maxFloors.Add(res);

			return -1;
		}

		public void PrintMaxFloors()
		{
			for (int i = 0; i < _tries-1; i++)
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
