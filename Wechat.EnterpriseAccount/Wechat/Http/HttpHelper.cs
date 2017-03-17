using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Wechat.EnterpriseAccount.Wechat.Http
{
    /// <summary>
    /// 请求帮助类
    /// </summary>
    public class WXRequest
    {
        /// <summary>
        /// 发起请求获取数据
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="data">发送的数据</param>        
        /// <returns></returns>
        private static string GetResponseContent(string url, string data, string method)
        {
            string result = string.Empty;
            switch (method.ToUpper())
            {
                case "GET":
                    using (var s = CreateGetHttpResponse(url, method).GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(s, Encoding.UTF8);
                        result = reader.ReadToEnd();
                    }
                    break;

                case "POST":
                default:
                    {
                        WebClient webClient = new WebClient();
                        byte[] sendData = Encoding.UTF8.GetBytes(data);
                        webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                        webClient.Headers.Add("ContentLength", sendData.Length.ToString());
                        byte[] recData = webClient.UploadData(url, method, sendData);
                        result = Encoding.UTF8.GetString(recData);
                    }
                    break;
            }
            return result;
        }


        /// <summary>  
        /// 创建GET方式的HTTP请求  
        /// http://www.cnblogs.com/bomo/archive/2013/01/31/2886938.html
        /// </summary>  
        private static HttpWebResponse CreateGetHttpResponse(string url, string method = "GET")
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                request.ProtocolVersion = HttpVersion.Version10;    //http版本，默认是1.1,这里设置为1.0
            request.Method = method;
            return request.GetResponse() as HttpWebResponse;
        }


        public static WxBaseReponse Request(IHttpRequest request)
        {
            return Request<WxBaseReponse>(request);
        }

        public static T Request<T>(IHttpRequest request) where T : WxBaseReponse
        {
            string responseData = "";
            T ins = null;
            try
            {
                responseData = GetResponseContent(request.GetUrl(), request.GetParamters(), request.Method);
            }
            catch (Exception e)
            {
                ins = Activator.CreateInstance<T>();
                ins.ErrCode = "-10000";
                ins.ErrMsg = e.Message;
            }
            if (ins == null)
            {
                try
                {
                    ins = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseData);
                    if (ins != null)
                        ins.ReponseData = responseData;
                }
                catch (Exception e)
                {
                    ins = Activator.CreateInstance<T>();
                    ins.ReponseData = responseData;
                    ins.ErrCode = "-11000";
                    ins.ErrMsg = e.Message;
                }
                if (ins == null)
                    ins = Activator.CreateInstance<T>();
            }
            return ins;
        }

        private static string InitHttpData(IDictionary<string, string> data)
        {
            if (data == null)
                return "";
            StringBuilder sbparameterStr = new StringBuilder();
            foreach (KeyValuePair<string, string> kv in data)
            {
                sbparameterStr.AppendFormat("{0}={1}&", kv.Key, kv.Value);
            }
            return sbparameterStr.ToString().TrimEnd('&');
        }
    }





}
