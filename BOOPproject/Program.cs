using System;

namespace BOOPproject
{
    class Program
    {
        static void Main()
        {
            string text = "Toto je retezec predstavovany nekolika radky,\n"
                         + "ktere jsou od sebe oddeleny znakem LF (Line Feed).\n"
                         + "Je tu i nejaky ten vykricnik! Pro ucely testovani i otaznik?\n"
                         + "Toto je jen zkratka zkr. ale ne konec vety. A toto je\n"
                         + "posledni veta!";

            StringStatistics stats = new StringStatistics(text);
            Console.WriteLine("Word count:{0}\nSentences count:{1}", stats.GetWordsNumber(), stats.GetSentencesNumber());
            Console.WriteLine("Lines count:{0}\nLongest strings:{1}", stats.GetLinesNumber(), stats.GetLongestWords());
            Console.WriteLine("Shortest string:{0}", stats.GetShortestWords());
            Console.WriteLine("Most frequent words:{0}", stats.GetExtremeFrequentWordsString(true));
            Console.WriteLine("Alphabetical words:{0}", stats.GetAlphabeticalWords());
            Console.WriteLine("Word Map:{0}", stats.GetWordsMapInString());

            Console.ReadLine();
        }
    }
}
