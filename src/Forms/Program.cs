using System;
using System.Threading;
using System.Windows.Forms;
//////////////////////////////////////////////////////////////////////////////////////
//
//  Copyright (c) 2014-2015, 王胜国
//  All rights reserved.
//  email 49480040@qq.com
//
//////////////////////////////////////////////////////////////////////////////////////
namespace NWebGather.Forms
{
    static class Program
    {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ThreadExceptionHandler handler = new ThreadExceptionHandler();
            Application.ThreadException += handler.Application_ThreadException;
            try
            {
                //首次调用，保证配置生效
                SysConfig.Init();
                Application.Run(new MDIParentMain());
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("错误信息：{0}\r\n错误位置：{1}\r\n错误源：{2}", ex.Message, ex.StackTrace, ex.Source), "程序异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    /// 
    /// 处理程序异常
    /// 
    internal class ThreadExceptionHandler
    {
        public void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                var ex = e.Exception;
                string errorMessage = "发生错误，是否终止程序，错误信息：\n\n" +
                ex.Message + "\n\n" + ex.GetType() +
                "\n\nStack Trace:\n" + ex.StackTrace;

                if (MessageBox.Show(errorMessage, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                    Application.Exit();
            }
            catch
            {
                try
                {
                    MessageBox.Show("严重错误", "严重错误",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }
    }
}
