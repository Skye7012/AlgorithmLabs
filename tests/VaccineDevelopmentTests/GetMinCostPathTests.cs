using System;
using VaccineDevelopmentLab;
using Xunit;
using System.Linq;

namespace VaccineDevelopmentTests
{
	public class GetMinCostPathTests
	{
		[Fact]
		public void SolveTask_SolutionShouldBeLargerOrEquealThanJustSummingRow()
		{
			var vaccineDevelopment = new VaccineDevelopment(2, 4);
			vaccineDevelopment.SolveTask();

			var summedRows = vaccineDevelopment.SumPlanMatrixRows().ToList();

			Assert.True(summedRows.TrueForAll(x => x >= vaccineDevelopment.Res.cost));
		}
	}
}
