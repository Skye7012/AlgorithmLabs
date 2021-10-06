using System;
using System.Collections.Generic;
using System.Text;
using BackpackTaskLab;
using Xunit;

namespace UnitTests.BackpackTaskTests
{
	public class GetSolutionTests
	{
		private readonly List<Item> _items;
		private readonly HashSet<Item> _expectedItems;

		public GetSolutionTests()
		{
			_items = new List<Item>
				{
					{new Item("Phone", 2, 8) },
					{new Item("Laptop", 10, 10) },
					{new Item("Charger", 1, 5) },
					{new Item("Water", 5, 4) },
					{new Item("Pen", 3, 7) },
				};
			_expectedItems = new HashSet<Item>()
			{
				_items[0], _items[2], _items[4]
			};
		}
		[Fact]
		public void SendItems_ShouldReturnSolution()
		{
			BackpackTask bt = new BackpackTask(10, _items);

			var expectedBackpack = new Backpack(20, _expectedItems, true);

			var actualBackpack = bt.GetSolution();

			Assert.Equal(expectedBackpack.Max, actualBackpack.Max);
			Assert.Equal(expectedBackpack.HasItems, actualBackpack.HasItems);
			Assert.Equal(expectedBackpack.Items, actualBackpack.Items);
		}
	}
}
