using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem003 : Problem
	{

		public Problem003() : base(3, ProblemDescription.PROBLEM003_DESCRIPTION) { }

		protected override void Run()
		{
			//Node root = new Node("root");
			//Node root = new Node("root", new Node("left"));
			BinaryNode<string> root = new BinaryNode<string>("root", new BinaryNode<string>("left", new BinaryNode<string>("left.left")), new BinaryNode<string>("right"));
			string serializedNode = Serialize(root);
			Console.WriteLine("Serialized Node:\n" + serializedNode);
			Console.WriteLine("Deserializing Node...");
			BinaryNode<string> deserializedNode = Deserialize(serializedNode);
			Console.WriteLine("Serializing Deserialized Node:");
			Console.WriteLine(Serialize(deserializedNode));

			if (Serialize(root) == Serialize(Deserialize(Serialize(root))))
				Console.WriteLine("Correct");
			else
				Console.WriteLine("Wrong");
		}

		public string Serialize(BinaryNode<string> node)
		{
			if (null == node)
				return "null pointer";
			StringBuilder sb = new StringBuilder();
			sb.Append("Node('").Append(node.Value).Append("'");
			if (null != node.Left)
			{
				sb.Append(", ").Append(Serialize(node.Left));
				if (null != node.Right)
					sb.Append(", ").Append(Serialize(node.Right));
			}
			sb.Append(")");
			return sb.ToString();
		}
		
		public BinaryNode<string> Deserialize(string serializedNode)
		{
			BinaryNode<string> leftNode = null, rightNode = null;
			
			// Trimming the string
			serializedNode = serializedNode.Substring(serializedNode.IndexOf('(') + 1);
			serializedNode = serializedNode.Remove(serializedNode.Length - 1);

			// Extracting the value
			string val = serializedNode.Substring(serializedNode.IndexOf('\'') + 1);
			val = val.Remove(val.IndexOf('\''));
			Console.WriteLine("Extracted value: " + val);


			// startIndex represents the starting position of the left node (if exists)
			int startIndex = serializedNode.IndexOf(",");
			if(-1 != startIndex) // if there are any other nodes
			{
				string leftString;
				// endIndex represents the ending position of the left node
				// (and the starting position of the right one if exists)
				int endIndex = serializedNode.Length - 1;
				bool evenParentesis = true;
				for (int i = serializedNode.Length - 1; i >= 0; i--)
				{
					char c = serializedNode[i];
					if (c == ')' || c == '(')
						evenParentesis = !evenParentesis;
					else if (c == ',' && evenParentesis)
					{
						endIndex = i;
						break;
					}
				}
				
				if (startIndex != endIndex) // right node exists
				{
					leftString = serializedNode.Remove(endIndex).Substring(startIndex + 2);
					string rightString = serializedNode.Substring(endIndex + 2);
					rightNode = Deserialize(rightString);
				}
				else // only left node exists
				{
					leftString = serializedNode.Substring(startIndex + 2);
				}

				leftNode = Deserialize(leftString);
			}

			return new BinaryNode<string>(val, leftNode, rightNode);
		}
	}
}
