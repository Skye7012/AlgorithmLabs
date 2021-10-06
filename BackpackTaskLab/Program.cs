using MyTimer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackpackTaskLab
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var timer = new Timer())
			{
				var items = new List<Item>
				{
					{new Item("Phone", 2, 8) },
					{new Item("Laptop", 10, 10) },
					{new Item("Charger", 1, 5) },
					{new Item("Water", 5, 4) },
					{new Item("Pen", 3, 7) },
				};

				BackpackTask bt = new BackpackTask(10, items);
				var res = bt.GetSolution();
				bt.PrintBackpacks();
				Console.WriteLine();
				Console.WriteLine();
				Console.WriteLine("Solution: ");
				Console.WriteLine($"Backpack №{res.Items.Sum(x => x.Weight)}");
				res.Print();
			}
		}
	}
}
