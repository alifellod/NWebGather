using System.Collections.Generic;
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
    public static class ListExtension
    {
        public static string Join(this List<string> list, string split)
        {
            if (list == null || list.Count == 0)
                return string.Empty;
            StringBuilder sb = new StringBuilder();
            foreach (string item in list)
            {
                sb.AppendFormat("{0}{1}", item, split);
            }
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - split.Length, split.Length);
            }
            return sb.ToString();

        }
    }
}
