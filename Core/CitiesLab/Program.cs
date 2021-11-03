using MyLib.EulerCycleLib;
using System;
using System.Collections.Generic;

namespace CitiesLab
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var _cycle = new HashSet<(int, int, int)>()
			{
				(1,1,3),
				(2,2,1),
				(3,3,2),
			};

			var _path = new HashSet<(int, int, int)>()
			{
				(1,1,3),(1,4,3),
				(2,2,1),
				(3,3,2),
			};

			var _complexPath = new HashSet<(int, int, int)>()
			{
				(4,4,2),
				(1,1,2),
				(2,2,3),
				(3,3,4),
			};

			var _complexPathNotValid = new HashSet<(int, int, int)>()
			{
				(4,4,2),(4,5,10),
				(1,1,2),
				(2,2,3),
				(3,3,4),
			};

			var b = new EulerPath(_path).isPathValid();
			var b1 = new EulerPath(_cycle).isPathValid();
			var b2 = new EulerPath(_complexPath).isPathValid();
			var b3 = new EulerPath(_complexPathNotValid).isPathValid();

			var res = new EulerPath(_complexPath).Solve();
			var res2 = new EulerPath(_path).Solve();
		}
	}
}
