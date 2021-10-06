using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BackpackTaskLab
{
	public class Backpack : IComparable<Backpack>
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

		public void Print()
		{
			Console.WriteLine($"max: {Max}");
			Console.WriteLine($"hasItems: {HasItems}");
			int i = 1;
			if (Items.Count > 0)
			{
				Console.WriteLine("Items:");
				foreach (var item in Items)
				{
					Console.WriteLine($"	Item №: {i++}");
					item.Print();
				}
			}
		}

		public int CompareTo([AllowNull] Backpack backpack)
		{
			if (this.Equals(backpack))
				return 0;
			else
			{
				if (backpack != null)
					return Max.CompareTo(backpack.Max);
				else
					return 1;
			}
		}

		public override bool Equals(object obj)
		{
			if ((obj == null) || !this.GetType().Equals(obj.GetType()))
			{
				return false;
			}
			else
			{
				Backpack b = (Backpack)obj;
				return (Max == b.Max) 
					&& (HasItems == b.HasItems)
					&& (Items == b.Items);
			}
		}
	}
}
