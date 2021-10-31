using System;
using System.Collections.Generic;

namespace MyLib
{
	class Program
	{
		static void Main(string[] args)
		{
			HashSet<(int, int, int)> ribs = new HashSet<(int, int, int)>()
			{
				(0,0,1),(0,7,4),
				(1,1,2),(1,6,3),
				(2,2,3),
				(3,3,4),(3,5,0),
				(4,4,1),
			};

			HashSet<(int, int, int)> ribs2 = new HashSet<(int, int, int)>()
			{
				(0,0,1),
				(1,1,2),
				(2,2,0),(2,3,3),
				(3,4,4),
				(4,5,2),
			};

			//var x = TopWithRibs.ToTopWithRibs(ribs);
			var x = EulerCycle.TupleToAdjacencyList(ribs2);
			var e = new EulerCycle(x);
			e.Solve();
			e.CountRibs();
			var y = x.Count;
		}
	}
}
