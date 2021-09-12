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
				Table table = new Table();
				table.PrintTable();
			}
		}
	}
}
