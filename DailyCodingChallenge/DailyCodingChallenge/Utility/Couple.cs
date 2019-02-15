
using System;

namespace DailyCodingChallenge.Problems.Utility
{
	class Couple<T>
	{

		public T X { get; private set; }
		public T Y { get; private set; }

		public Couple(T x, T y)
		{
			X = x;
			Y = y;
		}

		public override bool Equals(object obj)
		{
			Couple<T> couple = obj as Couple<T>;
			if (null == couple)
				throw new InvalidCastException("Invalid cast operation. Obj is not a Copule<T>.");
			return base.Equals(couple);
		}

		public override string ToString() => "(" + X + "," + Y + ")";

		public bool Equals(Couple<T> couple) => X.Equals(couple.X) && Y.Equals(couple.Y);

		public static bool operator ==(Couple<T> first, Couple<T> second) => first.X.Equals(second.X) && first.Y.Equals(second.Y);

		public static bool operator !=(Couple<T> first, Couple<T> second) => !(first == second);
	}

}
