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
				//var s1 = "DCDA";
				//var s2 = "ABCD";
				var s1 = "DCDAE";
				var s2 = "ABCDAE";
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
				Console.WriteLine(matrix[m, n]);
				Print(matrix, s1, s2);


				//int i = m;
				//int j = n;
				var now = matrix[m, n];
				string s = "";

				for (int i = m, j = n; j != 0 || i != 0;)
				{
					if (j == 0 || i == 0)
						break;
					var first = matrix[i - 1, j];
					var second = matrix[i, j - 1];
					if (matrix[i, j] > first && matrix[i, j] > second)
					{
						s += s1[i - 1];//
						i--;
						j--;
					}
					else if (first >= second)
						i--;
					else
						j--;
				}
				s = new string(s.Reverse().ToArray());
				Console.WriteLine("\n\n" + s);

			}
		}

		static void Print(int[,] martix, string first, string second)
		{
			var newMatrix = new char[martix.GetLength(0) + 1, martix.GetLength(1) + 1];

			newMatrix[0, 0] = newMatrix[1, 0] = newMatrix[0, 1] = ' ';

			for (int i = 0; i < first.Length; i++)
			{
				newMatrix[i + 2, 0] = first[i];
			}

			for (int j = 0; j < second.Length; j++)
			{
				newMatrix[0, j + 2] = second[j];
			}

			for (int i = 1; i < newMatrix.GetLength(0); i++)
			{
				for (int j = 1; j < newMatrix.GetLength(1); j++)
				{
					string str = Convert.ToString(martix[i - 1, j - 1]);
					newMatrix[i, j] = str[0];
				}
			}


			for (int i = 0; i < newMatrix.GetLength(0); i++)
			{
				for (int j = 0; j < newMatrix.GetLength(1); j++)
				{
					//Console.Write(second[j]);
					Console.Write(newMatrix[i, j]);
				}
				Console.WriteLine();
			}
		}
	}
}
