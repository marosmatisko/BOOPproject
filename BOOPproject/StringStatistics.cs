using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BOOPproject
{
    public class StringStatistics
    {
        private readonly List<string> _wordList;
        private readonly List<string> _sentenceList;
        private readonly Dictionary<string, int> _wordMap = new Dictionary<string, int>();
        private readonly Dictionary<char, int> _charMap = new Dictionary<char, int>();
        private readonly Dictionary<char, int> _specialMaps = new Dictionary<char, int>();
        private readonly string _text;

        public StringStatistics(string text)
        {
            _text = text;
            _wordList = Regex.Split(text, @"[^\w]+").Where(s => s != string.Empty).ToList();
            _sentenceList = Regex.Split(text, @"(?<=[.!?])\s+(?=[A-Z])").ToList();
            for (int i = 0; i < _sentenceList.Count; i++)
            {
                _sentenceList[i] = _sentenceList[i].Replace(Environment.NewLine, "").Trim();
                if(_sentenceList[i] == "") _sentenceList.RemoveAt(i);
            }
            foreach (var word in _wordList)
                if (_wordMap.ContainsKey(word)) _wordMap[word]++;
                else _wordMap.Add(word, 1);
            foreach (var character in text.ToCharArray())
            {
                if (char.IsLetterOrDigit(character))
                {
                    if (_charMap.ContainsKey(character)) _charMap[character]++;
                    else _charMap.Add(character, 1);
                }
                else if (!char.IsWhiteSpace(character))
                {
                    if (_specialMaps.ContainsKey(character)) _specialMaps[character]++;
                    else _specialMaps.Add(character, 1);
                }
            }
        }

        public int GetWordsNumber() => _wordList.Count;

        public int GetLinesNumber() => Regex.Split(_text, @"\n+").Count(s => s != string.Empty);

        public int GetSentencesNumber() => _sentenceList.Count;

        public string GetLongestWords() => GetExtremeStrings(_wordList, true);

        public string GetLongestSentences() => GetExtremeStrings(_sentenceList, true);

        public string GetShortestWords() => GetExtremeStrings(_wordList, false);

        public string GetShortestSentences() => GetExtremeStrings(_sentenceList, false);

        private static string GetExtremeStrings(List<string> sourceList, bool longest)
        {
            var lenght = longest
                ? sourceList.OrderByDescending(s => s.Length).First().Length
                : sourceList.OrderByDescending(s => s.Length).Last().Length;
            return string.Join("", sourceList.Select(s => s.Length == lenght ? (s + ", ") : null)).Trim(' ', ',');
        }

        public string GetExtremeFrequentWordsString(bool most)
        {
            var frequent = _wordMap[_wordMap.Keys.First()];
            foreach (var count in _wordMap.Values)
                if ((count > frequent && most) || (count < frequent && !most)) frequent = count;
            return string.Join("", _wordMap.Where(pair => pair.Value == frequent).Select(pair => pair.Key));
        }

        public string GetAlphabeticalWords() => string.Join(", ", _wordList.OrderBy(q => q).ToList());

        public string GetWordsMap() => GetStringMap(_wordMap);

        public string GetCharactersMap() => GetStringMap(_charMap);

        private static string GetStringMap<T>(Dictionary<T, int> temp)
            => string.Join("\n", temp.ToList()).Replace("[", "").Replace("]", "").Replace(",", ":"); 

        public int GetVowelNumber()
        {
            int count = 0;
            foreach (var character in _charMap.Keys.ToArray())
                if (char.ToLower(character) == 'a' || char.ToLower(character) == 'e' || char.ToLower(character) == 'i' ||
                    char.ToLower(character) == 'o' || char.ToLower(character) == 'u' || char.ToLower(character) == 'y')
                    count += _charMap[character];
            return count;
        }

        public int GetConsonantNumber() => _charMap.Sum(list => list.Value) - GetVowelNumber();

        public int GetSpecialCharactersNumber() => _specialMaps.Sum(list => list.Value);

        public int GetQuestionsNumber() => _sentenceList.Count(x => x.EndsWith("?"));

        public int GetImperativeNumber() => _sentenceList.Count(x => x.EndsWith("!"));

        public int GetIndicativeNumber() => _sentenceList.Count(x => x.EndsWith("."));
    }
}