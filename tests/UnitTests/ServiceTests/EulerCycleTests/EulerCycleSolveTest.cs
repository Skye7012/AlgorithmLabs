using System.Collections.Generic;
using MyLib.EulerCycleLib;
using MyLib.EulerCycleLib.Exceptions;
using Xunit;


namespace UnitTests.ServiceTests.EulerCycleTests
{
	public class EulerCycleSolveTest
	{
		private readonly HashSet<(int, int, int)> _murzilkaGraph;
		private readonly HashSet<(int, int, int)> _anotherProperGraph;
		private readonly HashSet<(int, int, int)> _notRelatedGraph;
		private readonly HashSet<(int, int, int)> _notValideGraph;
		private readonly HashSet<(int, int, int)> _nullGraph;

		public EulerCycleSolveTest()
		{
			_murzilkaGraph = new HashSet<(int, int, int)>()
			{
				(0,0,1),(0,7,4),
				(1,1,2),(1,6,3),
				(2,2,3),
				(3,3,4),(3,5,0),
				(4,4,1),(4,8,0)
			};

			_anotherProperGraph = new HashSet<(int, int, int)>()
			{
				(0,0,1),
				(1,1,2),
				(2,2,0),(2,3,3),
				(3,4,4),
				(4,5,2),
			};

			_notRelatedGraph = new HashSet<(int, int, int)>()
			{
				(0,0,1),
				(1,1,2),
				(2,3,3),
				(3,3,0),
				(10,10,10)
			};

			_notValideGraph = new HashSet<(int, int, int)>()
			{
				(0,0,1),
			};

			_nullGraph = new HashSet<(int, int, int)>();
		}

		[Fact]
		public void Solve_ProperGraph_ShouldSolve()
		{
			List<(int rib, int endTop)> expected = new List<(int rib, int endTop)>()
			{   
				(0,1),
				(1,2),
				(2,3),
				(3,4),
				(4,1),
				(6,3),
				(5,0),
				(7,4),
				(8,0),
			};

			var eulerCycle = new EulerCycle(_murzilkaGraph);
			var actual = eulerCycle.Solve();

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Solve_ProperGraphFromCustomStartTop_ShouldSolve()
		{
			List<(int rib, int endTop)> expected = new List<(int rib, int endTop)>()
				{   
					(4,1),
					(1,2),
					(2,3),
					(3,4),
					(8,0),
					(0,1),
					(6,3),
					(5,0),
					(7,4),
				};

			var eulerCycle = new EulerCycle(_murzilkaGraph);
			var actual = eulerCycle.Solve(4);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Solve_NotRelatedGraph_ThrowsNotRelatedGraphException()
		{
			var eulerCycle = new EulerCycle(_notRelatedGraph);
			Assert.Throws<NotRelatedGraphException>(() => eulerCycle.Solve());
		}

		[Fact]
		public void Solve_NotValideGraph_ThrowsNotValideGraphException()
		{
			var eulerCycle = new EulerCycle(_notValideGraph);
			Assert.Throws<NotValideGraphException>(() => eulerCycle.Solve());
		}

		[Fact]
		public void Solve_NullGraph_ThrowsEmptyAdjacencyListException()
		{
			var eulerCycle = new EulerCycle(_nullGraph);
			Assert.Throws<EmptyAdjacencyListException>(() => eulerCycle.Solve());
		}

		[Fact]
		public void Solve_WrongStartPoin_NotFoundSuchStartTopException()
		{
			var eulerCycle = new EulerCycle(_anotherProperGraph);
			Assert.Throws<NotFoundSuchStartTopException>(() => eulerCycle.Solve(999));
		}
	}
}
