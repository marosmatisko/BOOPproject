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
        public Dictionary<string, int> WordMap { get; } = new Dictionary<string, int>();
        public Dictionary<char, int> CharMap { get; } = new Dictionary<char, int>();
        public Dictionary<char, int> SpecialMaps { get; }= new Dictionary<char, int>();
        private readonly string _text;

        public StringStatistics(string text)
        {
            _text = text;
            _wordList = Regex.Split(text, @"[^\w]+").Where(s => s != string.Empty).ToList();
            _sentenceList = Regex.Split(text, @"(?<=[.!?]|[.!?][""“])\s+(?=[„""A-Z])").ToList();
            for (int i = 0; i < _sentenceList.Count; i++)
            {
                _sentenceList[i] = _sentenceList[i].Replace(Environment.NewLine, "").Trim();
                if(_sentenceList[i] == "") _sentenceList.RemoveAt(i);
            }
            foreach (var word in _wordList)
                if (WordMap.ContainsKey(word.ToLower())) ++WordMap[word.ToLower()];
                else WordMap.Add(word.ToLower(), 1);
            foreach (var character in text.ToCharArray())
            {
                if (char.IsLetterOrDigit(character))
                {
                    if (CharMap.ContainsKey(character)) CharMap[character]++;
                    else CharMap.Add(character, 1);
                }
                else if (!char.IsWhiteSpace(character))
                {
                    if (SpecialMaps.ContainsKey(character)) SpecialMaps[character]++;
                    else SpecialMaps.Add(character, 1);
                }
            }
        }

        public int GetWordsNumber() => _wordList.Count;

        public int GetLinesNumber() => Regex.Split(_text, @"\n+").Count(s => s != string.Empty);

        public int GetParagraphNumber() => Regex.Split(_text, @"\r\n{2,}").Count(s => s != string.Empty);

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
            return string.Join("", sourceList.Select(s => s.Length == lenght ? (s + ", ") : null).Distinct()).Trim(' ', ',');
        }

        public string GetExtremeFrequentWordsString(bool most)
        {
            var frequent = WordMap[WordMap.Keys.First()];
            foreach (var count in WordMap.Values)
                if ((count > frequent && most) || (count < frequent && !most)) frequent = count;
            return string.Join("", WordMap.Where(pair => pair.Value == frequent).Select(pair => pair.Key));
        }

        public string GetAlphabeticalWords() => string.Join(", ", _wordList.OrderBy(q => q).ToList());

        public string GetWordsMapInString() => GetStringMap(WordMap);

        public string GetCharactersMapInString() => GetStringMap(CharMap);

        private static string GetStringMap<T>(Dictionary<T, int> temp)
            => string.Join("\n", temp.ToList()).Replace("[", "").Replace("]", "").Replace(",", ":"); 

        public int GetVowelNumber()
        {
            int count = 0;
            foreach (var character in CharMap.Keys.ToArray())
                if (char.ToLower(character) == 'a' || char.ToLower(character) == 'e' || char.ToLower(character) == 'i' ||
                    char.ToLower(character) == 'o' || char.ToLower(character) == 'u' || char.ToLower(character) == 'y')
                    count += CharMap[character];
            return count;
        }

        public int GetConsonantNumber() => CharMap.Sum(list => list.Value) - GetVowelNumber();

        public int GetSpecialCharactersNumber() => SpecialMaps.Sum(list => list.Value);

        public int GetQuestionsNumber() => _sentenceList.Count(x => new [] {"?", "?\"", @"?“" }.Any(x.EndsWith));

        public int GetImperativeNumber() => _sentenceList.Count(x => new[] { "!", "!\"", @"!“" }.Any(x.EndsWith));

        public int GetIndicativeNumber() => _sentenceList.Count(x => new[] { ".", ".\"", @".“" }.Any(x.EndsWith));
    }
}