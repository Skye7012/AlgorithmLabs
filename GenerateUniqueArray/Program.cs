using MyTimer;

namespace MaxShifts
{
	public class Program
	{
		private static void Main(string[] args)
		{
			using (var timer = new Timer())
			{
				const int tries = 100;
				MaxShifts.MakeExperiment(tries);
			}
		}
	}
}
