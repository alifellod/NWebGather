namespace NWebGather.Framework
{
    public class GRTask
    {
        /// <summary>
        /// 任务名称
        /// </summary>
        public string TaskName { get; set; }
        /// <summary>
        /// 网站名称(数据源名称)
        /// </summary>
        public string SourceName { get; set; }

        public string FeedId { get; set; }
        /// <summary>
        /// 总采集返回的文章数量
        /// </summary>
        public int GetItemsCount { get; set; }
        /// <summary>
        /// 每次请求返回的文章数量
        /// </summary>
        public int GetItemsCountPer { get; set; }
        public string ContentFilter { get; set; }

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
    }
}
