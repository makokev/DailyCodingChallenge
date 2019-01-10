using System;
using System.Collections.Generic;

namespace DailyCodingChallenge.Problems.Utility
{
	class XORLinkedList<ValueType>
	{
		private readonly Dictionary<int, XORNode> memory = new Dictionary<int, XORNode>();
		private int memoryAddress;
		private int _count;

		private int _first;
		private int _last;

		public XORLinkedList()
		{
			memory.Add(0, new XORNode { Address = 0, Both = 0 ^ 0 });
			memoryAddress = 1;
			_count = 0;
			_first = 0;
			_last = _first;
		}

		public int Count => _count;

		public void Add(ValueType value)
		{
			if (memory[_first].Address == 0)
			{
				memory.Add(memoryAddress, new XORNode { Address = memoryAddress, Both = 0 ^ 0, Value = value });
				_first = memoryAddress;
				_last = _first;
			}
			else
			{
				XORNode secondLast = memory[_last];
				XORNode node = new XORNode { Address = memoryAddress, Both = 0 ^ secondLast.Address, Value = value };
				secondLast.Both = secondLast.Both ^ node.Address;
				_last = memoryAddress;
				memory.Add(memoryAddress, node);
			}
			_count++;
			memoryAddress++;
		}

		public ValueType Get(int index)
		{
			if (index >= Count)
				new ArgumentOutOfRangeException("Index out of bound exception.");

			XORNode currentNode = memory[_first];
			XORNode previewsNode = memory[0];
			int address;
			for (int i = 0; i < index; i++)
			{
				address = previewsNode.Address ^ currentNode.Both;
				previewsNode = currentNode;
				currentNode = memory[address];
			}
			return currentNode.Value;
		}

		public void Remove(int index)
		{
			XORNode currentNode, previousNode, nextNode;
			int address;
			if (index >= Count)
				new ArgumentOutOfRangeException("Index out of bound exception.");

			currentNode = memory[_first];
			previousNode = memory[0];
			if (index == 0) // remove the first node
			{
				nextNode = memory[currentNode.Both];
				if (Count == 1) // only one node
				{
					memory.Remove(_first);
					_first = 0;
					_last = 0;
				}
				else // more than one nodes
				{
					XORNode node = memory[_first];
					memory.Remove(_first);
					nextNode = memory[node.Both];
					nextNode.Both = nextNode.Both ^ _first;
					_first = nextNode.Address;
				}
			}
			else
			{
				// obtain the node that must be eliminated (currentNode)
				for (int i = 0; i < index; i++)
				{
					address = previousNode.Address ^ currentNode.Both;
					previousNode = currentNode;
					currentNode = memory[address];
				}

				if (currentNode.Address == _last) // remove the last node
				{
					int previousAddress = previousNode.Both ^ currentNode.Address;
					previousNode.Both = previousAddress;
					_last = previousNode.Address;
				}
				else // remove another node
				{
					nextNode = memory[currentNode.Both ^ previousNode.Address];
					int nextAddress = nextNode.Both ^ currentNode.Address;
					nextNode.Both = nextAddress ^ previousNode.Address;
					int previousAddress = previousNode.Both ^ currentNode.Address;
					previousNode.Both = previousAddress ^ nextNode.Address;
				}
			}
			_count--;
		}

		class XORNode
		{
			public int Address { get; set; }
			public int Both { get; set; }
			public ValueType Value { get; set; }

			public XORNode() { }

		}

	}
}
