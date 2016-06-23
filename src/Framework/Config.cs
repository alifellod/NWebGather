//////////////////////////////////////////////////////////////////////////////////////
//
//  Copyright (c) 2014-2015, 王胜国
//  All rights reserved.
//  email 49480040@qq.com
//
//////////////////////////////////////////////////////////////////////////////////////
namespace NWebGather.Framework
{
    /// <summary>
    /// 文章内容格式化的配置
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 需要换行的标签
        /// </summary>
        public string WrapTag { get; set; }
        /// <summary>
        /// 需要消除为空白的标签
        /// </summary>
        public string WhiteTag { get; set; }
        /// <summary>
        /// 需要缩进的标签
        /// </summary>
        public string IndentTag { get; set; }

        /// <summary>
        /// 需要换行的标签 替换为
        /// </summary>
        public string WrapTagTo { get; set; }
        /// <summary>
        /// 需要消除为空白的标签 替换为
        /// </summary>
        public string WhiteTagTo { get; set; }
        /// <summary>
        /// 需要缩进的标签 替换为
        /// </summary>
        public string IndentTagTo { get; set; }

        /// <summary>
        /// 输出的标题的格式化，如：\n章节：{0}\n\n
        /// {0}表示实际的标题，其它为附加
        /// </summary>
        public string OutputTitleFormat { get; set; }
    }
}
