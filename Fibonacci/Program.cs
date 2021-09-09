using MyTimer;

namespace GenerateUniqueArray
{
	static class Program
	{
		private static void Main(string[] args)
		{
			using (var timer = new Timer())
			{
				Fibonacci.GetFibonacci1000thNumber();
			}
		}
	}
}
