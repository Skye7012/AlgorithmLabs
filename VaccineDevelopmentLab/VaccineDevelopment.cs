using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace VaccineDevelopmentLab
{
	public class VaccineDevelopment
	{
		int _labs;
		int _stages;

		int[,] _planMatrix;

		//[1,i] mean transfer from [0,i] to [1,i]
		int[,] _transferMatrix;

		int[,] _pathMatrix;

		public VaccineDevelopment(int labs = 2, int stages = 100)
		{
			_labs = labs;
			_stages = stages;
			_planMatrix = GenerateMatrix(1,21);
			_transferMatrix = GenerateMatrix(1, 5);
			_pathMatrix = new int[_labs, _stages];
		}

		public (int labNum, int min) GetMinCostPath()
		{
			var newSum = new int[] { _planMatrix[0, 0], _planMatrix[1, 0] };
			var oldSum = new int[] { _planMatrix[0, 0], _planMatrix[1, 0] };

			for (int i = 1; i < _stages; i++)
			{
				for (int j = 0; j < _labs; j++)
				{
					var tempS1 = oldSum[j] + _planMatrix[j, i];
					int jNext = (j + 1) % 2;
					var tempS2 = oldSum[jNext] + _transferMatrix[j, i] + _planMatrix[j, i];
					if (tempS1 <= tempS2)
					{
						newSum[j] = tempS1;
						_pathMatrix[j, i] = j + 1;
					}
					else
					{
						newSum[j] = tempS2;
						_pathMatrix[j, i] = jNext + 1;
					}
				}
				oldSum[0] = newSum[0];
				oldSum[1] = newSum[1];
			}
			//var testdata1 = _planMatrix[0];//newSum не может быть меньше любого из этих значений
			//var testdata2 = _planMatrix[1];//добавить в UnitTest
			var summedRows = SumRows(_planMatrix);

			//var res = newSum.Min();
			(int labNum, int min) res = newSum[0] < newSum[1] ? (1, newSum[0]) : (2, newSum[1]);

			Console.WriteLine($"only1lab = {summedRows[0]}");
			Console.WriteLine($"only2lab = {summedRows[1]}");
			Console.WriteLine($"res = {res.min}");
			Console.WriteLine($"labNum = {res.labNum}");
			Console.WriteLine();

			return res;
		}

		public void PrintMatrixs()
		{

			Console.WriteLine("Plan\n");
			Console.WriteLine(MatrixToString(_planMatrix)); 
			Console.WriteLine("Transfer\n");
			Console.WriteLine(MatrixToString(_transferMatrix));
			Console.WriteLine("Path\n");
			Console.WriteLine(MatrixToString(_pathMatrix));
		}

		public void WriteMatrixToTxt()
		{
			StreamWriter sw = new StreamWriter("Matrix.txt");

			sw.WriteLine("Plan\n");
			sw.WriteLine(MatrixToString(_planMatrix));
			sw.WriteLine("Transfer\n");
			sw.WriteLine(MatrixToString(_transferMatrix));
			sw.WriteLine("Path\n");
			sw.WriteLine(MatrixToString(_pathMatrix));

			sw.Close();
		}

		int[,] GenerateMatrix(/*int rows, int columns, */int lowerBound, int upperBound)
		{
			Random rnd = new Random();

			int[,] res = new int[_labs, _stages];

			for (int i = 0; i < _labs; i++)
			{
				for (int j = 0; j < _stages; j++)
				{
					res[i, j] = rnd.Next(lowerBound, upperBound);
				}
			}

			return res;
		}

		int[] SumRows(int[,] matrix)
		{
			int rows = matrix.GetLength(0);
			int columns = matrix.GetLength(1);

			int[] res = new int[rows];
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					res[i] += matrix[i, j];
				}
			}

			return res;
		}

		string MatrixToString(int[,] matrix)
		{
			StringBuilder res = new StringBuilder();

			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					var str = string.Format(("{0:D2} | "), matrix[i, j]);
					res.Append(str);//работает?
				}
				res.Append("\n");
			}

			return res.ToString();
		}

	}
}
