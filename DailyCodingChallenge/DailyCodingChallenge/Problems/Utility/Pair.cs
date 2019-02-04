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
			A = a;
			B = b;
		}

		public T A { get; }
		public W B { get; }

		public override string ToString()
		{
			return "(" + A + ", " + B + ")";
		}

		public static Pair<T, W> Cons(T a, W b)
		{
			return new Pair<T, W>(a, b);
		}

		public static T Car(Pair<T, W> pair)
		{
			return pair.A;
		}

		public static W Cdr(Pair<T, W> pair)
		{
			return pair.B;
		}
	}
}
