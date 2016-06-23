using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using NWebGather.Helper;
//////////////////////////////////////////////////////////////////////////////////////
//
//  Copyright (c) 2014-2015, 王胜国
//  All rights reserved.
//  email 49480040@qq.com
//
//////////////////////////////////////////////////////////////////////////////////////
namespace NWebGather.Framework
{
    public class Worker
    {
        #region 事件
        /// <summary>
        /// 错误触发事件，传入参数 引发的异常对象、错误的类型、当前工作的网址
        /// </summary>
        public event Action<Exception, ErrorType, string> OnError;

        /// <summary>
        /// 工作结束触发事件
        /// </summary>
        public event Action OnWorkEnd;

        /// <summary>
        /// 一次/地址采集完成触发事件，传入参数 采集内容的标题、内容、网址
        /// </summary>
        public event Action<string, string, string> OnWorkItemEnd;
        #endregion


        private readonly Task _task;
        private readonly Config _config;

        private Regex _rgWebTtile;
        private Regex _rgWebContent;
        private Regex _rgContentPageUrl;
        private Regex _rgListPageUrl;
        private Regex _rgSamePageMark;

        private readonly HttpClient _httpRequest;

        public Worker(HttpClient httpRequest, Config config, Task task)
        {
            _httpRequest = httpRequest;
            _config = config;
            _task = task;
        }

        /// <summary>
        /// 发生错误时，执行错误处理函数
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="errorType"></param>
        /// <param name="curUrl">当前工作网址</param>
        private void Error(Exception ex, ErrorType errorType, string curUrl)
        {
            if (OnError != null)
                OnError(ex, errorType, curUrl);
        }
        private void WorkEnd()
        {
            if (OnWorkEnd != null)
                OnWorkEnd();
        }
        private void WorkItemEnd(string title, string content, string curUrl)
        {
            if (OnWorkItemEnd != null)
                OnWorkItemEnd(title, content, curUrl);
        }
        /// <summary>
        /// 通过逐页的模式进行采集
        /// 先在第一页采集，通过采集到的内容匹配到下一页的地址，接着往下走
        /// </summary>
        public void GatherWorkWithPageByPage()
        {
            //逐页模式
            //步骤
            //1、请求第一个页面
            //2、正则出标题、内容、链接
            //3、保存页面内容
            //4、如果找到匹配链接，则继续下一个循环 (如果链接是相对路径，则自动加上前缀)
            //   否则终止任务  
            string curUrl = _task.StartUrl;
            try
            {
                _rgWebTtile = new Regex(_task.WebTitle);
                _rgWebContent = new Regex(_task.WebContent);
                _rgContentPageUrl = new Regex(_task.ContentPageUrl);
                _rgSamePageMark = new Regex(_task.SamePageMark);
              
                long curGatherCount = 0;

                bool hasNextContentUrl = true;
                int sectionIndex = 1;
                while (hasNextContentUrl)
                {
                    if (curGatherCount > _task.GatherCountMax)
                    {
                        break;
                    }

                    //1、请求第一个页面
                    string html = _httpRequest.DownloadString(curUrl, string.Empty);
                    ContentPickup(curUrl, html, sectionIndex++);

                    Match m = _rgContentPageUrl.Match(html);
                    hasNextContentUrl = m.Success;
                    if (hasNextContentUrl)
                    {
                        curUrl = RequestHelper.UrlFormat(m.Groups["value"].Value, curUrl);
                        hasNextContentUrl = !string.IsNullOrEmpty(curUrl);
                    }
                    curGatherCount++;
                }
            }
            catch (Exception ex)
            {
                Error(ex, ErrorType.Global, curUrl);
            }

            WorkEnd();
        }

        /// <summary>
        /// 通过列表模式进行采集
        /// 采集输入的第一个网址的内容，在采集到的内容中匹配符合条件的内容地址及下一个列表的地址
        /// 然后采集匹配到的所有地址的内容
        /// 完成后，使用匹配到的列表地址继续进行采集
        /// </summary>
        public void GatherWorkWithList()
        {
            //列表模式
            //
            //{
            //请求第一个页面
            //获取内容页的链接集合
            //获取下也个列表页面链接
            //循环采集内容页面链接集合的数据
            //完成后进入下一个列表页面
            //}

            string curUrl;
            string gatherUrl = string.Empty;
            try
            {
                _rgListPageUrl = new Regex(_task.ListPageUrl);
                _rgWebTtile = new Regex(_task.WebTitle);
                _rgWebContent = new Regex(_task.WebContent);
                _rgContentPageUrl = new Regex(_task.ContentPageUrl);
                _rgSamePageMark = new Regex(_task.SamePageMark);

                long curGatherCount = 0;

                curUrl = _task.StartUrl;
                string html;

                bool hasContent = true;
                int sectionIndex = 1;
                while (hasContent)
                {
                    if (curGatherCount > _task.GatherCountMax)
                    {
                        break;
                    }
                    //1、请求第一个页面
                    html = _httpRequest.DownloadString(curUrl, string.Empty);

                    //正则出内容页面链接集合
                    MatchCollection mc = _rgContentPageUrl.Matches(html);
                    if (mc.Count > 0)
                    {
                        foreach (Match item in mc)
                        {
                            if (curGatherCount > _task.GatherCountMax)
                            {
                                break;
                            }
                            gatherUrl = RequestHelper.UrlFormat(item.Groups["value"].Value, curUrl);
                            if (string.IsNullOrEmpty(gatherUrl))
                            {
                                continue;
                            }
                            ContentGather(gatherUrl, sectionIndex++);
                            curGatherCount++;
                        }
                    }
                    Match m = _rgListPageUrl.Match(html);
                    hasContent = m.Success;
                    if (hasContent)
                    {
                        curUrl = RequestHelper.UrlFormat(m.Groups["value"].Value, curUrl);
                        hasContent = !string.IsNullOrEmpty(curUrl);
                    }
                    curGatherCount++;
                }
            }
            catch (Exception ex)
            {
                Error(ex, ErrorType.Global, gatherUrl);
            }
            WorkEnd();
        }

        /// <summary>
        /// 采集指定网址的内容
        /// </summary>
        /// <param name="curUrl">当前工作网址</param>
        /// <param name="sectionIndex">章节号</param>
        private void ContentGather(string curUrl, int sectionIndex)
        {
            try
            {
                //1、请求内容页面
                string html = _httpRequest.DownloadString(curUrl, string.Empty);
                ContentPickup(curUrl, html, sectionIndex);

            }
            catch (Exception ex)
            {
                Error(ex, ErrorType.ContentGather, curUrl);
            }

        }
        /// <summary>
        /// 标题及内容提取(包含匹配及处理)
        /// </summary>
        /// <param name="curUrl">当前工作网址</param>
        /// <param name="html">采集到的页面html源码</param>
        /// <param name="sectionIndex"></param>
        private void ContentPickup(string curUrl, string html, int sectionIndex)
        {
            try
            {
                string curWebTitle = string.Empty;
                string curWebContent = string.Empty;

                //正则出标题、内容、链接
                Match m = _rgWebTtile.Match(html);
                if (m.Success)
                {
                    curWebTitle = m.Groups["value"].Value;
                }
                //远方(QQ 503012008)  贡献的更新
                //将内容匹配修改为一个集合，而不是仅仅一个匹配
                var mcContent = _rgWebContent.Matches(html);
                StringBuilder sb = new StringBuilder();
                if (mcContent.Count > 0)
                {
                    foreach (Match item in mcContent)
                    {
                        sb.Append(item.Groups["value"].Value);
                    }
                    curWebContent = sb.ToString();
                }
                ContentProcess(curWebTitle, curWebContent, curUrl, sectionIndex);
            }
            catch (Exception ex)
            {
                Error(ex, ErrorType.ContentGather, curUrl);
            }
        }
        /// <summary>
        /// 将指定的内容进行处理
        /// </summary>
        /// <param name="curWebTitle">标题</param>
        /// <param name="curWebContent">内容</param>
        /// <param name="curUrl">用于提示的，当前操作的页面的网址</param>
        /// <param name="sectionIndex">章节号</param>
        private void ContentProcess(string curWebTitle, string curWebContent, string curUrl, int sectionIndex)
        {
            try
            {
                curWebContent = Regex.Replace(curWebContent, _config.WhiteTag, _config.WhiteTagTo);
                curWebContent = Regex.Replace(curWebContent, _config.IndentTag, _config.IndentTagTo);
                curWebContent = Regex.Replace(curWebContent, _config.WrapTag, _config.WrapTagTo);
                curWebContent = HttpUtility.HtmlDecode(curWebContent);

                if (_task.IsDealSamePage)
                    curWebTitle = curWebTitle.Replace(_task.FirstPageMark, "");

                //如果不处理同页
                //或者处理同页,但满意匹配同页的条件，才添加章节标题                        
                if (!_task.IsDealSamePage || (_task.IsDealSamePage && (!_rgSamePageMark.IsMatch(curWebTitle))))
                {
                    curWebTitle = _config.OutputTitleFormat.FormatWith(sectionIndex, curWebTitle);
                }
                else
                {
                    //否则设置当前标题为空，表示和上一页标题相同
                    curWebTitle = "";
                }
                WorkItemEnd(curWebTitle, curWebContent, curUrl);
            }
            catch (Exception ex)
            {
                Error(ex, ErrorType.ContentProcess, curUrl);
            }
        }

    }
}
