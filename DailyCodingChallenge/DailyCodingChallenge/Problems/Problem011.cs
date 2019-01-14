using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem011 : Problem
	{
		#region Static region

		private static List<string> WORDS;

		static Problem011()
		{
			WORDS = new List<string>();
			WORDS.Add("ciao");
			WORDS.Add("ciaone");
			WORDS.Add("help");
			WORDS.Add("help-desk");
			WORDS.Add("macho");
		}

		#endregion

		public Problem011() : base(11, ProblemDescription.PROBLEM011_DESCRIPTION) { }

		protected override void Run()
		{
			AutocompleteSystem autocompleteSystem = new AutocompleteSystem();
			WORDS.ForEach(autocompleteSystem.Add);

			Console.Write("Insert the prefix: ");
			string prefix = Console.ReadLine();
			
			Console.WriteLine("\nPrefix readed: '" + prefix + "'.\n");
			
			List<string> words = autocompleteSystem.FindWordByPrefix(prefix);
			if (0 == words.Count)
				Console.WriteLine("No words founded.");
			else
				Console.WriteLine("Words founded:");
			words.ForEach(Console.WriteLine);
			
		}

	}
}
