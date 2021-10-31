using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
	//  ребро
	public class Rib
	{
		int _startTop;

		int _numberOfRib;
		
		int _endTop;

		public Rib(int startTop, int numberOfRib, int endTop)
		{
			_startTop = startTop;
			_numberOfRib = numberOfRib;
			_endTop = endTop;
		}
	}
}
