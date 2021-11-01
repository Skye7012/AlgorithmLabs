using LongestCommonSubsequenceLab;
using LongestIncreasingSubsequenceLab;
using Xunit;

namespace UnitTests.CoreTests.LongestIncreasingSubsequenceTests
{
	public class GetLongestIncreasingSubsequenceTests
	{
		[Fact]
		public void SendSequence_ShouldReturnLongestIncreasingSubsequence()
		{
			var numbers = new int[] { 5, 10, 6, 12, 3, 24, 7, 8 };
			var lis = new LongestIncreasingSubsequence(numbers);

			var expectedSubseq = new int[] { 24, 12, 6, 5 };

			var actualSubseq = lis.GetLongestIncreasingSubsequence();

			Assert.Equal(expectedSubseq, actualSubseq);
		}
	}
}
