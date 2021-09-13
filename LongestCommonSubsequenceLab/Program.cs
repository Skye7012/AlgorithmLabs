using MyTimer;
using System;
using System.Linq;

namespace LongestCommonSubsequenceLab
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var timer = new Timer())
			{
				var lcs = new LongestCommonSubsequence("DCDA", "ABCD");
				lcs.PrintSizeMatrix();
				Console.WriteLine("\n\n" + lcs.GetLongestCommonSubsequence());
			}
		}
	}
}
