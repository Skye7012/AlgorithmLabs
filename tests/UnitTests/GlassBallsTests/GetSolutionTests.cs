using System;
using System.Collections.Generic;
using System.Text;
using GlassBallsLab;
using Xunit;

namespace UnitTests.GlassBallsTests
{
	public class GetSolutionTests
	{
		[Theory]
		[InlineData(0,999999, -1,-1 )]
		[InlineData(1,999999, 999999,1)]
		[InlineData(999999,999999, 20,500000)]
		[InlineData(4,999999, 71, 57226)]
		public void SendBallsAndFloors_ShouldReturnSolution(
			int balls,
			int floors,
			int expectedTries,
			int excpectedFloorToThrow)
		{
			var gb = new GlassBalls(balls, floors);

			var actualRes = gb.GetSolution();

			Assert.Equal(expectedTries, actualRes.tries);
			Assert.Equal(excpectedFloorToThrow, actualRes.floor);
		}
	}
}
