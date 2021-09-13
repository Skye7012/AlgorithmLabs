using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace VaccineDevelopmentLab
{
	public class VaccineDevelopment
	{
		int _labs;
		int _stages;

		Table _plan;

		//[1,i] mean transfer from [0,i] to [1,i]
		Table _transfer;

		Table _path;

		public VaccineDevelopment(int labs = 2, int stages = 100)
		{
			_labs = labs;
			_stages = stages;
			_plan = new Table(_labs, _stages);
			_transfer = new Table(_labs, _stages);
			_path = new Table(_labs, _stages, " ");
		}
		public void PrintAll()
		{
			_plan.PrintTable("Plan");
			_transfer.PrintTable("Transfet");
			//_path.PrintTable("Path");
		}

		public int GetMinCostPath()
		{
			var newSum = new int[] { _plan[0, 0], _plan[1, 0] };
			var oldSum = new int[] { _plan[0, 0], _plan[1, 0] };

			for (int i = 1; i < _stages; i++)
			{
				for (int j = 0; j < _labs; j++)
				{
					var tempS1 = oldSum[j] + _plan[j, i];
					int jNext = (j + 1) % 2;
					var tempS2 = oldSum[jNext] + _transfer[j, i] + _plan[j, i];
					//newSum[j] = tempS1 < tempS2 ? tempS1 : tempS2;
					if (tempS1 <= tempS2)
					{
						newSum[j] = tempS1;
						_path[j, i] = j + 1;
					}
					else
					{
						newSum[j] = tempS2;
						_path[j, i] = jNext + 1;
					}
				}
				oldSum[0] = newSum[0];
				oldSum[1] = newSum[1];
			}
			var testdata1 = _plan[0];//newSum не может быть меньше любого из этих значений
			var testdata2 = _plan[1];//добавить в UnitTest

			//var res = newSum.Min();
			(int labNum, int res) res = newSum[0] < newSum[1] ? (1, newSum[0]) : (2, newSum[1]);

			Console.WriteLine($"\ntestdata1 = {testdata1}");
			Console.WriteLine($"testdata2 = {testdata2}");
			Console.WriteLine($"res = {res.res}");
			Console.WriteLine($"labNum = {res.labNum}");

			Console.WriteLine("\n");
			_path.PrintTable();

			return res.res;
		}

		public void Print()
		{

			Console.WriteLine("Plan\n");
			_plan.PrintTable();
			Console.WriteLine("Transfer\n");
			_transfer.PrintTable();
		}


	}
}
