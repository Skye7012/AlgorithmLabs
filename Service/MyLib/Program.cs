using System;
using System.Collections.Generic;

namespace MyLib
{
	class Program
	{
		static void Main(string[] args)
		{
			HashSet<(int, int)> endRibs = new HashSet<(int, int)>()
			{
				(0,1),(1,2)
			};

			//List<TopWithRibs> ribs = new List<TopWithRibs>()
			//{
			//	new TopWithRibs(0, new HashSet<EndRib>()
			//		new EndRib(0,1))
			//}
		}
	}
}
