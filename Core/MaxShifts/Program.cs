using MyTimer;

namespace MaxShiftsLab
{
	public class Program
	{
		private static void Main(string[] args)
		{
			using (var timer = new Timer())
			{
				new MaxShifts().MakeExperiment();
			}
		}
	}
}
