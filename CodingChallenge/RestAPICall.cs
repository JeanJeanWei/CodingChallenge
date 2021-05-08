using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CodingChallenge
{
    public class RestAPICall
    {
        public RestAPICall()
        {
        }

        public string GetRestResponseString(string url)
        {
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";
            webrequest.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Encoding enc = Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webresponse.Close();
            return result;
        }

        public dynamic GetRestObjects(string url, Dictionary<string, string> parameters = null)
        {

            Uri uri = new Uri(url);
            if (parameters != null && parameters.Count > 0)
            {
                var stringBuilder = new StringBuilder();
                string str = "?";
                foreach(string key in parameters.Keys)
                {
                    stringBuilder.Append(str +
                        WebUtility.UrlEncode(key) +
                         "=" + WebUtility.UrlEncode(parameters[key]));
                    str = "&";
                }

                uri = new Uri(url + stringBuilder.ToString());
            }
            
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(uri);
            webrequest.Method = "GET";
            webrequest.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Encoding enc = Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webresponse.Close();
            JArray array = JArray.Parse(result);
            return array;
        }
    }
}
