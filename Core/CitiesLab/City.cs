using MyLib.EulerCycleLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CitiesLab
{
	public class City
	{
		public List<(string name, int rib)> CitiesRib { get; set; } = new List<(string, int)>();

		void CitiesToLower(List<string> cities)
		{
			for (int i = 0; i < cities.Count; i++)
			{
				cities[i] = cities[i].ToLower();
			}
		}

		public List<string> Solve(List<string> cities)
		{
			var ribs = FormatCitiesToRib(cities);

			var solution = new EulerPath(ribs).Solve();

			return solution.Select(x => CitiesRib.First(y => y.rib == x.rib).name).ToList();
		}

		HashSet<(int, int, int)> FormatCitiesToRib(List<string> cities)
		{
			CitiesToLower(cities);
			int n = 0;
			Dictionary<char, int> lettersNum = new Dictionary<char, int>();
			HashSet<(int, int, int)> res = new HashSet<(int, int, int)>();

			foreach (var city in cities)
			{
				char firstLetter = city.First();
				char lastLetter = city.Last();

				if (!lettersNum.ContainsKey(lastLetter))
				{
					lettersNum.Add(lastLetter, ++n);
				}
				if(!lettersNum.ContainsKey(firstLetter))
				{
					lettersNum.Add(firstLetter, ++n);
				}
			}

			n = 0;

			foreach (var city in cities)
			{
				++n;
				CitiesRib.Add((city, n));

				char firstLetter = city.First();
				char lastLetter = city.Last();

				res.Add((lettersNum[firstLetter], n, lettersNum[lastLetter]));
			}

			return res;
		}
	}
}
