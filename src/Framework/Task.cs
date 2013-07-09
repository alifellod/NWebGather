namespace NWebGather.Framework
{
    public class Task
    {
        /*
         <taskName>500年来谁著史</taskName>
	<startUrl>http://data.book.163.com/book/section/0000JFbX/0000JFbX0.html</startUrl>
	<title>&quot;article-sectioname&quot;&gt;(?&lt;value&gt;.*?)&lt;/div&gt;</title>
	<content>&quot;bk-article-body&quot;&gt;(?&lt;value&gt;[\s\S]*?)&lt;/div&gt;</content>
	<nextUrl>返回目录页&lt;/a&gt;[\s\S]*?&lt;a href=&quot;(?&lt;value&gt;.*?)&quot; target=&quot;_self&quot;[\s\S]*?id=&quot;nextsection&quot;&gt;下一章&lt;/a&gt;</nextUrl>
	<savePath>C:\Users\Administrator\Desktop\gather\</savePath>
	<saveOnlyFile>1</saveOnlyFile>
	<startClearMessageBox>1</startClearMessageBox>
	<defaultEncode>gb2312</defaultEncode>
	<dealSamePage>1</dealSamePage>
	<firstPageMark>(1)</firstPageMark>
	<samePageMark>(\d*?)</samePageMark>
         */
        /// <summary>
        /// 任务名称
        /// </summary>
        public string TaskName { get; set; }
        /// <summary>
        /// 网站名称(数据源名称)
        /// </summary>
        public string SourceName { get; set; }

        /// <summary>
        /// 采集模式：逐页、列表
        /// </summary>
        public string GatherModel { get; set; }
        /// <summary>
        /// 开始页面链接
        /// </summary>
        public string StartUrl { get; set; }
        /// <summary>
        /// 列表页面的链接匹配正则
        /// </summary>
        public string ListPageUrl { get; set; }
        /// <summary>
        /// 页面标题的匹配正则
        /// </summary>
        public string WebTitle { get; set; }
        /// <summary>
        /// 页面内容的匹配正则
        /// </summary>
        public string WebContent { get; set; }
        /// <summary>
        /// 内容页面链接的匹配正则
        /// </summary>
        public string ContentPageUrl { get; set; }
        /// <summary>
        /// 采集的数据保存路径
        /// </summary>
        public string SavePath { get; set; }
        /// <summary>
        /// 是否只保存在一个文件
        /// </summary>
        public bool IsSaveOnlyFile { get; set; }
        /// <summary>
        /// 是否启动时清空消息框
        /// </summary>
        public bool IsStartClearMessageBox { get; set; }
        /// <summary>
        /// 默认采集编码
        /// </summary>
        public string DefaultEncode { get; set; }
        /// <summary>
        /// 是否处理同页
        /// </summary>
        public bool IsDealSamePage { get; set; }
        /// <summary>
        /// 同页的标识
        /// </summary>
        public string SamePageMark { get; set; }
        /// <summary>
        /// 同页时,第一页的标识
        /// </summary>
        public string FirstPageMark { get; set; }
        /// <summary>
        /// 采集次数上限，超过此数，则自动停止
        /// </summary>
        public long GatherCountMax { get; set; }
    }
}
