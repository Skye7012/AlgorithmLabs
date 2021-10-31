using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
	// Конечное ребро
	public class EndRib
	{
		int _number;

		//вершина, куда идет ребро
		int _endTop;

		public EndRib(int number, int endTop)
		{
			_number = number;
			_endTop = endTop;
		}
	}
}
