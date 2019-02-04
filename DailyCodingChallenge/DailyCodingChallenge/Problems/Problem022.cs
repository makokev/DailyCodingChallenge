using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem022 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM022_DESCRIPTION;
		protected override int Number => 22;

		protected override void Run()
		{
			List<string> words = new List<string> { "bed", "bath", "bedbath", "and", "beyond" };
			string phrase = "bedbathandbeyond";

			Console.WriteLine("Words: " + words.AsString());
			Console.WriteLine("Phrase: '" + phrase + "'.");

			Console.WriteLine("Parsing...");
			List<List<string>> sentences = ParsePhraseInSentences(phrase, words);
			if (null != sentences)
				foreach (List<string> sentence in sentences)
					Console.WriteLine("Sentence: " + sentence.AsString());
			else
				Console.WriteLine("No sentence translated.");
		}

		private List<List<string>> ParsePhraseInSentences(string phrase, List<string> words)
		{
			List<List<string>> sentences = RecursiveParse(phrase, words, new List<string>());
			return (sentences.Count > 0) ? sentences : null;
		}

		private List<List<string>> RecursiveParse(string phrase, List<string> words, List<string> translation)
		{
			List<List<string>> translations = new List<List<string>>();
			foreach(string word in words)
			{
				if (phrase.StartsWith(word))
				{
					string remainingPhrase = phrase.Remove(0, word.Length);
					List<string> newTranslation = translation.ToList();
					newTranslation.Add(word);
					if (remainingPhrase.Length == 0)
						return new List<List<string>> { newTranslation };
					else
					{
						List<List<string>> partialTranslations = RecursiveParse(remainingPhrase, words, newTranslation);
						foreach (List<string> t in partialTranslations)
							translations.Add(t);
					}
				}
			}
			return translations;
		}
	}
}
