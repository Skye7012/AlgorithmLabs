using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
	public class EulerCycle
	{
		// Ребра
		int _ribs;

		// Вершины
		int _tops;

		/// <summary>
		/// 1 — начальная вершина
		/// 2 — ребро
		/// 3 — конечная вершина
		/// </summary>
		Dictionary<int, Dictionary<int, int>> _adjacencyList;
		//Dictionary<int, (int rib, int top)> _adjacencyList;

		public EulerCycle(Dictionary<int, Dictionary<int, int>> adjacencyList)
		{
			_adjacencyList = adjacencyList;

		}
	}
}
