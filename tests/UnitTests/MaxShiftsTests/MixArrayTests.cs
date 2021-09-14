using MaxShiftsLab;
using Xunit;


namespace UnitTests.MaxShiftsTests
{
	public class MixArrayTests
	{
		[Theory]
		[InlineData(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
		[InlineData(new int[] { 0, 1 })]
		public void MixArray_InvokeMethod_ShouldReturnMixedArray(int[] array)
		{
			var arrayToMix = (int[])array.Clone();
			MaxShifts.MixArray(arrayToMix);

			for (int i = 0; i < array.Length; i++)
			{
				Assert.NotEqual(array[i], arrayToMix[i]);
			}
		}
	}
}
