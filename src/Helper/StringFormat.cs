using System;
using System.Globalization;
using System.Text;
using System.IO;
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
    /// 字符过滤
    /// </summary>
    public class StringFormat
    {
        //字符串清理
        public static string InputText(string inputString, int maxLength)
        {
            StringBuilder retVal = new StringBuilder();

            // 检查是否为空
            if (!string.IsNullOrEmpty(inputString))
            {
                inputString = inputString.Trim();

                //检查长度
                if (inputString.Length > maxLength)
                    inputString = inputString.Substring(0, maxLength);

                //替换危险字符
                for (int i = 0; i < inputString.Length; i++)
                {
                    switch (inputString[i])
                    {
                        case '"':
                            retVal.Append("&quot;");
                            break;
                        case '<':
                            retVal.Append("&lt;");
                            break;
                        case '>':
                            retVal.Append("&gt;");
                            break;
                        default:
                            retVal.Append(inputString[i]);
                            break;
                    }
                }
                retVal.Replace("'", " ");// 替换单引号
            }
            return retVal.ToString();

        }
        /// <summary>
        /// 转换成 HTML code
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>string</returns>
        public static string Encode(string str)
        {
            str = str.Replace("&", "&amp;");
            str = str.Replace("'", "''");
            str = str.Replace("\"", "&quot;");
            str = str.Replace(" ", "&nbsp;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace("\n", "<br>");
            return str;
        }
        /// <summary>
        ///解析html成 普通文本
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>string</returns>
        public static string Decode(string str)
        {
            str = str.Replace("<br>", "\n");
            str = str.Replace("&gt;", ">");
            str = str.Replace("&lt;", "<");
            str = str.Replace("&nbsp;", " ");
            str = str.Replace("&quot;", "\"");
            return str;
        }
        /// <summary>
        /// 检查字符串最大长度，返回指定长度的串
        /// </summary>
        /// <param name="sqlInput">输入字符串</param>
        /// <param name="maxLength">最大长度</param>
        /// <returns></returns>			
        public static string SqlText(string sqlInput, int maxLength)
        {
            if (!string.IsNullOrEmpty(sqlInput))
            {
                sqlInput = sqlInput.Trim();
                if (sqlInput.Length > maxLength)//按最大长度截取字符串
                    sqlInput = sqlInput.Substring(0, maxLength);
            }
            return sqlInput;
        }
        /// <summary>
        /// 清除一般非法输入
        ///去除,
        ///去除左尖括号
        ///去除>
        ///去除--
        ///去除'
        ///去除"
        ///去除=
        ///去除%
        ///去除空格
        /// </summary>
        /// <param name="sqlText"></param>
        /// <returns></returns>
        public static string SqlTextClear(string sqlText)
        {
            if (sqlText == null)
            {
                return null;
            }
            if (sqlText == "")
            {
                return "";
            }
            sqlText = sqlText.Replace(",", "");//去除,
            sqlText = sqlText.Replace("<", "");//去除<
            sqlText = sqlText.Replace(">", "");//去除>
            sqlText = sqlText.Replace("--", "");//去除--
            sqlText = sqlText.Replace("'", "");//去除'
            sqlText = sqlText.Replace("\"", "");//去除"
            sqlText = sqlText.Replace("=", "");//去除=
            sqlText = sqlText.Replace("%", "");//去除%
            sqlText = sqlText.Replace(" ", "");//去除空格
            return sqlText;
        }

        //过滤非法字符(判断是否非法，非法返回true)
        public static bool Illegal(string ss)
        {
            string[] aryReg = { "'", "<", ">", "%", "\"\"", ",", ".", ">=", "=<", "-", "_", ";", "||", "[", "]", "&", "/", "-", "|" };
            if (string.IsNullOrEmpty(ss))
            {
                return false;
            }
            for (int i = 0; i < aryReg.Length; i++)
            {
                if (ss.Contains(aryReg[i]))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IllegalTime(string ss)
        {
            string[] aryReg = { "'", "<", ">", "%", "\"\"", ",", ">=", "=<", "||", "&", "|" };
            if (string.IsNullOrEmpty(ss))
            {
                return false;
            }
            for (int i = 0; i < aryReg.Length; i++)
            {
                if (ss.Contains(aryReg[i]))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 错误信息格式化输出
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string FormatExceptionString(Exception ex)
        {
            if (ex == null) return "";
            string msg= string.Format("{0}\n详细信息如下：\n［InnerException］{1}\n［Source］ {2}\n［TargetSite］{3}\n［StackTrace］ {4}"
                , ex.Message, ex.InnerException
                , ex.Source
                , ex.TargetSite
                , ex.StackTrace);
            return msg.Replace("在","\n在");
        }
        /// <summary>
        /// 转义字符 显示形式 转换成 实际形式 \\n to \n 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string EscapeCharacterDecode(string input)
        {
            StringBuilder builder = new StringBuilder();
            StringWriter writer = new StringWriter(builder);
            int l = input.Length;
            int maxIndex = l - 1;
            for (int i = 0; i < l; i++)
            {
                char ch = input[i];
                if (ch == '\\' && i < maxIndex)
                {
                    char ch2 = input[i + 1];
                    char curchar = EscapeCharacterEntities.Lookup(ch2.ToString(CultureInfo.InvariantCulture));
                    if (curchar != (char)0)
                    {
                        writer.Write(curchar);
                        i++;
                        continue;
                    }
                }
                writer.Write(ch);
            }
            return builder.ToString();
        }
        /// <summary>
        /// 转义字符 显示形式 转换成 实际形式 \\n to \n 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string EscapeCharacterEncode(string input)
        {
            StringBuilder builder = new StringBuilder();
            StringWriter writer = new StringWriter(builder);
            int l = input.Length;
            int maxIndex = l - 1;
            for (int i = 0; i < l; i++)
            {
                char ch = input[i];
                if (ch == '\\' && i < maxIndex)
                {
                    char ch2 = input[i + 1];
                    char curchar = EscapeCharacterEntities.Lookup(ch2.ToString(CultureInfo.InvariantCulture));
                    if (curchar != (char)0)
                    {
                        writer.Write(curchar);
                        i++;
                        continue;
                    }
                }
                writer.Write(ch);
            }
            return builder.ToString();
        }
    }

}
