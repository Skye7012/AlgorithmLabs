using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using MyLib.EulerCycleLib;

namespace PerfectTrapezoidLab
{
	public class PerfectTrapezoid
	{
		const string _path = "..\\..\\..\\Task\\";

		HashSet<(int, int, int)> _trapezoids = new HashSet<(int, int, int)>();

		int _amount;

		public PerfectTrapezoid(int num)
		{
			ReadFile(num);
		}

		public List<int> Solve()
		{
			var eulerCycle = new EulerCycle(_trapezoids);
			var res = eulerCycle.Solve(FindStartTrapezoid());

			return res.Select(x => x.rib).ToList();
		}

		int FindStartTrapezoid()
			=> _trapezoids.Min(x => Math.Abs(x.Item1));


		public void ReadFile(int num)
		{
			string path = _path + num;

			var rawText = File.ReadAllLines(path);

			_amount = Convert.ToInt32(rawText[0]);

			for (int i = 0; i < _amount; i++)
			{
				_trapezoids.Add(ConvertStringToTrapezoid(rawText[i + 1], i + 1));
			}
		}

		(int, int, int) ConvertStringToTrapezoid(string stringTuple, int num)
		{
			var elements = stringTuple.Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

			int leftAngle = elements[0];
			int rightAngle = elements[1] - elements[2];

			return (leftAngle, num, rightAngle);
		}
	}
}
