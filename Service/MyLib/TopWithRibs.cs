using System;
using System.Collections.Generic;
using System.Linq;
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

		public static List<TopWithRibs> ToTopWithRibs(HashSet<(int top, int ribNumber, int end)> ribs)
		{
			List<TopWithRibs> res = new List<TopWithRibs>();

			foreach (var rib in ribs)
			{
				if (res.Any(x => x._top == rib.top))
				{
					var x = res.Single(x => x._top == rib.top).
						_endRibs.Add(new EndRib(rib.ribNumber, rib.end));
				}
				else
					res.Add(new TopWithRibs(rib));
			}

			return res;
		}

		public TopWithRibs(int top, HashSet<EndRib> endRibs)
		{
			_top = top;
			_endRibs = endRibs;
		}

		public TopWithRibs(int top, HashSet<(int,int)> endRibs)
		{
			_top = top;
			_endRibs = ToHashSetEndRib(endRibs);
		}

		public TopWithRibs(int top, int ribNumber, int end)
		{
			_top = top;
			_endRibs = new HashSet<EndRib>() { new EndRib(ribNumber, end) };
		}

		public TopWithRibs((int top, int ribNumber, int end) rib)
		{
			_top = rib.top;
			_endRibs = new HashSet<EndRib>() { new EndRib(rib.ribNumber, rib.end) };
		}

		public HashSet<EndRib> ToHashSetEndRib(HashSet<(int, int)> given)
		{
			HashSet<EndRib> res = new HashSet<EndRib>();

			foreach (var item in given)
			{
				res.Add(item);
			}

			return res;
		}
	}
}
