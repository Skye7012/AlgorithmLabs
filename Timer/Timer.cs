using System;

namespace MyTimer
{
	public class Timer : IDisposable
	{
		public DateTime BeginTime { get; }
		public TimeSpan Past { get; set; }
		//public DateTime EndTime { get; set; }
		public Timer()
		{
			BeginTime = DateTime.Now;
		}
		public void Dispose()
		{
			Past = DateTime.Now - BeginTime;
			Console.WriteLine($"\n\nExecuting Time =  {Past}");
		}
	}
}
