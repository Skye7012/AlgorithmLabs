using MyTimer;
using System;
using System.Linq;

namespace LongestIncreasingSubsequenceLab
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var timer = new Timer())
			{
				var numbers = new int[] { 5, 10, 6, 12, 3, 24, 7, 8 };
				var lis = new LongestIncreasingSubsequence(numbers);
				Console.WriteLine("Max Length: " + lis.GetLongestIncreasingSubsequenceLength());
				Console.WriteLine("SubSequence: ");
				Array.ForEach(lis.GetLongestIncreasingSubsequence(), Console.WriteLine);
			}
		}
	}
}
