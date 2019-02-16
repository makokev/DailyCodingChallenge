using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems.Utility
{
	public static class ListExtensions
	{
		public static string Print<T>(this List<T> list, string separator = ", ", bool withBrackets = true)
		{
			StringBuilder sb = new StringBuilder();
			if(withBrackets)
				sb.Append("{ ");
			for (int i = 0; i < list.Count; i++)
			{
				if (0 != i)
					sb.Append(separator);

				sb.Append(list[i].ToString());
			}
			if(withBrackets)
				sb.Append(" }");
			return sb.ToString();
		}
	}
}
