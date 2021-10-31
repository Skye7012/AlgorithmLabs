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

			//var x = TopWithRibs.ToTopWithRibs(ribs);
			var x = EulerCycle.TupleToAdjacencyList(ribs);
		}
	}
}
