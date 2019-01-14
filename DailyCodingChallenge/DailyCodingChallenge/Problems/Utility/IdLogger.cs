using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems.Utility
{
	class IdLogger
	{
		private readonly List<string> _logger = new List<string>();

		private uint Size { get; set; }
		private List<string> Logger => _logger;

		public IdLogger(uint size)
		{
			if (size == 0)
				new ArgumentOutOfRangeException("IdLogger creation failed: N must be positive (n>0).");
			Size = size;
		}

		public void Record(string orderId)
		{
			if (Logger.Count == Size) { 
				Logger.RemoveAt(0);
			}
			Logger.Add(orderId);
		}

		public string GetLast(int index)
		{
			if (index <= 0)
				throw new ArgumentOutOfRangeException("index", "GetLast in IdLogger failed: index must be positive (i>0).");
			if(Logger.Count < index)
				return null;
			int realIndex = Logger.Count - index;
			return Logger[realIndex];
		}
	}
}
