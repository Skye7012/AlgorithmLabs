﻿using MyTimer;
using System;

namespace LongestCommonSubsequenceLab
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var timer = new Timer())
			{
				var s1 = "DCDA";
				var s2 = "ABCD";
				var m = s1.Length;
				var n = s2.Length;
				int[,] matrix = new int[m + 1, n + 1];

				for (int i = 1; i < m + 1; i++)
				{
					for (int j = 1; j < n + 1; j++)
					{
						if (s1[i - 1] == s2[j - 1])
							matrix[i, j] = matrix[i - 1, j - 1] + 1;
						else
						{
							var first = matrix[i - 1, j];
							var second = matrix[i, j - 1];
							matrix[i, j] = first > second ? first : second;
						}
					}
				}

				Print(matrix);
			}
		}

		static void Print(int[,] martix)
		{
			for (int i = 0; i < martix.GetLength(0); i++)
			{
				for (int j = 0; j < martix.GetLength(1); j++)
				{
					Console.Write(martix[i, j]);
				}
				Console.WriteLine();
			}
		}
	}
}
