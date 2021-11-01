using MyTimer;
using System;
using System.Linq;

namespace VaccineDevelopmentLab
{
	class Program
	{
		static void Main(string[] args)
		{
			using(var timer = new Timer())
			{
				var vaccineDevelopment = new VaccineDevelopment(2,4);
				vaccineDevelopment.SolveTask();
				vaccineDevelopment.PrintSolution();
				vaccineDevelopment.WriteSolutionToTxt();
			}
		}
	}
}
