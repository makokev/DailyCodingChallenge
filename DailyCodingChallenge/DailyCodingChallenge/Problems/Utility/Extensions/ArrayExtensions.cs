using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems.Utility.Extensions
{
	public static class ArrayExtensions
	{
		public static string AsString(this Array array)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("[ ");
			for (int i = 0; i < array.Length; i++)
			{
				if (0 != i)
					sb.Append(", ");
				sb.Append(array.GetValue(i).ToString());
			}
			sb.Append(" ]");
			return sb.ToString();
		}
	}
}
