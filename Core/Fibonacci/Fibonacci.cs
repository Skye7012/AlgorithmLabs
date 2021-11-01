using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace FibonacciLab
{
	static class Fibonacci
	{
		public static void GetFibonacci1000thNumber()
		{

			List<BigInteger> integers = new List<BigInteger>() { 0, 1 };

			for (int i = 2; i < 1000; i++)
			{
				integers.Add(integers[i - 2] + integers[i - 1]);
				Console.WriteLine(integers[i] + "\n");
			}

			Console.WriteLine("\n1000th = " + integers.Last());
		}
	}
}
