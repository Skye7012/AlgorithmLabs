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

			foreach (var item in s)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine("\n\n\n");

			List<string> cities2 = new List<string>()
			{
				"Izhevsk",
				"Novgorod",
				"New-York",
				"Kazan",
				"Dubai",
			};

			city = new City();
			s = city.Solve(cities2);

			foreach (var item in s)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine("\n\n\n");
		}
			
	}
}
