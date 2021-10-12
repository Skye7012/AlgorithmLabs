using MyTimer;
using System;

namespace GlassBallsLab
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var timer = new Timer())
			{
				var gb = new GlassBalls(3,12);
				//var res = gb.GetSolution();
				//Console.WriteLine("tries: " + res.tries);
				//Console.WriteLine("first floor to throw: " + res.floor);
				//gb.PrintMaxFloors();

				gb.AlgorithmDemonsration();
			}
		}
	}
}
