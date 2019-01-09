﻿using DailyCodingChallenge.Problems.Utility;
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

		public override void run()
		{
			Console.WriteLine(this.ToString());
			Console.WriteLine(this.PrintDescription() + "\n");

			//Node root = new Node("root");
			//Node root = new Node("root", new Node("left"));
			Node<string> root = new Node<string>("root", new Node<string>("left", new Node<string>("left.left")), new Node<string>("right"));
			string serializedNode = Serialize(root);
			Console.WriteLine("Serialized Node:\n" + serializedNode);
			Console.WriteLine("Deserializing Node...");
			Node<string> deserializedNode = Deserialize(serializedNode);
			Console.WriteLine("Serializing Deserialized Node:");
			Console.WriteLine(Serialize(deserializedNode));

			if (Serialize(root) == Serialize(Deserialize(Serialize(root))))
				Console.WriteLine("Correct");
			else
				Console.WriteLine("Wrong");
		}

		public string Serialize(Node<string> node)
		{
			if (null == node)
				return "null pointer";
			StringBuilder sb = new StringBuilder();
			sb.Append("Node('").Append(node.val).Append("'");
			if (null != node.left)
			{
				sb.Append(", ").Append(Serialize(node.left));
				if (null != node.right)
					sb.Append(", ").Append(Serialize(node.right));
			}
			sb.Append(")");
			return sb.ToString();
		}
		
		public Node<string> Deserialize(string serializedNode)
		{
			Node<string> leftNode = null, rightNode = null;
			
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

			return new Node<string>(val, leftNode, rightNode);
		}
	}
}