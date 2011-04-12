using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Windows.Forms;

namespace gDesktopTranslator.Utilities
{
    public static class Translator
    {
        /// <summary>
        /// Translates the text.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="languagePair">The language pair.</param>
        /// <returns></returns>
        public static string TranslateText(string input, string languagePair)
        {
            return TranslateText(input, languagePair, System.Text.Encoding.UTF8);
        }

        /// <summary>
        /// Translate Text using Google Translate
        /// </summary>
        /// <param name="input">The string you want translated</param>
        /// <param name="languagePair">2 letter Language Pair, delimited by "|". 
        /// e.g. "en|da" language pair means to translate from English to Danish</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>Translated to String</returns>
        public static string TranslateText(string input, string languagePair, Encoding encoding)
        {
            string url = String.Format("http://www.google.com/translate_t?hl=en&ie=UTF8&text={0}&langpair={1}", input, languagePair);

            string result = String.Empty;

            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = System.Text.Encoding.UTF8;
                result = webClient.DownloadString(url);
            }

            /*Match m = Regex.Match(result, "(?<=<div id=result_box dir=\"ltr\">)(.*?)(?=</div>)");

            if (m.Success)
                result = m.Value;

            return result;*/
            /*
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(result);
            return doc.DocumentNode.SelectSingleNode("//textarea[@name='utrans']").InnerText; 
             */
            result = result.Substring(result.IndexOf("<span title=\"") + "<span title=\"".Length);
            result = result.Substring(result.IndexOf(">") + 1);
            result = result.Substring(0, result.IndexOf("</span>"));
            return result.Trim();

        }
    }
}