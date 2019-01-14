using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;

namespace DailyCodingChallenge.Problems
{
	// C = A ^ B = B ^ A
	// A = C ^ B = B ^ C
	// B = C ^ A = A ^ C

	class Problem006 : Problem
	{
		public Problem006() : base(6, ProblemDescription.PROBLEM006_DESCRIPTION) { }

		protected override void Run()
		{
			XORLinkedList<int> list = new XORLinkedList<int>();
			list.Add(1);
			list.Add(2);
			list.Add(3);
			Console.WriteLine("List:");
			Console.WriteLine("list[0] = " + list.Get(0));
			Console.WriteLine("list[1] = " + list.Get(1));
			Console.WriteLine("list[2] = " + list.Get(2));
			list.Remove(0);
			list.Add(4);
			Console.WriteLine("List:");
			Console.WriteLine("list[0] = " + list.Get(0));
			Console.WriteLine("list[1] = " + list.Get(1));
			Console.WriteLine("list[2] = " + list.Get(2));
			list.Remove(1);
			Console.WriteLine("List:");
			Console.WriteLine("list[0] = " + list.Get(0));
			Console.WriteLine("list[1] = " + list.Get(1));
			list.Add(2);
			list.Remove(2);
			list.Remove(1);
			Console.WriteLine("List:");
			Console.WriteLine("list[0] = " + list.Get(0));
			
		}
	}	
}
