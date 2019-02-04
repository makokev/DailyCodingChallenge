using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems.Utility
{
	class TimeInterval : IComparable
	{
		public int StartTime { get; private set; }
		public int EndTime { get; private set; }

		public TimeInterval(int startTime, int endTime)
		{
			if (startTime < 0)
				throw new ArgumentOutOfRangeException("startTime", "startTime must be not negative (startTime >= 0).");
			if (endTime < 0 || endTime <= startTime)
				throw new ArgumentOutOfRangeException("endTime", "endTime must be not negative and greather than startTime (0 <= startTime < endTime).");

			StartTime = startTime;
			EndTime = endTime;
		}

		public bool IsOverlapping(TimeInterval timeInterval) => !(EndTime <= timeInterval.StartTime || timeInterval.EndTime <= StartTime);

		public override string ToString() => "(" + StartTime + "," + EndTime + ")";

		public int CompareTo(object obj)
		{
			TimeInterval timeInterval = obj as TimeInterval;
			if (null == timeInterval)
				throw new ArgumentException("obj", "The object passed is not an instance of TimeInterval.");

			if (StartTime < timeInterval.StartTime)
				return -1;
			else if (StartTime > timeInterval.StartTime)
				return 1;
			else
				return (EndTime - timeInterval.EndTime);

		}
	}
}
