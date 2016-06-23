using System.IO;
//////////////////////////////////////////////////////////////////////////////////////
//
//  Copyright (c) 2014-2015, 王胜国
//  All rights reserved.
//  email 49480040@qq.com
//
//////////////////////////////////////////////////////////////////////////////////////
namespace NWebGather.Forms
{
    public class SysConfig
    {
        /// <summary>
        /// 文章内容进行html标签格式化配置文件路径
        /// </summary>
        public static string HtmlFormatConfigPath { get; set; }
        /// <summary>
        /// 普通任务配置保存路径
        /// </summary>
        public static string TaskConfigPath { get; set; }
        /// <summary>
        /// 谷歌阅读器任务配置保存路径
        /// </summary>
        public static string GRTaskConfigPath { get; set; }
        static SysConfig()
        {
            if (File.Exists("Config\\path.txt"))
            {
                string[] paths = File.ReadAllLines("Config\\path.txt");
                if (paths.Length < 6)
                {
                    SetDefaultConfig();
                }
                else
                {
                    HtmlFormatConfigPath = paths[1];
                    TaskConfigPath = paths[3].EndsWith("\\") ? paths[3] : paths[3] + "\\";
                    GRTaskConfigPath = paths[5].EndsWith("\\") ? paths[5] : paths[5] + "\\";
                }
            }
            else
            {
                SetDefaultConfig();
            }
        }
        public static void Init()
        {
            var v = GRTaskConfigPath;
        }
        /// <summary>
        /// 设置默认路径配置
        /// </summary>
        private static void SetDefaultConfig()
        {
            HtmlFormatConfigPath = "Config\\HtmlFormatConfig.xml";
            TaskConfigPath = "Config\\task";
            GRTaskConfigPath = "Config\\grtask";
        }
    }
}
