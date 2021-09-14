using System.Linq;
using VaccineDevelopmentLab;
using Xunit;

namespace VaccineDevelopmentTests
{
	public class SolveTaskTests
	{
		[Fact]
		public void SolveTaskWithHandWritedMatrixs_ShouldProperltSolveTask()
		{
			int[,] planMatrix =
			{
				{ 10,13,11 ,5},//19+8=27 27+7=34
				{ 4 ,22,4 ,10},
			};

			int[,] transferMatrix =
			{
				{ 2,2,1,2},
				{ 3,6,4,4},
			};

			int[,] expectedPathMatrix =
			{
				{ 0,2,1,2},
				{ 0,2,1,2},
			};

			(int labNum, int cost) expectedRes = (1, 34);

			var vaccineDevelopment = VaccineDevelopment.CreateForTest(
				planMatrix,
				transferMatrix,
				2, 4);

			vaccineDevelopment.SolveTask();

			Assert.Equal(expectedRes, vaccineDevelopment.Res);
			Assert.Equal(expectedPathMatrix, vaccineDevelopment.PathMatrix);
		}

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
