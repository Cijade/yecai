using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using dmNet;

namespace yecai
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        DmScript sc0 = new DmScript();
        public static MainWindow mainWindow;
        public Thread t1;

        public MainWindow()
        {
           
            InitializeComponent();
            mainWindow = this;
            Log.WriteStr("大漠版本：" + sc0.Reg());
        }
        

        //绑定窗口
        private void Btn_1_Click(object sender, RoutedEventArgs e)
        {
                int hwnd = sc0.FindWindow();
                sc0.BindWindow(hwnd, 0);
            Log.WriteStr("绑定窗口结果："+ sc0.BindWindow(hwnd, 0));
        }

        private void Btn_1_1_Click(object sender, RoutedEventArgs e)
        {
            int hwnd = sc0.FindWindow();
            int x =sc0.BindWindow(hwnd, 1);
            Log.WriteStr("绑定窗口结果："+ x);
        }

        //挖矿任务
        private void Btn_2_Click(object sender, RoutedEventArgs e)
        {
            Log.WriteStr("自动每日任务开始");
            Log.WriteStr("请将界面置于主界面");
            sc0.Fishtasks();

        }

        //单地图挖矿
        private void Btn_3_Click(object sender, RoutedEventArgs e)
        {
            
            t1=new Thread(() => sc0.SingleMapMine());
            t1.Start();
            Log.WriteStr("单地图挖矿开始");

        }

        //开始钓鱼
        public string scripts;
        private void Btn_4_Click(object sender, RoutedEventArgs e)
        {
            t1 = new Thread(() => sc0.Fish());
            t1.Start();
            
            Log.WriteStr(scripts);
        }


        private void Btn_5_Click(object sender, RoutedEventArgs e)
        {

        }

        //单地图挂机
        private void Btn_guaji_Click(object sender, RoutedEventArgs e)
        {

            t1 = new Thread(() => sc0.SingleMapguaji());
            t1.Start();
            Log.WriteStr("单地图挂机开始");



        }



        private void Btn_Pause_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Stop_Click(object sender, RoutedEventArgs e)
        {
            sc0.scriptx = false;
            sc0.Stop();
        }

        private void Btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            sc0.Stop();
            System.Environment.Exit(0);
        }

        
    }
}
