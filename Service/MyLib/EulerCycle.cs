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
			_temp = new Stack<(int rib, int endTop)>();
			_answer = new Stack<(int rib, int endTop)>();
		}

		#region logic

		public List<(int rib, int endTop)> Solve ()
		{
			if (!_adjacencyList.Any())
				return null;

			int st = _adjacencyList.First().Key;
			int top = st;

			while(_adjacencyList.Any())
			{
				var rib = _adjacencyList[top].First();
				_adjacencyList[top].Remove(rib);
				RemoveEmptyHashSet(top);
				_temp.Push(rib);
				top = rib.endTop;


				// actionsAtDeadEnd
				if (!HaveWay(top))
				{
					if (top != st)
						throw new Exception();
					else
					{
						while(true)
						{
							if(_temp.Count == 1)
							{
								_answer.Push(_temp.Pop());
								break;
							}
							var toPop = _temp.Pop();
							_answer.Push(toPop);
							toPop = _temp.Peek();
							st = top = toPop.endTop;

							if (HaveWay(top))
								break;
						}
					}
				}
			}
			if (_adjacencyList.Any())
				throw new Exception();
			else
			{
				var res = _answer/*.Reverse()*/.ToList();
				return res;
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

		//bool TryGetNextTop(int endTop)
		//{
		//	if (!HaveWay(endTop))
		//		return false;
		//	else
		//		ret
		//}

		void RemoveEmptyHashSet(int key)
		{
			if (!_adjacencyList[key].Any())
				_adjacencyList.Remove(key);
		}

		bool HaveWay(int endTop)
		{
			return _adjacencyList.ContainsKey(endTop);
		}

		//bool isDeadEnd(int endTop)
		//{
		//	return !HaveWay();
		//}


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
