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

		void MakeExperiment()
        {
			Random rnd = new Random();
			var gb = new GlassBalls(3, 12);
			var res = gb.GetSolution();
			int soghtFloor = rnd.Next(0, gb.Floors + 2);
			int ballsLeft = gb.Balls;
			int triesLeft = res.tries;
			bool isCrashed = false;
			int choosedFloor = 0;

			Console.WriteLine("tries: " + res.tries);
			Console.WriteLine("first floor to throw: " + res.floor);
			Console.WriteLine("sought floor " + soghtFloor);
			Console.WriteLine("Begin algorithm? Press Enter");
			Console.ReadLine();

			int i = 0;
			var newGb = new GlassBalls();
			while (res.floor != soghtFloor)
			{
				Console.WriteLine("Thrown ball from " + res.floor + " floor");

				if (res.floor > soghtFloor)
				{
					isCrashed = true;
					ballsLeft--;
					triesLeft--;
					i++;
					choosedFloor = gb.Floors - res.floor;
					Console.WriteLine("The ball crashed");
				}
				else
				{
					isCrashed = false;
					choosedFloor = res.floor;
					Console.WriteLine("The ball didn't crash");
				}

				Console.WriteLine($"Tries left = {triesLeft + i} - {i} = {triesLeft}");
				Console.WriteLine($"Balls left = {ballsLeft + i} - {i} = {ballsLeft}");

				//int choosedFloor = isCrashed
				//	? Floors - res.floor
				//	: res.floor;

				newGb = new GlassBalls(ballsLeft, choosedFloor);
				res = newGb.GetSolution();
			}
		}
	}
}
