using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem021 : Problem
	{
		public Problem021() : base(21, ProblemDescription.PROBLEM021_DESCRIPTION) {	}

		protected override void Run()
		{
			List<TimeInterval> times = ReadTimeIntervalList(-1);
			Console.WriteLine("Time intervals:   " + times.AsString());
			times.Sort();
			Console.WriteLine("Sorted intervals: " + times.AsString());

			List<List<TimeInterval>> rooms = new List<List<TimeInterval>>();
			foreach (TimeInterval time in times)
			{
				InsertInterval(time, rooms);
			}

			Console.WriteLine("Minimum number of Rooms required: " + rooms.Count);
			foreach (List<TimeInterval> room in rooms) {
				Console.WriteLine("Room: " + room.AsString());
			}

		}

		private List<TimeInterval> ReadTimeIntervalList(int exitValue = 0)
		{
			List<TimeInterval> list = new List<TimeInterval>();
			while (true)
			{
				Console.Write("Insert startTime (to exit: " + exitValue + "): ");
				if (int.TryParse(Console.ReadLine(), out int startTime))
				{
					if (startTime != exitValue)
					{
						Console.Write("Insert endTime (to exit: " + exitValue + "): ");
						if (int.TryParse(Console.ReadLine(), out int endTime))
						{
							if (endTime != exitValue)
							{
								list.Add(new TimeInterval(startTime, endTime));
							}
							else
								break;
						}
					}
					else
						break;
				}
			}
			return list;
		}

		private void InsertInterval(TimeInterval interval, List<List<TimeInterval>> rooms)
		{
			bool inserted = false;
			foreach (List<TimeInterval> room in rooms)
			{
				bool isOverlapping = false;
				foreach(TimeInterval time in room)
				{
					if (interval.IsOverlapping(time))
						isOverlapping = true;
				}
				if (!isOverlapping)
				{
					room.Add(interval);
					inserted = true;
					break;
				}
			}
			if (!inserted)
			{
				List<TimeInterval> newRoom = new List<TimeInterval>();
				newRoom.Add(interval);
				rooms.Add(newRoom);
			}
		}
	}

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
