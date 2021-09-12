using MaxShiftsLab;
using System;
using System.Collections.Generic;
using Xunit;

namespace MaxShiftsTests
{
	public class GenerateUniqueArrayTest
	{
		[Fact]
		public void GenerateUniqueArray_Send1MilArrayLength_Return10MilLengthUniqueArray()
		{
			var maxShifts = new MaxShifts(arrayLength: 100000);
			var values = new List<int>();

			var actual = maxShifts.GenerateUniqueArray();

			foreach(var value in actual)
			{
				Assert.DoesNotContain<int>(value, values);
				if (!values.Contains(value))
					values.Add(value);
			}
		}

		[Fact]
		public void awea()
		{
			var values = new List<int>();
			int[] actual = { 1, 2, 3, 1 };

			foreach (var value in actual)
			{
				Assert.DoesNotContain<int>(value, values);
				if (!values.Contains(value))
					values.Add(value);
			}
		}
	}
}
