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
				var i = test.GetMinCostPath();
			}
		}
	}
}
