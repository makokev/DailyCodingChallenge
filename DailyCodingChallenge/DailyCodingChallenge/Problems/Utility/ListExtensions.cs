using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems.Utility
{
	public static class ListExtensions
	{
		public static string AsString<T>(this List<T> list)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("[ ");
			for (int i = 0; i < list.Count; i++)
			{
				if (0 != i)
					sb.Append(", ");

				sb.Append(list[i].ToString());
			}
			sb.Append(" ]");
			return sb.ToString();
		}

	}
}
