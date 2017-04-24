using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BOOPproject;

namespace BOOPprojectWeb {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void Confirm_btn_Click(object sender, EventArgs e) {
            StringStatistics statistics = new StringStatistics(TextBox1.Text);

            ResultsTable.Rows[0].Cells[1].Text = Convert.ToString(statistics.GetSentencesNumber());
            ResultsTable.Rows[1].Cells[1].Text = Convert.ToString(statistics.GetWordsNumber());
            ResultsTable.Rows[2].Cells[1].Text = Convert.ToString(statistics.GetIndicativeNumber());
            ResultsTable.Rows[3].Cells[1].Text = Convert.ToString(statistics.GetQuestionsNumber());
            ResultsTable.Rows[4].Cells[1].Text = Convert.ToString(statistics.GetImperativeNumber());
            ResultsTable.Rows[5].Cells[1].Text = Convert.ToString(statistics.GetConsonantNumber());
            ResultsTable.Rows[6].Cells[1].Text = Convert.ToString(statistics.GetVowelNumber());
            ResultsTable.Rows[7].Cells[1].Text = Convert.ToString(statistics.GetLinesNumber());
            ResultsTable.Rows[8].Cells[1].Text = Convert.ToString(statistics.GetSpecialCharactersNumber());
            ResultsTable.Rows[9].Cells[1].Text = Convert.ToString(statistics.GetParagraphNumber());

            MostFreqWord.Text = statistics.GetExtremeFrequentWordsString(true);
            LongestSntc.Text = statistics.GetLongestSentences();
            LongestWrds.Text = statistics.GetLongestWords();
            ShortestSntc.Text = statistics.GetShortestSentences();
            ShortestWrds.Text = statistics.GetShortestWords();

            PrintDicionary(statistics.WordMap, statistics.GetWordsNumber(), WrdsMapDiv);
            PrintDicionary(statistics.CharMap, statistics.GetCharacterCount(), CharMapDiv);
        }

        private void PrintDicionary<T>(Dictionary<T, int> dic, int count, HtmlGenericControl div) {
            div.InnerHtml = "";
            foreach (KeyValuePair<T, int> entry in dic.OrderByDescending(key => key.Value).ThenBy(key => key.Key)) {
                div.InnerHtml +=
                    $"<a href=\"#\" data-toggle=\"tooltip\" title=\"{entry.Value}x&nbsp;&nbsp;{Math.Round(Convert.ToDouble(entry.Value) / count * 100, 2)}%\">{entry.Key}</a> | ";
            }
        }
    }
}