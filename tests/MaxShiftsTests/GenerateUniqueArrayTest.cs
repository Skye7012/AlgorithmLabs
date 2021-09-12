using MaxShiftsLab;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace MaxShiftsTests
{
	public class GenerateUniqueArrayTest
	{
		bool IsArrayUniqe(int[] array)
		{
			var values = new List<int>();

			foreach (var value in array)
			{
				if (!values.Contains(value))
					values.Add(value);
				else
					return false;
			}

			return true;
		}

		[Fact]
		public void GenerateUniqueArray_InvokeMethod_ShouldReturnUniqueArray()
		{
			var arrayLength = 10;
			var maxShifts = new MaxShifts(arrayLength: arrayLength);
			var values = new List<int>();

			var actual = maxShifts.GenerateUniqueArray(20);

			Assert.Equal(actual.Length, arrayLength);

			Assert.True(IsArrayUniqe(actual));
		}

		[Fact]
		public void GenerateUniqueArray_MakeArrayNonUnique_ShouldAssertFalse()
		{
			var arrayLength = 10;
			var maxShifts = new MaxShifts(arrayLength: arrayLength);
			var values = new List<int>();

			var actual = maxShifts.GenerateUniqueArray(20);

			//Make Array Non Unique
			actual[0] = actual.Last();

			Assert.Equal(actual.Length, arrayLength);

			Assert.False(IsArrayUniqe(actual));
		}
	}
}
