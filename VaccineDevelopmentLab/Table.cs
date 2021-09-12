﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VaccineDevelopmentLab
{
	public class Table
	{
		int rows;
		int columns;
		int[,] cells;

		public Table(int rows = 2, int columns = 100)
		{
			this.rows = rows;
			this.columns = columns;
			cells = GenerateTable(rows, columns);
		}

		public static int[,] GenerateTable(int rows, int columns)
		{
			Random rnd = new Random();
			int[,] res = new int[rows, columns];

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					res[i, j] = rnd.Next(1, 21);
				}
			}
			return res;
		}
		public void PrintTable(string varName = "plan")
		{
			StreamWriter sw = new StreamWriter($"{varName}.txt");
			for (int i = 0; i < cells.GetLength(0); i++)
			{
				for (int j = 0; j < cells.GetLength(1); j++)
				{
					var str = string.Format(("{0:D2} | "), cells[i, j]);
					sw.Write(str);
				}
				sw.WriteLine();
			}
			sw.Close();
		}
	}
}
