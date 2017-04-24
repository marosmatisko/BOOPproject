using BOOPproject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BOOPproject.Tests
{
    [TestClass()]
    public class StringStatisticsTests
    {
        [TestMethod()]
        public void StringStatisticsTest()
        {
            const string text = "Toto je skusobny text so skr. a dvomi! Vetami.";
            var stat = new StringStatistics(text);
            Assert.IsNotNull(stat);
        }

        [TestMethod()]
        public void GetWordsNumberTest()
        {
            const int expected = 9;
            const string text = "Toto je skusobny text so skr. a dvomi! Vetami.";
            var stat = new StringStatistics(text);
            var result = stat.GetWordsNumber();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetLinesNumberTest()
        {
            const int expected = 3;
            const string text = "Toto je skusobny text so skr. a dvomi!\n Vetami.\nLol\n\n";
            var stat = new StringStatistics(text);
            var result = stat.GetLinesNumber();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetParagraphNumberTest()
        {
            const int expected = 2;
            const string text = "Toto je skusobny text so skr. a dvomi!\r\n\n Vetami.\nLol\n\n";
            var stat = new StringStatistics(text);
            var result = stat.GetParagraphNumber();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetSentencesNumberTest()
        {
            const int expected = 3;
            const string text = "Toto je skusobny text so skr. a tromi!\n Vetami.\nLol\n\n";
            var stat = new StringStatistics(text);
            var result = stat.GetSentencesNumber();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetLongestWordsTest()
        {
            const string expected = "skusobny, Vetamimi";
            const string text = "Toto je skusobny text so skr. a tromi!\n Vetamimi.\nLol\n\n";
            var stat = new StringStatistics(text);
            var result = stat.GetLongestWords();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetLongestSentencesTest()
        {
            const string expected = "Toto je skusobny text so skr. a tromi!";
            const string text = "Toto je skusobny text so skr. a tromi!\n Vetamimi.\nLol\n\n";
            var stat = new StringStatistics(text);
            var result = stat.GetLongestSentences();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetShortestWordsTest()
        {
            const string expected = "a";
            const string text = "Toto je skusobny text so skr. a tromi!\n Vetamimi.\nLol\n\n";
            var stat = new StringStatistics(text);
            var result = stat.GetShortestWords();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetShortestSentencesTest()
        {
            const string expected = "Lol";
            const string text = "Toto je skusobny text so skr. a tromi!\n Vetamimi.\nLol\n\n";
            var stat = new StringStatistics(text);
            var result = stat.GetShortestSentences();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetExtremeFrequentWordsStringTest()
        {
            const string expected = "a";
            const string text = "Toto je skusobny text so skr. a tromi!\n Vetamimi.\nLol a\n\n";
            var stat = new StringStatistics(text);
            var result = stat.GetExtremeFrequentWordsString(true);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetAlphabeticalWordsTest()
        {
            const string expected = "a";
            const string expectedEnd = "Vetamimi";
            const string text = "Toto je skusobny text so skr. a tromi!\n Vetamimi.\nLol a\n\n";
            var stat = new StringStatistics(text);
            var result = stat.GetAlphabeticalWords();
            Assert.IsTrue(result.StartsWith(expected) && result.EndsWith(expectedEnd));
        }

        [TestMethod()]
        public void GetWordsMapTest()
        {
            const string expected = "Toto: 1\nje: 1\nskusobny: 2\ntext: 1\nFakt: 1\nText: 1";
            const string text = "Toto je skusobny text!\n Fakt skusobny.\nText\n\n";
            var stat = new StringStatistics(text);
            var result = stat.GetWordsMapInString();
            Assert.IsTrue(result.StartsWith(expected));
        }

        [TestMethod()]
        public void GetCharactersMapTest()
        {
            const string expected = "T: 2\no: 3\nt: 4\nj: 1\ne: 3\ns: 2\nk: 1\nu: 1\nb: 1\nn: 1\ny: 1\nx: 2";
            const string text = "Toto je skusobny text!\nText\n\n";
            var stat = new StringStatistics(text);
            var result = stat.GetCharactersMapInString();
            Assert.IsTrue(result.StartsWith(expected));
        }

        [TestMethod()]
        public void GetVowelNumberTest()
        {
            const int expected = 17;
            const string text = "Toto je skusobny text so skr. a tromi!\n Vetamimi.\nLol a\n\n";
            var stat = new StringStatistics(text);
            var result = stat.GetVowelNumber();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetConsonantNumberTest()
        {
            const int expected = 24;
            const string text = "Toto je skusobny text so skr. a tromi!\n Vetamimi.\nLol a\n\n";
            var stat = new StringStatistics(text);
            var result = stat.GetConsonantNumber();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetSpecialCharactersNumberTest()
        {
            const int expected = 3;
            const string text = "Toto je skusobny text so skr. a tromi!\n Vetamimi.\nLol a\n\n";
            var stat = new StringStatistics(text);
            var result = stat.GetSpecialCharactersNumber();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetQuestionsNumberTest()
        {
            const int expected = 1;
            const string text = "Toto je skusobny text so skr. a tromi!\n Vetamimi.\nLol?\n\n";
            var stat = new StringStatistics(text);
            var result = stat.GetQuestionsNumber();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetImperativeNumberTest()
        {
            const int expected = 1;
            const string text = "Toto je skusobny text so skr. a tromi!\n Vetamimi.\nLol?\n\n";
            var stat = new StringStatistics(text);
            var result = stat.GetImperativeNumber();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetIndicativeNumberTest()
        {
            const int expected = 1;
            const string text = "Toto je skusobny text so skr. a tromi!\n Vetamimi.\nLol?\n\n";
            var stat = new StringStatistics(text);
            var result = stat.GetIndicativeNumber();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetCharacterCountTest()
        {
            const int expected = 40;
            const string text = "Toto je skusobny text so skr. a tromi!\n Vetamimi.\nLol?\n\n";
            var stat = new StringStatistics(text);
            var result = stat.GetCharacterCount();
            Assert.AreEqual(expected, result);
        }
    }
}
