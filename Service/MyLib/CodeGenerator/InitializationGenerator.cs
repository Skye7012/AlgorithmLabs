using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib.CodeGenerator
{
	public static class InitializationGenerator
	{
		public static string InitializeTupleList(List<(int rib, int endTop)> list)
		{
			StringBuilder sb = new StringBuilder();


			sb.Append("List<(int rib, int endTop)> variable = new List<(int rib, int endTop)>()\n");
			sb.Append("{\n");

			foreach (var item in list)
			{
				int rib = item.rib;
				int end = item.endTop;

				sb.Append($"	({rib},{end}),\n");
			}

			sb.Append("};");

			return sb.ToString();
		}
		public static string InitializeTupleHashSet(HashSet<(int startTop, int rib, int endTop)> adjacencyList)
		{
			StringBuilder sb = new StringBuilder();


			sb.Append("HashSet<(int startTop, int rib, int endTop)> variable = new HashSet<(int startTop, int rib, int endTop)>()\n");
			sb.Append("{\n");

			foreach (var item in adjacencyList)
			{
				int st = item.startTop;
				int rib = item.rib;
				int end = item.endTop;

				sb.Append($"	({st},{rib},{end}),\n");
			}

			sb.Append("};");

			return sb.ToString();
		}
	}
}
