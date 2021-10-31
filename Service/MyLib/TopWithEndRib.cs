using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
	// вершина с коллекцией ребер
	public class TopWithRibs
	{
		//номер вершины
		int _top;

		// коллекция конечных ребер
		HashSet<EndRib> _endRibs;

		public TopWithRibs(int top, HashSet<EndRib> endRibs)
		{
			_top = top;
			_endRibs = endRibs;
		}
	}
}
