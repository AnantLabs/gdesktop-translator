/**
 * Translator.cs
 *
 * Copyright (C) 2008,  iron9light
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;
using System.Net;
using System.Web;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading;


namespace Google.API.Translate
{
    //Delegate for download complete event
    public delegate void DownloadMp3Completed(String text, String fileName);
    //Delegate for download error
    public delegate void DownloadMp3Failed(String text, String fileName, Exception ex);
    /// <summary>
    /// Translate format.
    /// </summary>
    /// 

    public enum TranslateFormat
    {
        /// <summary>
        /// Text format. Default value.
        /// </summary>
        text,
        /// <summary>
        /// Html format.
        /// </summary>
        html,
    }

    /// <summary>
    /// Utility class for translate and detect.
    /// </summary>
    public static class Translator
    {
        private static int s_Timeout = 0;
        private static Regex oneWordRegex = new Regex(@"^\w+$");
        public static bool RequestedWithDict;

        private static String ttsUrl = "http://translate.google.com.ua/translate_tts?ie=UTF-8&prev=input"; //&q=test&tl=en
        public static int MAX_TTS_LENGTH = 100; //Google supports up to 100 chars
        private static Random random = new Random((int)DateTime.Now.Ticks);
        private static Dictionary<String, String> cache = new Dictionary<string,string>();

        /// <summary>
        /// Get or set the length of time, in milliseconds, before the request times out.
        /// </summary>
        public static int Timeout
        {
            get
            {
                return s_Timeout;
            }
            set
            {
                if (s_Timeout < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                s_Timeout = value;
            }
        }

        /// <summary>
        /// Translate the text from <paramref name="from"/> to <paramref name="to"/>.
        /// </summary>
        /// <param name="text">The content to translate.</param>
        /// <param name="from">The language of the original text. You can set it as <c>Language.Unknown</c> to the auto detect it.</param>
        /// <param name="to">The target language you want to translate to.</param>
        /// <returns>The translate result.</returns>
        /// <exception cref="TranslateException">Translate failed.</exception>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// string text = "我喜欢跑步。";
        /// string translated = Translator.Translate(text, Language.Chinese_Simplified, Language.English);
        /// Console.WriteLine(translated);
        /// // I like running.
        /// </code>
        /// </example>
        public static string Translate(string text, Language from, Language to, bool ifUseProxy, String userName, String Password, String proxyHost, String userDomain)
        {
            RequestedWithDict = false;
            //If text to translate - is one word, then try to get dictionary information for it
            text = text.Trim();
            try{
                if (oneWordRegex.IsMatch(text))
                {
                    String result = TranslateWithDictInfo( text,  from,  to,    ifUseProxy,  userName,  Password,  proxyHost,  userDomain);
                    String resultCopy = result;
                    result = result.Replace(text, "").Replace(",", "").Replace(" ", "");
                    if (result.Trim().Length > 0)
                        return resultCopy;
                }
            }
            catch(Exception ex)
            {
                return Translate(text, from, to, TranslateFormat.text,  ifUseProxy,  userName,  Password,  proxyHost,  userDomain);
            }
            return Translate(text, from, to, TranslateFormat.text,  ifUseProxy,  userName,  Password,  proxyHost,  userDomain);
        }

        /// <summary>
        /// Translate the text from <paramref name="from"/> to <paramref name="to"/>.
        /// </summary>
        /// <param name="text">The content to translate.</param>
        /// <param name="from">The language of the original text. You can set it as <c>Language.Unknown</c> to the auto detect it.</param>
        /// <param name="to">The target language you want to translate to.</param>
        /// <param name="format">The format of the text.</param>
        /// <returns>The translate result.</returns>
        /// <exception cref="TranslateException">Translate failed.</exception>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// string text = GetYourHtmlString();
        /// string translated = Translator.Translate(text, Language.English, Language.French, TranslateFormat.html);
        /// </code>
        /// </example>
        public static string Translate(string text, Language from, Language to, TranslateFormat format, bool ifUseProxy, String userName, String Password, String proxyHost, String userDomain)
        {
            RequestedWithDict = false;
            if (from != Language.Unknown && !LanguageUtility.IsTranslatable(from))
            {
                throw new TranslateException("Can not translate this language : " + from);
            }
            if (!LanguageUtility.IsTranslatable(to))
            {
                throw new TranslateException(string.Format("Can not translate this language to \"{0}\"", to));
            }
            TranslateData result;
            try
            {
                result = Translate(text, LanguageUtility.GetLanguageCode(from), LanguageUtility.GetLanguageCode(to), format,  ifUseProxy,  userName,  Password,  proxyHost,  userDomain);
            }
            catch (TranslateException ex)
            {
                throw new TranslateException("Translate failed!", ex);
            }

            if (format == TranslateFormat.text)
            {
                return HttpUtility.HtmlDecode(result.TranslatedText);
            }
            return result.TranslatedText;
        }

        /// <summary>
        /// Translate the text to <paramref name="to"/> and auto detect which language the text is from.
        /// </summary>
        /// <param name="text">The content to translate.</param>
        /// <param name="to">The target language you want to translate to.</param>
        /// <param name="from">The detected language of the original text.</param>
        /// <returns>The translate result.</returns>
        /// <exception cref="TranslateException">Translate failed.</exception>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// string text = "Je t'aime.";
        /// Language from;
        /// string translated = Translator.Translate(text, Language.English, out from);
        /// Console.WriteLine("\"{0}\" is \"{1}\" in {2}", text, translated, from);
        /// // "Je t'aime." is "I love you." in French.
        /// </code>
        /// </example>
        public static string Translate(string text, Language to, out Language from, bool ifUseProxy, String userName, String Password, String proxyHost, String userDomain)
        {
            RequestedWithDict = false;
            return Translate(text, to, TranslateFormat.text, out from,  ifUseProxy,  userName,  Password,  proxyHost,  userDomain);
        }

        /// <summary>
        /// Translate the text to <paramref name="to"/> and auto detect which language the text is from.
        /// </summary>
        /// <param name="text">The content to translate.</param>
        /// <param name="to">The target language you want to translate to.</param>
        /// <param name="format">The format of the text.</param>
        /// <param name="from">The detected language of the original text.</param>
        /// <returns>The translate result.</returns>
        /// <exception cref="TranslateException">Translate failed.</exception>
        public static string Translate(string text, Language to, TranslateFormat format, out Language from, bool ifUseProxy, String userName, String Password, String proxyHost, String userDomain)
        {
            RequestedWithDict = false;
            if (!LanguageUtility.IsTranslatable(to))
            {
                throw new TranslateException(string.Format("Can not translate this language to \"{0}\"", to));
            }
            TranslateData result;
            try
            {
                result = Translate(text, LanguageUtility.GetLanguageCode(Language.Unknown), LanguageUtility.GetLanguageCode(to), format, ifUseProxy,  userName,  Password,  proxyHost,  userDomain);
            }
            catch (TranslateException ex)
            {
                throw new TranslateException("Translate failed!", ex);
            }
            from = LanguageUtility.GetLanguage(result.DetectedSourceLanguage);

            if (format == TranslateFormat.text)
            {
                return HttpUtility.HtmlDecode(result.TranslatedText);
            }
            return result.TranslatedText;
        }

        /// <summary>
        /// Detect the language for this text.
        /// </summary>
        /// <param name="text">The text you want to test.</param>
        /// <param name="isReliable">Whether the result is reliable</param>
        /// <param name="confidence">The confidence percent of the result.</param>
        /// <returns>The detected language.</returns>
        /// <exception cref="TranslateException">Detect failed.</exception>
        public static Language Detect(string text, out bool isReliable, out double confidence, bool ifUseProxy, String userName, String Password, String proxyHost, String userDomain)
        {
            DetectData result;
            try
            {
                result = Detect(text,  ifUseProxy,  userName,  Password,  proxyHost,  userDomain);
            }
            catch (TranslateException ex)
            {
                throw new TranslateException("Detect failed!", ex);
            }
            string languageCode = result.LanguageCode;
            isReliable = result.IsReliable;
            confidence = result.Confidence;
            Language language = LanguageUtility.GetLanguage(languageCode);
            return language;
        }

        internal static TranslateData Translate(string text, string from, string to, bool ifUseProxy, String userName, String Password, String proxyHost, String userDomain)
        {
            return Translate(text, from, to, TranslateFormat.text,  ifUseProxy,  userName,  Password,  proxyHost,  userDomain);
        }

        internal static TranslateData Translate(string text, string from, string to, TranslateFormat format, bool ifUseProxy, String userName, String Password, String proxyHost, String userDomain)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            if (from == null)
            {
                throw new ArgumentNullException("from");
            }
            if (to == null)
            {
                throw new ArgumentNullException("to");
            }
            
            TranslateRequest request = new TranslateRequest(text, from, to, format);

            WebRequest webRequest;
            if(Timeout != 0)
            {
                webRequest = request.GetWebRequest(Timeout);
            }
            else
            {
                webRequest = request.GetWebRequest();
            }

            if (ifUseProxy)
            {
                webRequest.Proxy = new WebProxy(proxyHost);
                webRequest.Proxy.Credentials = new NetworkCredential(userName,Password,userDomain);
            }
            TranslateData responseData;
            try
            {
                responseData = RequestUtility.GetResponseData<TranslateData>(webRequest);
            }
            catch (GoogleAPIException ex)
            {
                throw new TranslateException(string.Format("request:\"{0}\"", request), ex);
            }
            //MessageBox.Show(responseData.TranslatedText);

            return responseData;
        }

        internal static DetectData Detect(string text, bool ifUseProxy, String userName, String Password, String proxyHost, String userDomain)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            DetectRequest request = new DetectRequest(text);

            WebRequest webRequest;
            if (Timeout != 0)
            {
                webRequest = request.GetWebRequest(Timeout);
            }
            else
            {
                webRequest = request.GetWebRequest();
            }

            if (ifUseProxy)
            {
                webRequest.Proxy = new WebProxy(proxyHost);
                webRequest.Proxy.Credentials = new NetworkCredential(userName, Password, userDomain);
            }

            DetectData responseData;
            try
            {
                responseData = RequestUtility.GetResponseData<DetectData>(webRequest);
            }
            catch (GoogleAPIException ex)
            {
                throw new TranslateException(string.Format("request:\"{0}\"", request), ex);
            }

            return responseData;
        }
        //Get dictionary information from google
        //Issue http://code.google.com/p/gdesctop-translator/issues/detail?id=29
        public static string TranslateWithDictInfo(string text, Language from, Language to, bool ifUseProxy, String userName, String Password, String proxyHost, String userDomain)
        {
            
            String s_DictBaseAddress = @"http://translate.google.com/translate_a/t?client=t";
            StringBuilder url = new StringBuilder();
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            
            if (from != Language.Unknown && !LanguageUtility.IsTranslatable(from))
            {
                throw new TranslateException("Can not translate this language : " + from);
            }
            if (!LanguageUtility.IsTranslatable(to))
            {
                throw new TranslateException(string.Format("Can not translate this language to \"{0}\"", to));
            }

            url.Append(s_DictBaseAddress);
            url.Append("&text=" + HttpUtility.HtmlEncode(text));
            url.Append("&pc=0"); //???
            url.Append("&oc=1"); //???
            url.Append("&multires=0"); //???
            url.Append("&hl=" + LanguageUtility.GetLanguageCode(to));
            url.Append("&sl=" + LanguageUtility.GetLanguageCode(from));
            url.Append("&tl=" + LanguageUtility.GetLanguageCode(to));

            ///Clipboard.SetText(url.ToString(), TextDataFormat.UnicodeText);


            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url.ToString());
            //webRequest.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            //webRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
            //webRequest.Headers.Add("Accept-Charset", "windows-1251,utf-8;q=0.7,*;q=0.7");
            //webRequest.Headers.Add("Accept-Language", "ru");
            webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            webRequest.Method = "GET";
            //webRequest.TransferEncoding = "utf-8";
            webRequest.ContentType = "text/plain; charset=UTF-8";
            webRequest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; uk; rv:1.9.2.8) Gecko/20100722 Firefox/3.6.8";
            
            if (ifUseProxy)
            {
                webRequest.Proxy = new WebProxy(proxyHost);
                webRequest.Proxy.Credentials = new NetworkCredential(userName, Password, userDomain);
            }
            //TranslateData responseData;
            if (webRequest == null)
            {
                throw new ArgumentNullException("request");
            }
            
            string resultString;
            try
            {
                using (WebResponse response = webRequest.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        resultString = reader.ReadToEnd();
                        //MessageBox.Show(resultString);
                    }
                }
            }
            catch (WebException ex)
            {
                throw new GoogleAPIException("Failed to get response.", ex);
            }
            catch (IOException ex)
            {
                throw new GoogleAPIException("Cannot read the response stream.", ex);
            }
            //return resultString;
            //return HttpUtility.HtmlDecode(resultString);
            RequestedWithDict = true;
            return RequestUtility.parseGoogleDictResponce(HttpUtility.HtmlDecode(resultString), LanguageUtility.GetLanguageCode(from).ToLower());
        }

        public static bool SuggestBetterTranslation(String rawText,String original,String suggestion,Language from,Language to, IWebProxy proxy)
        {
            String baseAddress = @"http://translate.google.com.ua/translate_suggestion?oe=UTF-8";
            String param = "langpair=" + LanguageUtility.GetLanguageCode(from) + "|" + LanguageUtility.GetLanguageCode(to);
            param = param + "&text=" + HttpUtility.HtmlEncode(rawText);
            param = param + "&gtrans=" + HttpUtility.HtmlEncode(original);
            param = param + "&utrans=" + HttpUtility.HtmlEncode(suggestion);

            HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create(baseAddress.ToString());

            if (proxy!= null)
            {
                webRequest.Proxy = proxy;
            }

            //TranslateData responseData;
            if (webRequest == null)
            {
                throw new ArgumentNullException("request");
            }

            webRequest.Method = "POST";
            byte[] data = Encoding.ASCII.GetBytes(param);
            webRequest.ContentLength = data.Length;
            
            Stream stOut = webRequest.GetRequestStream();
            
            stOut.Write(data, 0, data.Length);
            //stOut.Flush();
            stOut.Close();

            //string resultString;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse) webRequest.GetResponse())
                {
                    if (HttpStatusCode.OK == response.StatusCode)
                        return true;
                }
            }
            catch (WebException ex)
            {
                throw new GoogleAPIException("Failed to get response.", ex);
            }
            catch (IOException ex)
            {
                throw new GoogleAPIException("Cannot read the response stream.", ex);
            }

            return false;
        }

        public static void getSpeechFile(String text, String language, IWebProxy proxy, DownloadMp3Completed completed, DownloadMp3Failed failed)
        {
            //Check if we allready have that file for that text
            text = text.Trim();
            if (cache.ContainsKey(text.ToUpper()) && File.Exists(cache[text.ToUpper()]))
            {
                completed.Invoke(text,cache[text.ToUpper()]);
                return;
            }
            if (text.Length > MAX_TTS_LENGTH)
                throw new GoogleAPIException("Text to speak is too long.");
            //MP3 files will be downloaded into  Windows' temp folder
            String tempPath = System.IO.Path.GetTempPath();
            //Generate unique file name 
            String fileName;
            fileName = tempPath + "GTranslate" + RandomString(20) + ".mp3";

            String URL = ttsUrl + "&q=" + text + "&tl=" + language;
            DownloadMp3Job job = new DownloadMp3Job(URL,fileName,proxy,text);
            job.Downloaded += new DownloadMp3Completed(job_Downloaded);
            job.Downloaded += completed;
            job.Failed += failed;
            try
            {
                job.execute();
            }
            catch (Exception ex)
            {
                failed.Invoke(text, fileName, ex);
                return;
            }       
        }

        static void job_Downloaded(string text, string fileName)
        {
            if (!cache.ContainsKey(text.ToUpper()))
                cache.Add(text.ToUpper(), fileName);
        }

        private static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

    }

    public class DownloadMp3Job
    {
        public event DownloadMp3Completed Downloaded;
        public event DownloadMp3Failed Failed;
        private String URL;
        private String fileToSave;
        private IWebProxy webProxy;
        private String text;

        public DownloadMp3Job(String URL, String fileName, IWebProxy webProxy, String text)
        {
            this.URL = URL;
            this.fileToSave = fileName;
            this.webProxy = webProxy;
            this.text = text;
        }


        public void download()
        {
            //Create web-client to download the file
            WebClient webClient = new WebClient();
            if (webProxy != null)
            {
                webClient.Proxy = webProxy;
            }
            try
            {
                webClient.DownloadFile(new Uri(URL), fileToSave);
            }
            catch (Exception ex)
            {
                Failed.Invoke(text, fileToSave, ex);
                return;
            }
            Downloaded.Invoke(text, fileToSave);
        }

        public void execute()
        {
            Thread oThread = new Thread(new ThreadStart(this.download));
            oThread.Start();
            //this.download();
        }
    }
}
