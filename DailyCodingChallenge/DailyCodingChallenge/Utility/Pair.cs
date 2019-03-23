using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems.Utility
{
	class Pair<T, W>
	{
		public T First { get; private set; }
		public W Second { get; private set; }

		public Pair(T first, W second)
		{
			First = first;
			Second = second;
		}

		public override string ToString() =>  "<" + First + ", " + Second + ">";

		public static Pair<T, W> Cons(T first, W second) => new Pair<T, W>(first, second);

		public static T Car(Pair<T, W> pair) => pair.First;

		public static W Cdr(Pair<T, W> pair) => pair.Second;

	}
}
