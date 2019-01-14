using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems.Utility
{
	public delegate void Job();

	class JobScheduler
	{
		private int _milliseconds;
		public static Job _job;

		public JobScheduler(int milliseconds, Job job)
		{
			if (milliseconds <= 0)
				throw new ArgumentOutOfRangeException("milliseconds", "milliseconds must be positive (m>0).");
			if (null == job)
				throw new ArgumentNullException("job", "job must be not null.");
			_milliseconds = milliseconds;
			_job = job;
		}

		public void Start()
		{
			System.Threading.Thread.Sleep(_milliseconds);
			_job.Invoke();
		}
	}
}
