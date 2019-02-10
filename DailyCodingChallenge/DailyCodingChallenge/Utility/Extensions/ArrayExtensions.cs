using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems.Utility.Extensions
{
	public static class ArrayExtensions
	{
		public static string Print(this Array array, string separator = ", ", bool withBrackets = true)
		{
			StringBuilder sb = new StringBuilder();
			if(withBrackets)
				sb.Append("[ ");
			for (int i = 0; i < array.Length; i++)
			{
				if (0 != i)
					sb.Append(separator);
				sb.Append(array.GetValue(i).ToString());
			}
			if(withBrackets)
				sb.Append(" ]");
			return sb.ToString();
		}
	}
}
