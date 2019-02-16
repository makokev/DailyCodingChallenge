
using System;

namespace DailyCodingChallenge.Problems.Utility
{
	class Couple<T>
	{

		public T First { get; private set; }
		public T Second { get; private set; }

		public Couple(T first, T second)
		{
			First = first;
			Second = second;
		}

		public override bool Equals(object obj)
		{
			Couple<T> couple = obj as Couple<T>;
			if (null == couple)
				throw new InvalidCastException("Invalid cast operation. Obj is not a Copule<T>.");
			return base.Equals(couple);
		}

		public override string ToString() => "(" + First + "," + Second + ")";

		public bool Equals(Couple<T> couple) => First.Equals(couple.First) && Second.Equals(couple.Second);

		public static bool operator ==(Couple<T> couple1, Couple<T> copule2) => couple1.First.Equals(copule2.First) && couple1.Second.Equals(copule2.Second);

		public static bool operator !=(Couple<T> couple1, Couple<T> couple2) => !(couple1 == couple2);
	}

}
