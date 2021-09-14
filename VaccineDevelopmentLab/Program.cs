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
				var vaccineDevelopmenv = new VaccineDevelopment(2,4);
				var i = vaccineDevelopmenv.GetMinCostPath();
				vaccineDevelopmenv.PrintMatrixs();
				vaccineDevelopmenv.WriteMatrixToTxt();
			}
		}
	}
}
