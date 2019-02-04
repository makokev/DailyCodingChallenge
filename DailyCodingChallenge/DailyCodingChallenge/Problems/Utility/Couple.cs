
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

		public override string ToString()
		{
			return "(" + X + "," + Y + ")";
		}

		public static bool operator ==(Couple<T> first, Couple<T> second)
		{
			return first.X.Equals(second.X) && first.Y.Equals(second.Y);
		}

		public static bool operator !=(Couple<T> first, Couple<T> second)
		{
			return !(first == second);
		}
	}

}
