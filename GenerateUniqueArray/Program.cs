using MyTimer;

namespace MaxShifts
{
	public class Program
	{
		private static void Main(string[] args)
		{
			using (var timer = new Timer())
			{
				const int tries = 10;
				MaxShifts.MakeExperiment(tries);
			}
		}
	}
}
