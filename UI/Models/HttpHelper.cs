using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace UI.Models
{
    internal class HttpHelper
    {
        /// <summary>
        /// 实现http的GET/DELETE请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="method">请求方式GTE/Delete</param>
        /// <returns></returns>
        public static string HttpGet(string url,string method)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = method;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            {
                return sr.ReadToEnd();
            }
        }

        public static string HttpPost(string url,string method,object param)
        {
           
            string json = JsonConvert.SerializeObject(param);
            byte[] buffer = Encoding.UTF8.GetBytes(json);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = method;
            request.Accept = "*/*";
            request.ContentType = "application/json";
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            using (StreamReader sr = new StreamReader(stream))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
