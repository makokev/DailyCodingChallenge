using DailyCodingChallenge.Utility;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem053 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM053_DESCRIPTION;
		protected override int Number => 53;

		protected override void Run()
		{
			int num = 3;
			StackedQueue<int> queue = new StackedQueue<int>();

			// filling the queue
			Console.WriteLine("Queueing values:");
			for (int i = 0; i < num; i++)
			{
				Console.WriteLine("Queued value '{0}'.", i);
				queue.Enque(i);
			}

			// remove all values and check the correct extraction order
			int value;
			Console.WriteLine("\nDequeueing values:");
			for(int i = 0; i < num; i++)
			{
				value = queue.Dequeue();
				Console.WriteLine("Dequeued correct value '{0}': {1}.", value, value == i);
			}
		}
	}
}
