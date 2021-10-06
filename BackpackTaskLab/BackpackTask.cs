using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackpackTaskLab
{
	public class BackpackTask
	{
		int _maxWeight;
		List<Item> _items;
		Backpack[] _backpacks;
		public BackpackTask(int maxWeight, List<Item> items)
		{
			_items = items;
			_maxWeight = maxWeight;
			_backpacks = new Backpack[_maxWeight + 1];
			for (int i = 0; i < _backpacks.Length; i++)
			{
				_backpacks[i] = new Backpack();			
			}
		}
		public void GetSolution()
		{
			_backpacks[0].HasItems = true;

			for (int i = 0; i < _items.Count; i++)
			{
				for (int j = _maxWeight; j >= 0; j--)
				{
					int weight = _items[i].Weight;
					if (j - weight >= 0)
					{
						Backpack prevBackpack = _backpacks[j - weight];
						Backpack backpack = _backpacks[j];
						Item item = _items[i];
						if (prevBackpack.HasItems)
							if (backpack.Max < prevBackpack.Max + item.Value)
							{
								backpack.Max = prevBackpack.Max + item.Value;
								backpack.Items = new HashSet<Item>(prevBackpack.Items.ToArray());
								backpack.Items.Add(item);
								backpack.HasItems = true;
							}
					}
				}
			}

			PrintBackpacks();
		}
		public void PrintBackpacks()
		{
			for (int i = 0; i < _backpacks.Length; i++)
			{
				Backpack backpack = _backpacks[i];
				Console.WriteLine($"Backpack №{i}");
				backpack.Print();
				Console.WriteLine();
				Console.WriteLine();
			}
		}
	}
}
