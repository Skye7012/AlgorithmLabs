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
				var test = new VaccineDevelopment(2,4);
				test.PrintAll();
				test.Print();
				var i = test.GetMinCostPath();
			}
		}
	}
}
