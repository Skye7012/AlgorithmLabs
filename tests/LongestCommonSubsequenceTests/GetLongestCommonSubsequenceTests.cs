using LongestCommonSubsequenceLab;
using System;
using Xunit;

namespace LongestCommonSubsequenceTests
{
	public class GetLongestCommonSubsequenceTests
	{
		[Theory]
		[InlineData("DCDA", "ABCD", "CD")]
		[InlineData("DCDAE", "ABCDAE", "CDAE")]
		[InlineData("ABAB", "BABA", "ABA")]
		[InlineData("ABCD", "ABCE", "ABC")]
		public void SendTwoSequences_ShouldReturnLongestCommonSubsequence(
			string firstSeq,
			string secondSeq,
			string expectedSubseq)
		{
			var lcs = new LongestCommonSubsequence(firstSeq, secondSeq);

			var actualSubseq = lcs.GetLongestCommonSubsequence();

			Assert.Equal(expectedSubseq, actualSubseq);
		}
	}
}
