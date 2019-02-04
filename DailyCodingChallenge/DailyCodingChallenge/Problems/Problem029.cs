using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem029 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM029_DESCRIPTION;
		protected override int Number => 29;

		protected override void Run()
		{
			string message = "AAAAAAAAAAAABBBCCC";
			Console.WriteLine("Initial message: {0}\n", message);
			string encodedMessage = EncodeMessage(message);
			Console.WriteLine("Encoded message: {0}\n", encodedMessage);
			string decodedMessage = DecodeMessage(encodedMessage);
			Console.WriteLine("Decoded message: {0}\n", decodedMessage);
			Console.WriteLine("Correctly encoded and decoded the message: {0}\n", message.Equals(decodedMessage));
		}

		/// <summary>
		/// Encodes the message with Run-Length algorithm. 
		/// </summary>
		/// <param name="message">The message that needs to be encoded.</param>
		/// <returns>The encoded message</returns>
		private string EncodeMessage(string message)
		{
			StringBuilder sb = new StringBuilder();
			int count = 0;
			char c = message.ElementAt(0);
			foreach (char ch in message)
			{
				if(c == ch)
					count++;
				else
				{
					sb.Append(count).Append(c);
					count = 1;
					c = ch;
				}
			}
			sb.Append(count).Append(c);
			return sb.ToString();
		}

		/// <summary>
		/// Decodes the encoded message with Run-Length algorithm.
		/// </summary>
		/// <param name="encodedMessage">The encoded message that needs to be decoded.</param>
		/// <returns>The decoded message</returns>
		private string DecodeMessage(string encodedMessage)
		{
			StringBuilder sb = new StringBuilder();
			StringBuilder number = new StringBuilder();
			foreach (char ch in encodedMessage)
			{
				if (ch <= '9' && ch >= '0')
				{
					number.Append(ch);
				}
				else
				{
					int.TryParse(number.ToString(), out int n);
					for (int i = 0; i < n; i++)
						sb.Append(ch);
					number.Clear();
				}
			}
			return sb.ToString();
		}
	}
}
