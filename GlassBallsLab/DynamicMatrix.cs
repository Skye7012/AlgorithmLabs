using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlassBallsLab
{
	class DynamicMatrix
	{
		public List<int[]> Matrix { get; set; }
		int width;

		public DynamicMatrix()
		{
			Matrix = new List<int[]>();
		}
		public void AddRow(int[] numbers)
		{
			FillByWidth(numbers);
			Matrix.Add(numbers);
		}
		public void AddZeroRow()
		{
			AddRow(Enumerable.Repeat(1, width).ToArray());
		}
		void FillByWidth(int[] numbers)
		{
			if (numbers.Length < width)
			{
				var newNumbers = Enumerable.Repeat(0, width).ToArray();
				for (int i = 0; i < numbers.Length; i++)
				{
					newNumbers[i] = numbers[i];
				}
				numbers = newNumbers;
			}
		}
		public int[] this[int row]
		{
			get
			{
				return Matrix[row];
			}
			set
			{
				Matrix[row] = value;
			}
		}
		public int this[int row, int column]
		{
			get
			{
				return Matrix[row][column];
			}
			set
			{
				Matrix[row][column] = value;
			}
		}
	}
}
