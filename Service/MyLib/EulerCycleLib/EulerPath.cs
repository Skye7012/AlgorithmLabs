using MyLib.EulerCycleLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLib.EulerCycleLib
{
	public class EulerPath
	{

		/// <summary>
		/// 1 — начальная вершина
		/// 2 — ребро
		/// 3 — конечная вершина
		/// </summary>
		Dictionary<int, HashSet<(int rib, int endTop)>> _adjacencyList;

		HashSet<(int startTop, int rib, int endTop)> _ribs;

		int _countRibs;

		Stack<(int rib, int endTop)> _temp;

		Stack<(int rib, int endTop)> _answer;

		int _startTop;

		public EulerPath(Dictionary<int, HashSet<(int rib, int endTop)>> adjacencyList)
		{
			_adjacencyList = adjacencyList;
			_countRibs = CountRibs();
			_temp = new Stack<(int rib, int endTop)>();
			_answer = new Stack<(int rib, int endTop)>();
		}

		public EulerPath(HashSet<(int startTop, int rib, int endTop)> adjacencyList)
		{
			_adjacencyList = TupleToAdjacencyList(adjacencyList);
			_ribs = adjacencyList;
			_countRibs = CountRibs();
			_temp = new Stack<(int rib, int endTop)>();
			_answer = new Stack<(int rib, int endTop)>();
		}

		#region logic

		public bool isPathValid()
		{
			int cycleStartTop = 0;
			int cycleEndTop = 0;
			int notValidTopsNum = 0;

			List<int> tops = new List<int>();

			var we = _ribs.Select(x => x.startTop).Distinct().ToList();
			var ew = _ribs.Select(x => x.endTop).Distinct().ToList();

			tops = we.Union(ew).Distinct().ToList();

			var x = _adjacencyList.Keys;
			foreach (var top in tops)
			{
				int stNum = _ribs.Where(x => x.startTop == top).Count();
				int endNum = _ribs.Where(x => x.endTop == top).Count();


				if (endNum != stNum)
					if (stNum == endNum + 1)
					{
						cycleStartTop = top;
						notValidTopsNum++;
					}
					else if (stNum + 1 == endNum)
					{
						cycleEndTop = top;
						notValidTopsNum++;
					}
			}

			if (notValidTopsNum == 2)
			{
				if (_adjacencyList.ContainsKey(cycleEndTop))
				{
					_adjacencyList[cycleEndTop].Add((tops.Max() + 1, cycleStartTop));

				}
				else
				{
					var rib = (tops.Max() + 1, cycleStartTop);
					_adjacencyList.Add(cycleEndTop, new HashSet<(int rib, int endTop)> {rib });
				}
				_startTop = cycleStartTop;
				return true;
			}
			else
				return false;
		}

		public List<(int rib, int endTop)> Solve()
		{
			if (!isPathValid())
				throw new Exception();

			var solution = new EulerCycle(_adjacencyList).Solve(_startTop);

			var res = solution.ToList();
			res.Remove(res.Last());

			return res;
		}

		void RemoveEmptyHashSet(int key)
		{
			if (!_adjacencyList[key].Any())
				_adjacencyList.Remove(key);
		}

		bool HaveWay(int endTop)
		{
			return _adjacencyList.ContainsKey(endTop);
		}


		#endregion

		#region service

		public int CountRibs()
		{
			int count = 0;

			foreach (var item in _adjacencyList)
			{
				count += item.Value.Count;
			}

			return count;
		}

		public static Dictionary<int, HashSet<(int rib, int endTop)>> TupleToAdjacencyList(HashSet<(int top, int ribNumber, int end)> ribs)
		{
			Dictionary<int, HashSet<(int rib, int endTop)>> res = new Dictionary<int, HashSet<(int rib, int endTop)>>();

			foreach (var rib in ribs)
			{
				if (res.ContainsKey(rib.top))
				{
					res[rib.top].Add((rib.ribNumber, rib.end));
				}
				else
					res.Add(rib.top,
						new HashSet<(int rib, int endTop)>() { (rib.ribNumber, rib.end) });
			}

			return res;
		}

		#endregion
	}
}
