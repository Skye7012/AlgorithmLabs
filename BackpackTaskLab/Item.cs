using System;
using System.Collections.Generic;
using System.Text;

namespace BackpackTaskLab
{
	public class Item
	{
		public Item(string name, int weight, int value)
		{
			Name = name;
			Weight = weight;
			Value = value;
		}

		public string Name { get; set; }
		public int Weight { get; set; }
		public int Value { get; set; }
	}
}
