using MaxShiftsLab;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace MaxShiftsTests
{
	public class GenerateUniqueArrayTest
	{
		bool IsArrayUniqe()
		{

			return false;
		}
		[Fact]
		public void GenerateUniqueArray_InvokeMethod_ShouldReturnUniqueArray()
		{
			var arrayLength = 10;
			var maxShifts = new MaxShifts(arrayLength: arrayLength);
			var values = new List<int>();

			var actual = maxShifts.GenerateUniqueArray(20);

			Assert.Equal(actual.Length, arrayLength);

			foreach (var value in actual)
			{
				Assert.DoesNotContain<int>(value, values);
				if (!values.Contains(value))
					values.Add(value);
			}
		}

		[Fact]
		public void awea()
		{
			try
			{
				var arrayLength = 10;
				var maxShifts = new MaxShifts(arrayLength: arrayLength);
				var values = new List<int>();

				var actual = maxShifts.GenerateUniqueArray(20);


				var sameInteger = actual.Last();
				actual[0] = sameInteger;

				Assert.Equal(actual.Length, arrayLength);

				foreach (var value in actual)
				{
					Assert.DoesNotContain<int>(value, values);
					if (!values.Contains(value))
						values.Add(value);
				}
			}
			catch
			{
				Assert.Throws<>
			}
		}
	}
}
