#region

using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

#endregion
//////////////////////////////////////////////////////////////////////////////////////
//
//  Copyright (c) 2014-2015, 王胜国
//  All rights reserved.
//  email 49480040@qq.com
//
//////////////////////////////////////////////////////////////////////////////////////
namespace NWebGather.Helper
{
    /// <summary>
    ///     Http协议处理
    ///     默认处理
    ///     编码为utf8
    ///     超时：15000毫秒
    /// </summary>
    public class HttpClient
    {
        /// <summary>
        ///     编码为utf8
        ///     超时：15000毫秒
        /// </summary>
        public HttpClient()
        {
            KeepAlive = true;
            Timeout = 15000;
            Encoder = Encoding.UTF8;
            CookieContainer = new CookieContainer();
            ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback) Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, new RemoteCertificateValidationCallback(CheckValidationResult));
        }

        public HttpClient(string url)
        {
            KeepAlive = true;
            Timeout = 15000;
            Url = url;
            Encoder = Encoding.UTF8;
            CookieContainer = new CookieContainer();
            ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback) Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, new RemoteCertificateValidationCallback(CheckValidationResult));
        }

        public int Timeout { get; set; }
        public CookieContainer CookieContainer { get; set; }
        public bool KeepAlive { get; set; }
        public bool AllowAutoRedirect { get; set; }

        [CompilerGenerated]
        public string AddtionalCookieString { get; set; }

        public string RequestCookieString { get; set; }
        public string ResponseHeaderData { get; set; }
        public string Url { get; set; }
        public Encoding Encoder { get; set; }
        public string ResponseUrl { get; set; }
        public string SavePaht { get; set; }

        /// <summary>
        ///     把cookie添加到请求对象里
        /// </summary>
        /// <param name="url"></param>
        /// <param name="request"></param>
        private void AppendCookie(string url, HttpWebRequest request)
        {
            if (!string.IsNullOrEmpty(RequestCookieString)) //如果请求的Cookie不为空
            {
                Uri uri = new Uri(url);
                CookieCollection cookies = CookieContainer.GetCookies(uri);
                Match match;
                string[] strArray = RequestCookieString.Split(new[] {';'});
                if (strArray.Length > 0)
                {
                    lock (cookies.SyncRoot)
                    {
                        string str = strArray[0];
                        if (cookies[str.Split(new[] {'='})[0]] == null)
                        {
                            foreach (string str2 in strArray)
                            {
                                if (!string.IsNullOrEmpty(str2))
                                {
                                    match = Regex.Match(str2, "(?<name>[^=]+)=(?<value>[^=].+)");
                                    if (match.Success) //把获取到的Cookie添加到请求对象中
                                    {
                                        request.CookieContainer.Add(uri, new Cookie(match.Groups["name"].Value.Trim(), match.Groups["value"].Value.Trim()));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     这是什么东西
        /// </summary>
        public bool CheckValidationResult(object obj, X509Certificate ceft, X509Chain chain, SslPolicyErrors error)
        {
            return true;
        }

        public void ClearCookie()
        {
            CookieContainer = new CookieContainer();
        }

        /// <summary>
        ///     创建提交请求对象
        /// </summary>
        /// <param name="url"></param>
        /// <param name="refer"></param>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private HttpWebRequest CreatePostRequest(string url, string refer, byte[] bytes)
        {
            //url = CheckUrl(url, this.Url);
            //refer = CheckUrl(refer, this.Url);
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(CheckUrl(url));
            request.Timeout = Timeout;
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = CookieContainer;
            AppendCookie(url, request);
            request.Credentials = CredentialCache.DefaultCredentials; //获取或设置请求的身份验证信息
            request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
            request.Method = "POST";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            request.Headers.Add("Cache-Control", "no-cache");
            request.Headers.Add("UA-CPU", "x86");
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, "zh-cn");
            request.Referer = CheckUrl(refer);
            request.ContentLength = bytes.Length;
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip");
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "deflate");
            request.ServicePoint.Expect100Continue = false;
            if (KeepAlive)
            {
                request.KeepAlive = true;
            }
            if (!string.IsNullOrEmpty(AddtionalCookieString))
            {
                request.Headers.Add(HttpRequestHeader.Cookie, AddtionalCookieString);
            }
            request.AllowAutoRedirect = AllowAutoRedirect;
            Stream requestStream = request.GetRequestStream(); //请求
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            return request;
        }

        /// <summary>
        ///     创建提交请求对象
        /// </summary>
        /// <param name="url"></param>
        /// <param name="refer"></param>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private HttpWebRequest CreatePostRequest2(string url, string refer, byte[] bytes)
        {
            //url = CheckUrl(url, this.Url);
            //refer = CheckUrl(refer, this.Url);
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(CheckUrl(url));
            request.Timeout = Timeout;
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = CookieContainer;
            AppendCookie(url, request);
            request.Credentials = CredentialCache.DefaultCredentials; //获取或设置请求的身份验证信息
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Method = "POST";
            request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.2; zh-CN; rv:1.9.2.8) Gecko/20100722 Firefox/3.6.8";
            request.Headers.Add("Cache-Control", "no-cache");
            request.Headers.Add("UA-CPU", "x86");
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, "zh-cn");
            request.Referer = CheckUrl(refer);
            request.ContentLength = bytes.Length;
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip");
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "deflate");
            if (KeepAlive)
            {
                request.KeepAlive = true;
            }
            if (!string.IsNullOrEmpty(AddtionalCookieString))
            {
                request.Headers.Add(HttpRequestHeader.Cookie, AddtionalCookieString);
            }
            request.AllowAutoRedirect = AllowAutoRedirect;
            Stream requestStream = request.GetRequestStream(); //请求
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            return request;
        }

        /// <summary>
        ///     创建普通请求对象
        /// </summary>
        /// <param name="url">访问的地址</param>
        /// <param name="refer">来源地址</param>
        /// <returns></returns>
        private HttpWebRequest CreateRequest(string url, string refer)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new NullReferenceException("url is null");
            }
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(CheckUrl(url));
            request.Timeout = Timeout;
            //指向同一个对象
            request.CookieContainer = CookieContainer; //重要一步,保存Cookie
            AppendCookie(url, request);
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Accept = "*/*";
            request.Method = "GET";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip");
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "deflate");
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, "zh-CN");
            request.KeepAlive = true;
            request.Referer = CheckUrl(refer);
            if (!string.IsNullOrEmpty(AddtionalCookieString))
            {
                request.Headers.Add(HttpRequestHeader.Cookie, AddtionalCookieString);
            }
            request.AllowAutoRedirect = AllowAutoRedirect;
            return request;
        }

        public Bitmap DownloadFile(string url, string refer)
        {
            HttpWebRequest request = CreateRequest(url, refer);
            Stream responseStream;
            Bitmap bitmap = null;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                {
                    responseStream = response.Headers.Get("Content-Encoding") != null ? 
                        new GZipStream(response.GetResponseStream(), CompressionMode.Decompress)
                        : response.GetResponseStream();
                    if (responseStream != null)
                    {
                        bitmap = (Bitmap) Image.FromStream(responseStream);
                    }
                    if (!string.IsNullOrEmpty(ResponseHeaderData))
                    {
                        ResponseHeaderData = response.Headers.Get(ResponseHeaderData);
                    }
                }
            }
            catch (Exception ex)
            {
                LogerDAL.WriteLog(ex);
                return null;
            }
            return bitmap;
        }

        public string DownloadString(string refer)
        {
            return DownloadString(Url, refer);
        }

        /// <summary>
        ///     下载网页代码
        /// </summary>
        /// <param name="urlstr"></param>
        /// <param name="refer"></param>
        /// <returns></returns>
        public string DownloadString(string urlstr, string refer)
        {
            HttpWebRequest request = CreateRequest(urlstr, refer);
            string str = string.Empty;
            StreamReader reader;
            Stream stream;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                {
                    //是否采用压缩读取
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                        reader = new StreamReader(stream, Encoder);
                    }
                    else
                    {
                        reader = new StreamReader(response.GetResponseStream(), Encoder);
                    }
                    str = reader.ReadToEnd();
                    if (!string.IsNullOrEmpty(ResponseHeaderData)) //获取头部信息
                    {
                        ResponseHeaderData = response.Headers.Get(ResponseHeaderData);
                        ResponseUrl = response.ResponseUri.AbsoluteUri; //保存地址
                    }
                }
                return str;
            }
            catch (WebException exception)
            {
                if (exception.Status == WebExceptionStatus.Timeout)
                {
                    return string.Empty;
                }
                return string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public string DownloadString(string urlstr, string refer, bool checkheader)
        {
            HttpWebRequest request = CreateRequest(urlstr, refer);
            string str;
            StreamReader reader;
            Stream stream;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                {
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                        reader = new StreamReader(stream, Encoder);
                    }
                    else
                    {
                        reader = new StreamReader(response.GetResponseStream(), Encoder);
                    }
                    str = reader.ReadToEnd();
                    if (checkheader && !string.IsNullOrEmpty(ResponseHeaderData))
                    {
                        ResponseHeaderData = response.Headers.Get(ResponseHeaderData);
                        ResponseUrl = response.ResponseUri.AbsoluteUri;
                    }
                }
                return str;
            }
            catch (WebException exception)
            {
                if (exception.Status == WebExceptionStatus.Timeout)
                {
                    return string.Empty;
                }
                return string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        ///     下载网页代码
        /// </summary>
        /// <param name="rpath">访问地址</param>
        /// <param name="refer">来源地址</param>
        /// <returns></returns>
        public string DownloadStringWithRePath(string rpath, string refer)
        {
            if (string.IsNullOrEmpty(rpath)) //如果
            {
                return DownloadString(Url, refer);
            }
            if (rpath[0] != '/')
            {
                rpath = '/' + rpath;
            }
            string urlstr = Url + rpath;
            return DownloadString(urlstr, refer);
        }

        public string DownloadStringWithRePath(string rpath, string refer, bool checkheader)
        {
            if (checkheader)
            {
                return DownloadStringWithRePath(rpath, refer);
            }
            if (string.IsNullOrEmpty(rpath))
            {
                return DownloadString(Url, refer);
            }
            if (rpath[0] != '/')
            {
                rpath = '/' + rpath;
            }
            string urlstr = Url + rpath;
            return DownloadString(urlstr, refer, false);
        }

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetGetCookie(string url, string name, StringBuilder data, ref int dataSize);

        /// <summary>
        ///     发送请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="refer"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public string Post(string url, string refer, string data)
        {
            byte[] bytes = Encoder.GetBytes(data);
            string str = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            try
            {
                using (response = (HttpWebResponse) CreatePostRequest(url, refer, bytes).GetResponse())
                {
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                        reader = new StreamReader(stream, Encoder);
                    }
                    else
                    {
                        reader = new StreamReader(response.GetResponseStream(), Encoder);
                    }
                    str = reader.ReadToEnd();
                    if (!string.IsNullOrEmpty(ResponseHeaderData))
                    {
                        ResponseHeaderData = response.Headers.Get(ResponseHeaderData);
                    }
                }
                return str;
            }
            catch (Exception)
            {
                return string.Empty;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
        }

        /// <summary>
        ///     发送请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="refer"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public string Post2(string url, string refer, string data)
        {
            byte[] bytes = Encoder.GetBytes(data);
            string str;
            HttpWebResponse response = null;
            StreamReader reader;
            Stream stream;
            try
            {
                using (response = (HttpWebResponse) CreatePostRequest2(url, refer, bytes).GetResponse())
                {
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                        reader = new StreamReader(stream, Encoder);
                    }
                    else
                    {
                        reader = new StreamReader(response.GetResponseStream(), Encoder);
                    }
                    str = reader.ReadToEnd();
                    if (!string.IsNullOrEmpty(ResponseHeaderData))
                    {
                        ResponseHeaderData = response.Headers.Get(ResponseHeaderData);
                    }
                }
                return str;
            }
            catch (Exception ex)
            {
                LogerDAL.WriteLog(ex);
                return string.Empty;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
        }

        /// <summary>
        ///     采用相对地址进行请求
        /// </summary>
        /// <param name="url">相对地址</param>
        /// <param name="refer">来源地址</param>
        /// <param name="data">发送的请求数据</param>
        /// <returns></returns>
        public string PostByReUrl(string url, string refer, string data)
        {
            return Post(url, refer, data);
        }

        public static string CheckUrl(string url, string baseUrl)
        {
            if (string.IsNullOrEmpty(url))
            {
                return baseUrl;
            }
            url = url.Replace("//", "/");

            if (url.StartsWith("/"))
            {
                return baseUrl + url;
            }
            return url;
        }

        public string CheckUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return Url;
            }
            if (url.StartsWith("http://") || url.StartsWith("https://"))
            {
                return url;
            }
            if (url.StartsWith("/"))
            {
                return Url + url;
            }
            return Url + "/" + url;
        }

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);

        public string GetHtmlCodeByGet(string url, string refer)
        {
            if (string.IsNullOrEmpty(url))
            {
                return string.Empty;
            }
            try
            {
                HttpWebRequest rq = CreateRequest(url, refer);
                StreamReader reader;
                Stream stream;
                using (HttpWebResponse rp = (HttpWebResponse) rq.GetResponse())
                {
                    if (rp.Headers.Get("Content-Encoding") == null)
                    {
                        reader = new StreamReader(rp.GetResponseStream(), Encoder);
                    }
                    else
                    {
                        stream = new GZipStream(rp.GetResponseStream(), CompressionMode.Decompress);
                        reader = new StreamReader(stream, Encoder);
                    }
                    return reader.ReadToEnd();
                }
            }
            catch
            {
                
            }
            return string.Empty;
        }
    }
}