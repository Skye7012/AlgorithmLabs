using System;
using System.Linq;

namespace LongestCommonSubsequenceLab
{
	public class LongestCommonSubsequence
	{
		string s1;
		string s2;
		int m;
		int n;
		int[,] sizeMatrix;

		public LongestCommonSubsequence(
			string firstSequence,
			string secondSequence)
		{
			s1 = firstSequence;
			s2 = secondSequence;
			m = s1.Length;
			n = s2.Length;
			CalculateSizeMatrix();
		}

		public void CalculateSizeMatrix()
		{
			sizeMatrix = new int[m + 1, n + 1];
			for (int i = 1; i < m + 1; i++)
			{
				for (int j = 1; j < n + 1; j++)
				{
					if (s1[i - 1] == s2[j - 1])
						sizeMatrix[i, j] = sizeMatrix[i - 1, j - 1] + 1;
					else
					{
						var first = sizeMatrix[i - 1, j];
						var second = sizeMatrix[i, j - 1];
						sizeMatrix[i, j] = first > second ? first : second;
					}
				}
			}
		}

		public string GetLongestCommonSubsequence()
		{
			string s = "";

			for (int i = m, j = n; j != 0 || i != 0;)
			{
				if (j == 0 || i == 0)
					break;
				var first = sizeMatrix[i - 1, j];
				var second = sizeMatrix[i, j - 1];
				if (sizeMatrix[i, j] > first && sizeMatrix[i, j] > second)
				{
					s += s1[i - 1];
					i--;
					j--;
				}
				else if (first >= second)
					i--;
				else
					j--;
			}
			return new string(s.Reverse().ToArray());
		}

		public void PrintSizeMatrix()
		{
			var newMatrix = new char[sizeMatrix.GetLength(0) + 1, sizeMatrix.GetLength(1) + 1];

			newMatrix[0, 0] = newMatrix[1, 0] = newMatrix[0, 1] = '*';

			for (int i = 0; i < s1.Length; i++)
			{
				newMatrix[i + 2, 0] = s1[i];
			}

			for (int j = 0; j < s2.Length; j++)
			{
				newMatrix[0, j + 2] = s2[j];
			}

			for (int i = 1; i < newMatrix.GetLength(0); i++)
			{
				for (int j = 1; j < newMatrix.GetLength(1); j++)
				{
					string str = Convert.ToString(sizeMatrix[i - 1, j - 1]);
					newMatrix[i, j] = str[0];
				}
			}

			for (int i = 0; i < newMatrix.GetLength(0); i++)
			{
				for (int j = 0; j < newMatrix.GetLength(1); j++)
				{
					Console.Write(newMatrix[i, j] + " ");
				}
				Console.WriteLine();
			}
		}
	}
}
