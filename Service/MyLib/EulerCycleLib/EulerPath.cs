﻿using MyLib.EulerCycleLib.Exceptions;
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

			var x = _adjacencyList.Keys;
			foreach (var startTop in _adjacencyList.Keys)
			{
				int stNum = _adjacencyList[startTop].Count;

				int endNum = 0;

				foreach (var item in _adjacencyList)
				{
					foreach (var rib in item.Value)
					{
						if (rib.endTop == startTop)
							endNum++;
					}
				}

				if (endNum != stNum)
					if (stNum == endNum + 1)
					{
						cycleStartTop = startTop;
						notValidTopsNum++;
					}
					else if (stNum + 1 == endNum)
					{
						cycleEndTop = startTop;
						notValidTopsNum++;
					}
			}

			if (notValidTopsNum == 2)
			{
				//var newRib = (cycleStartTop, _adjacencyList.Keys.Max()+1, cycleEndTop);
				_adjacencyList[cycleEndTop].Add((_adjacencyList.Keys.Max() + 1, cycleStartTop));
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

			if (!_adjacencyList.Any())
				throw new EmptyAdjacencyListException();

			int st = _startTop;
			int top = st;

			if (!_adjacencyList.ContainsKey(st))
				throw new NotFoundSuchStartTopException(st);

			while (_adjacencyList.Any())
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
						throw new NotValideGraphException();
					else
					{
						while (true)
						{
							if (_temp.Count == 1)
							{
								_answer.Push(_temp.Pop());

								if (_adjacencyList.Any())
									throw new NotRelatedGraphException();

								break;
							}

							_answer.Push(_temp.Pop());
							st = top = _temp.Peek().endTop;

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
				var res = _answer.ToList();
				res.Remove(res.Last());
				return res;
			}
		}


		//public List<(int rib, int endTop)> Solve(int? startTop = null)
		//{

		//	if (!_adjacencyList.Any())
		//		throw new EmptyAdjacencyListException();



		//	int st = startTop.HasValue ? startTop.Value : _adjacencyList.First().Key;
		//	int top = st;

		//	if (!_adjacencyList.ContainsKey(st))
		//		throw new NotFoundSuchStartTopException(st);

		//	while (_adjacencyList.Any())
		//	{
		//		var rib = _adjacencyList[top].First();
		//		_adjacencyList[top].Remove(rib);
		//		RemoveEmptyHashSet(top);
		//		_temp.Push(rib);
		//		top = rib.endTop;

		//		bool pathCritery = (top != st && !_adjacencyList.Any());
		//		// actionsAtDeadEnd
		//		if (!HaveWay(top))
		//		{
		//			if(pathCritery)
		//			{
		//				while (true)
		//				{
		//					if (_temp.Count == 1)
		//					{
		//						_answer.Push(_temp.Pop());

		//						if (_adjacencyList.Any())
		//							throw new NotRelatedGraphException();

		//						break;
		//					}

		//					_answer.Push(_temp.Pop());
		//					st = top = _temp.Peek().endTop;

		//					if (HaveWay(top))
		//						break;
		//				}
		//			}
		//			else if (top != st && !pathCritery)
		//			{
		//				//if(_adjacencyList.Any())
		//					throw new NotValideGraphException();
		//				//else
		//				//	return _answer.ToList();
		//			}
		//			else if(top == st || pathCritery)
		//			{
		//				while(true)
		//				{
		//					if(_temp.Count == 1)
		//					{
		//						_answer.Push(_temp.Pop());

		//						if (_adjacencyList.Any())
		//							throw new NotRelatedGraphException();

		//						break;
		//					}

		//					_answer.Push(_temp.Pop());
		//					st = top = _temp.Peek().endTop;

		//					if (HaveWay(top))
		//						break;
		//				}
		//			}
		//		}
		//	}
		//	if (_adjacencyList.Any())
		//		throw new Exception();
		//	else
		//	{
		//		var res = _answer.ToList();
		//		return res;
		//	}
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
