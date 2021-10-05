using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlassBallsLab
{
	class DynamicMatrix
	{
		List<List<int>> matrix;
		public DynamicMatrix()
		{
			matrix = new List<List<int>>();
		}
		public void AddRow(int[] numbers)
		{
			matrix.Add(numbers.ToList());
		}
		public int this[int row, int column]
		{
			get
			{
				return matrix[row][column];
			}
			set
			{
				matrix[row][column] = value;
			}
		}
	}
}
