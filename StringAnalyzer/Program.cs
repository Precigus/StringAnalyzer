using System;
using System.Collections.Generic;
using System.Linq;

namespace StringAnalyzer
{
	class Program
	{
		static void Main(string[] args)
		{
			StringAnalyzer.getInstance();
		}
	}

	class StringAnalyzer
	{
		private static StringAnalyzer _instance = new StringAnalyzer();

		private string _text { get; set; }
		private Dictionary<string, int> WordFrequencyCount { get; set; }
		private Dictionary<int, int> WordLengthFrequencyCount { get; set; }

		private StringAnalyzer() 
		{
			AnalyzeString();
		}

		public static StringAnalyzer getInstance()
		{
			return _instance;
		}
		
		public void AnalyzeString()
		{
			_text = GetInputString();
			WordFrequencyCount = GetWordsFrequencyCount(_text);
			WordLengthFrequencyCount = GetWordsLengthFrequencyCount(_text);
			PrintInfo();
			Console.ReadLine();
		}

		private string GetInputString()
		{
			Console.Write("Please input the string you wish to analyze: ");
			string text = Console.ReadLine();

			if (text.Length == 0)
			{
				GetInputString();
			}
			
			return text;
		}

		private Dictionary<string, int> GetWordsFrequencyCount(string text)
		{
			Dictionary<string, int> results = new Dictionary<string, int>();

			string[] words = text.Split(' ');
			int initialCount = 1;

			try
			{
				foreach (var word in words)
				{
					if (results.ContainsKey(word))
					{
						results[word]++;
					}
					else
					{
						results.Add(word, initialCount);
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine($"Error message: {e.Message}");
			}

			return results;
		}

		private Dictionary<int, int> GetWordsLengthFrequencyCount(string text)
		{
			Dictionary<int, int> results = new Dictionary<int, int>();

			string[] words = text.Split(' ');
			int initialCount = 1;

			try
			{
				foreach (var word in words)
				{
					int wordLength = word.Length;

					if (results.ContainsKey(wordLength))
					{
						results[wordLength]++;
					}
					else
					{
						results.Add(wordLength, initialCount);
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine($"Error message: {e.Message}");
			}

			return results;
		}

		private void PrintInfo()
		{
			PrintDictionary(WordFrequencyCount);
			PrintDictionary(WordLengthFrequencyCount);
		}

		private void PrintDictionary<T>(IDictionary<T, int> dictionary)
		{
			string text = "";
			Type keyType = GetDictionaryKeyType(dictionary);

			foreach (var record in dictionary)
			{
				switch (keyType.Name)
				{
					case "String":
						text += $"\"{record.Key}\": ";
						break;
					case "Int32":
						text += $"{record.Key}: ";
						break;
					default:
						break;
				}
				text += $"{record.Value}, ";
			}

			text = text.Remove(text.Length - 2);
			Console.WriteLine(text);
		}

		private Type GetDictionaryKeyType<T> (IDictionary<T, int> dictionary)
		{
			Type dictionaryType = dictionary.GetType();
			Type type = dictionaryType.GetGenericArguments()[0];

			return type;
		}
	}
}
