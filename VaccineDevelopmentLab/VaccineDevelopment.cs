using System;
using System.IO;
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

		public (int labNum, int cost) Res { get; protected set; }

		public int[,] PathMatrix { get { return _pathMatrix; } }

		public VaccineDevelopment(int labs = 2, int stages = 100)
		{
			_labs = labs;
			_stages = stages;
			_planMatrix = GenerateMatrix(1, 21);
			_transferMatrix = GenerateMatrix(1, 5);
			_pathMatrix = new int[_labs, _stages];
			Res = (0, 0);
		}

		public VaccineDevelopment() { }

		public void SolveTask()
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

			Res = newSum[0] < newSum[1] ? (1, newSum[0]) : (2, newSum[1]);
		}

		int[,] GenerateMatrix(int lowerBound, int upperBound)
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

		public int[] SumPlanMatrixRows()
		{
			int rows = _planMatrix.GetLength(0);
			int columns = _planMatrix.GetLength(1);

			int[] res = new int[rows];
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					res[i] += _planMatrix[i, j];
				}
			}

			return res;
		}

		#region Print Methods

		public void PrintSolution()
		{
			var summedRows = SumPlanMatrixRows();

			Console.WriteLine("Plan\n");
			Console.WriteLine(MatrixToString(_planMatrix));
			Console.WriteLine("Transfer\n");
			Console.WriteLine(MatrixToString(_transferMatrix));
			Console.WriteLine("Path\n");
			Console.WriteLine(MatrixToString(_pathMatrix));
			Console.WriteLine();
			Console.WriteLine($"only1lab = {summedRows[0]}");
			Console.WriteLine($"only2lab = {summedRows[1]}");
			Console.WriteLine($"res = {Res.cost}");
			Console.WriteLine($"labNum = {Res.labNum}");

		}

		public void WriteSolutionToTxt()
		{
			StreamWriter sw = new StreamWriter("Solution.txt");
			var summedRows = SumPlanMatrixRows();

			sw.WriteLine("Plan\n");
			sw.WriteLine(MatrixToString(_planMatrix));
			sw.WriteLine("Transfer\n");
			sw.WriteLine(MatrixToString(_transferMatrix));
			sw.WriteLine("Path\n");
			sw.WriteLine(MatrixToString(_pathMatrix));
			sw.WriteLine();
			sw.WriteLine($"only1lab = {summedRows[0]}");
			sw.WriteLine($"only2lab = {summedRows[1]}");
			sw.WriteLine($"res = {Res.cost}");
			sw.WriteLine($"labNum = {Res.labNum}");

			sw.Close();
		}

		string MatrixToString(int[,] matrix)
		{
			StringBuilder res = new StringBuilder();

			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					var str = string.Format(("{0:D2} | "), matrix[i, j]);
					res.Append(str);
				}
				res.Append("\n");
			}
			return res.ToString();
		}

		#endregion


		/// <summary>
		/// Создать сущность для тестов
		/// </summary>
		/// <returns>-</returns>
		[Obsolete("Только для тестов")]
		public static VaccineDevelopment CreateForTest(
			int[,] planMatrix,
			int[,] transferMatrix,
			int labs = 2,
			int stages = 4)
			=> new VaccineDevelopment()
			{
				_planMatrix = planMatrix,
				_transferMatrix = transferMatrix,
				_labs = labs,
				_stages = stages,
				_pathMatrix = new int[labs, stages],
				Res = (0, 0),
			};

	}
}

