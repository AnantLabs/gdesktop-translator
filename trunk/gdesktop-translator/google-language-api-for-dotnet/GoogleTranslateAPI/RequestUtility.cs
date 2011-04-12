﻿/**
 * RequestUtility.cs
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
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace Google.API
{
    internal class RequestUtility
    {
        public static readonly Encoding s_Encoding = Encoding.UTF8;

        public static T GetResponseData<T>(WebRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            string resultString;
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), s_Encoding))
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

            ResultObject<T> resultObject;
            try
            {
                resultObject = JavaScriptConvert.DeserializeObject<ResultObject<T>>(resultString);
            }
            catch(JsonSerializationException ex)
            {
                throw new GoogleAPIException(
                    string.Format("Deserialize Failed.{0}Type:{1}{0}String:{2}", Environment.NewLine,
                                  typeof (ResultObject<T>), resultString));
            }

            if (resultObject.ResponseStatus != 200)
            {
                throw new GoogleAPIException(string.Format("[error code:{0}]{1}", resultObject.ResponseStatus, resultObject.ResponseDetails));
            }
            return resultObject.ResponseData;
        }

        public static T GetResponseData<T>(string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }
            WebRequest request = WebRequest.Create(url);
            return GetResponseData<T>(request);
        }

        public static String parseGoogleDictResponce(String response, String originalLangCode)
        {
            String strToParse = response;//"[[[\"робити\",\"do\",\"robyty\"]],[[\"noun\",[\"до\",\"дія\",\"угода\",\"обман\",\"розвага\"]],[\"verb\",[\"робити\",\"зробити\",\"виконувати\",\"виконати\",\"чинити\",\"займатися\",\"діяти\",\"творити\",\"завдавати\",\"вдіяти\",\"влаштовувати\",\"накоїти\",\"коїти\",\"готувати\"]]],\"en\"]";
            String pattern = "\""+originalLangCode+"\"";
            int pos = response.IndexOf(pattern);
            if (pos != -1)
            {
                strToParse = strToParse.Substring(0,pos);
            }

            StringBuilder result = new StringBuilder();
            //boolean firstComma = true;
            for (int i = 0; i<strToParse.Length; ++i)
            {
                char c = strToParse[i];
                if (c == '[' || c == ']' || c == '"' ||c == '\"' /*||c == ' '*/)
                    continue;
                if (c == ',')
                {
                    if (i > 1 && strToParse[i - 1] == ']' && strToParse[i - 2] == ']')
                    {
                        if (i + 1 < strToParse.Length && strToParse[i + 1] != ',')
                        {
                            result.Append(System.Environment.NewLine);

                        }

                        continue;
                    }
                    else if (i > 0 && i + 1 < strToParse.Length && strToParse[i - 1] == '"' && strToParse[i + 1] == '[')
                    {
                        result.Append(" - ");
                        continue;
                    }
                    else if (i > 0 && strToParse[i - 1] == ',')
                        continue;
                    else
                    {
                        result.Append(", ");
                        continue;
                    }
                }
                

                result.Append(c);
            }

            return result.ToString();
        }
    }
}
