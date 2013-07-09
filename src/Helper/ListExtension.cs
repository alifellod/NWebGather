using System.Collections.Generic;
using System.Text;

namespace NWebGather.Helper
{
    /// <summary>
    /// string 的扩展方法
    /// </summary>
    public static class ListExtension
    {
        /// <summary>
        /// 比默认string.Format高效的替代方法
        /// </summary>
        /// <param name="list"></param>
        /// <param name="split"></param>
        /// <returns></returns>
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
