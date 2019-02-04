using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;

namespace DailyCodingChallenge.Problems
{
	class Problem021 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM021_DESCRIPTION;
		protected override int Number => 21;

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
}
