using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    /// string 的扩展方法
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 比默认string.Format高效的替代方法
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string FormatWith(this string format, params object[] args)
        {
            if (format == null || args == null)
            {
                throw new ArgumentNullException((format == null) ? "format" : "args");
            }
            var capacity = format.Length + args.Where(a => a != null).Select(p => p.ToString()).Sum(p => p.Length);
            Console.WriteLine(capacity);
            var stringBuilder = new StringBuilder(capacity);
            stringBuilder.AppendFormat(format, args);
            return stringBuilder.ToString();
        }
        public static string FormatWith(this string[] formats, params object[] args)
        {
            if (formats == null || args == null)
            {
                throw new ArgumentNullException((formats == null) ? "format" : "args");
            }
            var capacity = formats.Where(f => f != null).Sum(f => f.Length) +
                           args.Where(a => a != null).Select(p => p.ToString()).Sum(p => p.Length);
            Console.WriteLine(capacity);
            var stringBuilder = new StringBuilder(capacity);
            for (int i = 0; i < formats.Length; i++)
            {
                stringBuilder.AppendFormat(formats[i], args);
            }
            return stringBuilder.ToString();
        }


        public static List<T> ToList<T>(this string text, char split)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }
            string[] strArray = text.Trim(new[] { split }).Split(new[] { split });
            if (strArray.Length == 0)
            {
                return null;
            }
            List<T> list = new List<T>();
            try
            {
                foreach (string str in strArray)
                {
                    T item = (T)Convert.ChangeType(str, typeof(T));
                    list.Add(item);
                }
            }
            catch
            {
                return null;
            }
            return list;
        }
    }
}
