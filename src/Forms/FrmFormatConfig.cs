#region

using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using NWebGather.Framework;
using NWebGather.Helper;

#endregion
//////////////////////////////////////////////////////////////////////////////////////
//
//  Copyright (c) 2014-2015, 王胜国
//  All rights reserved.
//  email 49480040@qq.com
//
//////////////////////////////////////////////////////////////////////////////////////
namespace NWebGather.Forms
{
    public partial class FrmFormatConfig : Form
    {
        private readonly XmlSerializer _xmlSerializer = new XmlSerializer(typeof (Config));

        public FrmFormatConfig()
        {
            InitializeComponent();

            if (File.Exists(SysConfig.HtmlFormatConfigPath))
            {
                Config config = _xmlSerializer.Deserialize(new MemoryStream(File.ReadAllBytes(SysConfig.HtmlFormatConfigPath))) as Config;
                if (config != null)
                {
                    txtWrapTag.Text = config.WrapTag.Replace("\n", "\r\n");
                    txtWhiteTag.Text = config.WhiteTag.Replace("\n", "\r\n");
                    txtIndentTag.Text = config.IndentTag.Replace("\n", "\r\n");
                    txtWrapTagTo.Text = config.WrapTagTo;
                    txtWhiteTagTo.Text = config.WhiteTagTo;
                    txtIndentTagTo.Text = config.IndentTagTo;
                    txtOutputTitleFormat.Text = config.OutputTitleFormat;
                }
            }
        }

        /// <summary>
        ///     获取配置实体
        /// </summary>
        /// <returns></returns>
        public static Config GetConfig()
        {
            if (File.Exists(SysConfig.HtmlFormatConfigPath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof (Config));
                Config config = xmlSerializer.Deserialize(new MemoryStream(File.ReadAllBytes(SysConfig.HtmlFormatConfigPath))) as Config;
                if (config == null)
                {
                    return null;
                }

                string[] datas = config.WrapTag.Replace("\r", "").Split('\n');
                if (datas.Length > 1)
                {
                    if (!datas[1].StartsWith("|"))
                    {
                        datas[1] = "|" + datas[1];
                    }
                    config.WrapTag = datas[0] + datas[1] + datas[1].ToUpper();
                    config.WrapTag = config.WrapTag.Trim('|');
                }
                config.WrapTag = StringFormat.EscapeCharacterDecode(config.WrapTag);

                datas = config.WhiteTag.Replace("\r", "").Split('\n');
                if (datas.Length > 1)
                {
                    if (!datas[1].StartsWith("|"))
                    {
                        datas[1] = "|" + datas[1];
                    }
                    config.WhiteTag = datas[0] + datas[1] + datas[1].ToUpper();
                    config.WhiteTag = config.WhiteTag.Trim('|');
                }
                config.WhiteTag = StringFormat.EscapeCharacterDecode(config.WhiteTag);

                datas = config.IndentTag.Replace("\r", "").Split('\n');
                if (datas.Length > 1)
                {
                    if (!datas[1].StartsWith("|"))
                    {
                        datas[1] = "|" + datas[1];
                    }
                    config.IndentTag = datas[0] + datas[1] + datas[1].ToUpper();
                    config.IndentTag = config.IndentTag.Trim('|');
                }
                config.IndentTag = StringFormat.EscapeCharacterDecode(config.IndentTag);

                config.WrapTagTo = StringFormat.EscapeCharacterDecode(config.WrapTagTo);
                config.WhiteTagTo = StringFormat.EscapeCharacterDecode(config.WhiteTagTo);
                config.IndentTagTo = StringFormat.EscapeCharacterDecode(config.IndentTagTo);
                config.OutputTitleFormat = StringFormat.EscapeCharacterDecode(config.OutputTitleFormat);
                return config;
            }
            return null;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Config config = new Config();

            config.WrapTag = txtWrapTag.Text;
            config.WhiteTag = txtWhiteTag.Text;
            config.IndentTag = txtIndentTag.Text;

            config.WrapTagTo = txtWrapTagTo.Text;
            config.WhiteTagTo = txtWhiteTagTo.Text;
            config.IndentTagTo = txtIndentTagTo.Text;
            config.OutputTitleFormat = txtOutputTitleFormat.Text;
            using (TextWriter writer = new StreamWriter(SysConfig.HtmlFormatConfigPath, false))
            {
                _xmlSerializer.Serialize(writer, config);
                writer.Close();
            }
            MessageBox.Show("配置已保存", "网络采集器", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnToUpperLetter_Click(object sender, EventArgs e)
        {
            txtInputString.Text = txtInputString.Text.ToUpper();
        }

        private void btnToLowerLetter_Click(object sender, EventArgs e)
        {
            txtInputString.Text = txtInputString.Text.ToLower();
        }
    }
}