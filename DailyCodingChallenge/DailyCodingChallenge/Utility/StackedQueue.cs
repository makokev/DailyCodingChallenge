using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Utility
{
	class StackedQueue<ValueType>
	{
		private readonly Stack<ValueType> _stack1;
		private readonly Stack<ValueType> _stack2;

		private Stack<ValueType> Stack1 { get => _stack1; }
		private Stack<ValueType> Stack2 { get => _stack2; }
		private bool Stack1Used { get; set; }

		public int Count { get => (Stack1Used) ? Stack1.Count : Stack2.Count; }

		public StackedQueue()
		{
			Stack1Used = true;
			_stack1 = new Stack<ValueType>();
			_stack2 = new Stack<ValueType>();
		}

		public void Enque(ValueType value)
		{
			if (!Stack1Used)
			{
				while (Stack2.Count > 0)
				{
					Stack1.Push(Stack2.Pop());
				}
				Stack1Used = true;
			}
			Stack1.Push(value);
		}

		public ValueType Dequeue()
		{
			if (Stack1Used)
			{
				Revert(Stack1, Stack2);
				while(Stack1.Count > 0)
				{
					Stack2.Push(Stack1.Pop());
				}
				Stack1Used = false;
			}
			return (Stack2.Count > 0) ? Stack2.Pop() : default(ValueType);
		}

		private void Revert(Stack<ValueType> from, Stack<ValueType> to)
		{
			while (from.Count > 0)
			{
				to.Push(from.Pop());
			}
		}
	}
}
