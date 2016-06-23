using System.Collections.Generic;

//////////////////////////////////////////////////////////////////////////////////////
//
//  Copyright (c) 2014-2015, 王胜国
//  All rights reserved.
//  email 49480040@qq.com
//
//////////////////////////////////////////////////////////////////////////////////////
namespace NWebGather.Helper
{
    public class RequestHelper
    {
        /// <summary>
        /// 判断输入字符是否为网址
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
                return false;
            url = url.ToLower();
            return url.StartsWith("http://") || url.StartsWith("https://");
        }
        /// <summary>
        /// 获取网址的域名部分
        /// </summary>
        /// <param name="url">网址</param>
        /// <returns></returns>
        public static string GetUrlDomain(string url)
        {
            //http://data.book.163.com/book/section/0000JFbX/0000JFbX0.html
            if (IsUrl(url))
                return string.Empty;

            string[] s = url.Split('/');

            if (s.Length < 3)
                return string.Empty;
            return "{0}://{1}".FormatWith(s[0], s[2]);
        }
        /// <summary>
        /// 处理页面中的链接为可直接访问的正规网址
        /// </summary>
        /// <param name="oriUrl">需要处理的原链接</param>
        /// <param name="containerUrl">待处理链接所在页面的链接</param>
        /// <returns></returns>
        public static string UrlFormat(string oriUrl, string containerUrl)
        {
            if (string.IsNullOrEmpty(oriUrl))
                return string.Empty;
            if (IsUrl(oriUrl))
                return oriUrl;

            List<string> urlItem = containerUrl.ToList<string>('/');
            if (urlItem.Count < 3)
            {
                return string.Empty;
            }

            //直接从根目录开始
            if (oriUrl.StartsWith("/"))
            {
                while (urlItem.Count > 3)
                {
                    urlItem.RemoveAt(urlItem.Count - 1);
                }
                oriUrl = oriUrl.Remove(0, 1);
            }
            else
            {
                //以退回的方式
                if (oriUrl.StartsWith("../"))
                {
                    //有没有更有效的可变处理方式呢?
                    if (oriUrl.StartsWith("../../../"))
                    {
                        //http://data.book.163.com/book/section/0000JFbX/0000JFbX0.html
                        urlItem.RemoveAt(urlItem.Count - 1);
                        urlItem.RemoveAt(urlItem.Count - 1);
                        urlItem.RemoveAt(urlItem.Count - 1);
                        urlItem.RemoveAt(urlItem.Count - 1);
                        oriUrl = oriUrl.Remove(0, 9);
                    }
                    else if (oriUrl.StartsWith("../../"))
                    {
                        //http://data.book.163.com/book/section/0000JFbX/0000JFbX0.html
                        //http://data.book.163.com/book/
                        urlItem.RemoveAt(urlItem.Count - 1);
                        urlItem.RemoveAt(urlItem.Count - 1);
                        urlItem.RemoveAt(urlItem.Count - 1);
                        oriUrl = oriUrl.Remove(0, 6);
                    }
                    else if (oriUrl.StartsWith("../"))
                    {
                        //http://data.book.163.com/book/section/0000JFbX/0000JFbX0.html
                        //http://data.book.163.com/book/section/

                        //一个 ../
                        //就移除文件名加一个文件夹
                        //就相当于删除/分割的最后两个
                        urlItem.RemoveAt(urlItem.Count - 1);
                        urlItem.RemoveAt(urlItem.Count - 1);
                        oriUrl = oriUrl.Remove(0, 3);
                    }
                }
                else
                {
                    //位于同一个目录
                    urlItem.RemoveAt(urlItem.Count - 1);
                }
            }
            return "{0}/{1}".FormatWith(urlItem.Join("/"), oriUrl);
        }
    }        
}
