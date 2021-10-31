using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLib
{
	public class EulerCycle
	{

		/// <summary>
		/// 1 — начальная вершина
		/// 2 — ребро
		/// 3 — конечная вершина
		/// </summary>
		Dictionary<int, HashSet<(int rib, int endTop)>> _adjacencyList;

		int _countRibs;

		Stack<(int rib, int endTop)> _temp;

		Stack<(int rib, int endTop)> _answer;

		public EulerCycle(Dictionary<int, HashSet<(int rib, int endTop)>> adjacencyList)
		{
			_adjacencyList = adjacencyList;
			_countRibs = CountRibs();
		}

		#region logic

		public List<(int rib, int endTop)> Solve ()
		{
			if (!_adjacencyList.Any())
				return null;

			int st = _adjacencyList.First().Key;
			//var x = _adjacencyList.Keys;

			while(true)
			{
				int key = st;
				if (!_adjacencyList[key].Any())
				{
					_adjacencyList.Remove(key);
					key = _adjacencyList.First().Key;
				}
				var rib = _adjacencyList[st].First();
				_adjacencyList[st].Remove(rib);
				_temp.Push(rib);


				// actionsAtDeadEnd
				if (isDeadEnd(rib.endTop))
				{
					if (rib.endTop != st)
						throw new Exception();
					else
					{
						while(true)
						{
							_answer.Push(_temp.Pop());
							if (haveWay(_temp.Pop().endTop))
								break;
						}
					}
				}


			}
		
		}

		//void actionAtDeadEnd()
		//{
		//	if (rib.endTop != st)
		//		throw new Exception();
		//	else
		//	{
		//		while (true)
		//		{
		//			_answer.Push(_temp.Pop());
		//			if (haveWay(_temp.Pop().endTop))
		//				break;
		//		}
		//	}
		//}

		void RemoveEmptyHashSet()
		{

		}

		bool haveWay(int endTop)
		{
			return _adjacencyList.ContainsKey(endTop);
		}

		bool isDeadEnd(int endTop)
		{
			return !_adjacencyList.Any(x => x.Key == endTop);
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
