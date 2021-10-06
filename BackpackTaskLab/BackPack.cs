using System;
using System.Collections.Generic;
using System.Text;

namespace BackpackTaskLab
{
	public class Backpack
	{
		public Backpack(int max, HashSet<Item> items, bool hasItems)
		{
			Max = max;
			Items = items;
			HasItems = hasItems;
		}
		public Backpack()
		{
			Max = 0;
			Items = new HashSet<Item>();
			HasItems = false;
		}
		public int Max { get; set; }
		public HashSet<Item> Items { get; set; }
		public bool HasItems { get; set; }
	}
}
