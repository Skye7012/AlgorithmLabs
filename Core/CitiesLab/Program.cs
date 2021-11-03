using MyLib.EulerCycleLib;
using System;
using System.Collections.Generic;

namespace CitiesLab
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<string> cities = new List<string>()
			{
				"Kazan",
				"New-York",
				"Novgorod",
			};
			var city = new City();
			var s = city.Solve(cities);
		}
			
	}
}
