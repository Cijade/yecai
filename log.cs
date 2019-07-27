using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using yecai;

public class Log
{
    public static void WriteStr(string format, params object[] args)
    {
            string str = String.Format(format, args);
            MainWindow.mainWindow.tbox_Log.AppendText(str+"\r\n");
            MainWindow.mainWindow.tbox_Log.ScrollToEnd();
    }
    public static void WriteTxt(string format, params object[] args)
    {
        string str = String.Format(format, args);
        MainWindow.mainWindow.tbox_1.AppendText(str + "\r\n");
        MainWindow.mainWindow.tbox_1.ScrollToEnd();

    }







}