
using System;
using System.Collections.Generic;

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

		public bool Equals(Couple<T> couple)
		{
			bool result = (couple != null);
			result = (!result) ? false : (First != null && couple.First != null && First.Equals(couple.First)) || (null == First && null == couple.First);
			result = (!result) ? false : (Second != null && couple.Second != null && Second.Equals(couple.Second)) || (null == Second && null == couple.Second);
			return result;
		}
		public override int GetHashCode()
		{
			var hashCode = 43270662;
			hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(First);
			hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(Second);
			return hashCode;
		}

		public static bool operator ==(Couple<T> couple1, Couple<T> couple2) =>	(null == couple1 || null == couple2) ? false : couple1.Equals(couple2);
		public static bool operator !=(Couple<T> couple1, Couple<T> couple2) => !(couple1 == couple2);
	}

}
