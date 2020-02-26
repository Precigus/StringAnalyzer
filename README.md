# StringAnalyzer
Bonus task for coding academy application


Given a string which contains words separated by whitespace characters - implement two methods:

- Dictionary﹤string, int﹥ GetWordsFrequencyCount(string text) - returns a dictionary, where the key is a word and the value is the amount of times that word occurs in the text.
For example, GetWordsFrequencyCount("My bike and my book"); returns {"my": 2, "bike": 1, "and": 1, "book": 1}, because the world "my" occurs 2 times and other words occur only once.

- Dictionary﹤int, int﹥ GetWordsLengthFrequencyCount(string text) - returns a dictionary, where the key is the length of a word and the value is the amount of times a word with such length is found in the text.
For example, GetWordsLenthFrequencyCount("My bike and my book"); returns {2: 2, 4: 2, 3: 1}, because there are 2 words that have 2 letters, 2 words that have 4 letters and 1 word that has 3 letters.

It is assumed that the text does not have punctuation marks and the results are case insensitive.