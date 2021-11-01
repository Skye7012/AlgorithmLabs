using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestIncreasingSubsequenceLab
{
	public class LongestIncreasingSubsequence
	{
		int[] _numbers;
		int[] _maxSequenceLength;

		public LongestIncreasingSubsequence(int[] numbers)
		{
			_numbers = numbers;
			_maxSequenceLength = Enumerable.Repeat(1, _numbers.Length).ToArray();

		}

		public int GetLongestIncreasingSubsequenceLength()
		{
			for (int i = 1; i < _numbers.Length; i++)
			{
				for (int j = 0; j < i; j++)
				{
					if (_numbers[i] > _numbers[j]
						&& _maxSequenceLength[i] <= _maxSequenceLength[j])
						_maxSequenceLength[i]++;
				}
			}

			return _maxSequenceLength.Max();
		}

		public int[] GetLongestIncreasingSubsequence()
		{
			int max = GetLongestIncreasingSubsequenceLength();
			var indexOfMax = _maxSequenceLength.ToList().
				IndexOf(max);

			var res = new List<int>() { _numbers[indexOfMax]};


			for (int j = indexOfMax, k = j - 1; k >= 0; k--)
			{
				if (_maxSequenceLength[j] == _maxSequenceLength[k] + 1)
				{
					res.Add(_numbers[k]);
					j = k;
				}
			}


			return res.ToArray();
		}
	}
}
