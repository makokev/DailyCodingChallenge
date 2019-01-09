using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems.Utility
{
	class Pair<T, W>
	{

		public Pair(T a, W b)
		{
			this.a = a;
			this.b = b;
		}

		public T a { get; }
		public W b { get; }

		public override string ToString()
		{
			return "(" + a + ", " + b + ")";
		}

		public static Pair<T, W> cons(T a, W b)
		{
			return new Pair<T, W>(a, b);
		}

		public static T car(Pair<T, W> pair)
		{
			return pair.a;
		}

		public static W cdr(Pair<T, W> pair)
		{
			return pair.b;
		}
	}
}
