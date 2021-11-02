using MyTimer;
using System;
using System.IO;

namespace PerfectTrapezoidLab
{
	internal class Program
	{
		static void Main(string[] args)
		{
			using Timer timer = new Timer();

			for (int i = 1; i <= 9; i++)
			{
				try
				{
					var res = string.Join(", ", new PerfectTrapezoid(i).Solve());

					File.WriteAllText("..\\..\\..\\Solutions\\" + i + ".txt", res);

					Console.WriteLine($"{i}ая задача успешно решена");
				}
				catch (Exception ex)
				{
					string message = $"В {i}ой задаче возникла ошибка : '{ex.Message}'";
					Console.WriteLine(message);
					File.WriteAllText("..\\..\\..\\Solutions\\" + i + ".txt", message);
				}
			}
		}
	}
}
