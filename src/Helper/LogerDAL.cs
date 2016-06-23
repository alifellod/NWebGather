using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
//////////////////////////////////////////////////////////////////////////////////////
//
//  Copyright (c) 2014-2015, 王胜国
//  All rights reserved.
//  email 49480040@qq.com
//
//////////////////////////////////////////////////////////////////////////////////////
namespace NWebGather.Helper
{
    public class LogerDAL
    {
        public static readonly string LogPath;
        public static bool LogEnable;
        static LogerDAL()
        {
            Locker = new object();
            LogEnable = true;
            LogPath = AppDomain.CurrentDomain.BaseDirectory + "log.txt";
        }
        public static object Locker;
        public static void WriteLog(Exception ex)
        {
            if (!LogEnable) return;
            lock (Locker)
            {
                CheckFile();
                Thread.Sleep(50);
                Application.DoEvents();
                StreamWriter sr = new StreamWriter(LogPath, true);
                sr.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture));
                sr.WriteLine(ex.Message);
                sr.WriteLine(ex.StackTrace);
                sr.Close();
            }
        }
        public static void WriteLog(string message)
        {
            if (!LogEnable) return;
            lock (Locker)
            {
                CheckFile();
                StreamWriter sr = new StreamWriter(LogPath, true);
                sr.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture));
                sr.WriteLine(message);
                sr.Close();
            }
        }
        private static void CheckFile()
        {
            if (!File.Exists(LogPath))
            {
                File.Create(LogPath);
            }
        }
    }
}
