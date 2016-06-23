//////////////////////////////////////////////////////////////////////////////////////
//
//  Copyright (c) 2014-2015, 王胜国
//  All rights reserved.
//  email 49480040@qq.com
//
//////////////////////////////////////////////////////////////////////////////////////
namespace NWebGather.Framework
{
    public class Task
    {
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
        /// (分页)同一页时,第一页的标识
        /// </summary>
        public string FirstPageMark { get; set; }
        /// <summary>
        /// 采集次数上限，超过此数，则自动停止
        /// </summary>
        public long GatherCountMax { get; set; }
    }
}
