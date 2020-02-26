using System;
using System.Collections.Generic;
using System.Linq;

namespace StringAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            AnalyzerDemo.Analyze();
        }
    }

    class AnalyzerDemo
    {
        public static string _text { get; private set; }
        public static Dictionary<string, int> WordFrequencyCount { get; private set; }
        public static Dictionary<int, int> WordLengthFrequencyCount { get; private set; }

        public static void Analyze()
        {
            _text = GetInputString();
            WordFrequencyCount = GetWordsFrequencyCount(_text);
            WordLengthFrequencyCount = GetWordsLengthFrequencyCount(_text);
            PrintInfo();
            Console.ReadLine();
        }

        private static string GetInputString()
        {
            Console.Write("Please input the string you wish to analyze: ");
            string text = Console.ReadLine();

            if (text.Length == 0)
            {
                GetInputString();
            }

            return text;
        }

        private static Dictionary<string, int> GetWordsFrequencyCount(string text)
        {
            Dictionary<string, int> results = new Dictionary<string, int>();

            string[] words = text.Split(' ');

            foreach (var word in words)
            {
                PopulateDictionaryByKey(results, word);
            }

            return results;
        }

        private static Dictionary<int, int> GetWordsLengthFrequencyCount(string text)
        {
            Dictionary<int, int> results = new Dictionary<int, int>();

            string[] words = text.Split(' ');

            foreach (var word in words)
            {
                int wordLength = word.Length;

                PopulateDictionaryByKey(results, wordLength);
            }

            return results;
        }

        private static void PopulateDictionaryByKey<T>(IDictionary<T, int> dictionary, T key)
        {
            int initialCount = 1;


            if (dictionary.ContainsKey(key))
            {
                dictionary[key]++;
            }
            else
            {
                dictionary.Add(key, initialCount);
            }
        }

        private static void PrintInfo()
        {
            PrintDictionary(WordFrequencyCount);
            PrintDictionary(WordLengthFrequencyCount);
        }

        private static void PrintDictionary<T>(IDictionary<T, int> dictionary)
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

        private static Type GetDictionaryKeyType<T>(IDictionary<T, int> dictionary)
        {
            Type dictionaryType = dictionary.GetType();
            Type type = dictionaryType.GetGenericArguments()[0];

            return type;
        }
    }
}
