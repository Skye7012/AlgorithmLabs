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
				var gb = new GlassBalls(999999,999999);
				Console.WriteLine("tries: " + gb.GetTries());
				//gb.PrintMaxFloors();
			}
		}
	}
}
