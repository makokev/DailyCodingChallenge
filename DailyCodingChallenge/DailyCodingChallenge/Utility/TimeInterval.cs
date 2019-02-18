using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems.Utility
{
	class TimeInterval : IComparable<TimeInterval>
	{
		public int StartTime { get; private set; }
		public int EndTime { get; private set; }

		public TimeInterval(int startTime, int endTime)
		{
			if (startTime < 0)
				throw new ArgumentOutOfRangeException("startTime", "The parameter must be not negative (startTime >= 0).");
			if (endTime < 0 || endTime <= startTime)
				throw new ArgumentOutOfRangeException("endTime", "The parameter must be not negative and greather than startTime (0 <= startTime < endTime).");

			StartTime = startTime;
			EndTime = endTime;
		}

		public bool IsOverlapping(TimeInterval timeInterval) => (null == timeInterval) ? false : !(EndTime <= timeInterval.StartTime || timeInterval.EndTime <= StartTime);

		public override string ToString() => "(" + StartTime + "," + EndTime + ")";

		public int CompareTo(object other)
		{
			TimeInterval timeInterval = other as TimeInterval;
			if (null == timeInterval)
				throw new ArgumentException("other", "The parameter is not an instance of TimeInterval.");
			return CompareTo(timeInterval);
		}

		public int CompareTo(TimeInterval other)
		{
			if (null == other)
				throw new ArgumentException("other", "The parameter is null.");

			if (StartTime < other.StartTime)
				return -1;
			else if (StartTime > other.StartTime)
				return 1;
			else
				return (EndTime - other.EndTime);
		}
	}
}
