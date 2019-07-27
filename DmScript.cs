using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using dmNet;

namespace yecai
{
    class DmScript
    {
        private dmsoft dm;
        public DmScript()
        {

        }
        public bool scriptx;//线程停止记号
        string path0;
        string texturepath;
      
        //收费注册
        public string Reg()
        {
            dm = new dmsoft();
            dm.Reg("qq52520aef84a07ae6964b44871ce634c6f507", "yecai");
            
            path0 = System.IO.Directory.GetCurrentDirectory();
            //texturepath = path0+"\texture";
            dm.SetPath(path0);
            return dm.Ver();
        }

        public int FindWindow()
        {
            int hwnd = dm.FindWindow("UnityWndClass", "Ant野菜部落2019 v5.0.1 - ");
            return hwnd;
        }

        public int BindWindow(int hwnd,int mode)
        {
            dm.SetWindowState(hwnd, 1);
            if (mode == 0)
            {
               return dm.BindWindow(hwnd, "gdi", "normal", "normal", 0);
            }
            else
            {
               return dm.BindWindow(hwnd, "gdi", "dx", "dx", 0);
                
            }
        }


        //单地图挖矿
        public void SingleMapMine()
        {
            scriptx = true;
            while (scriptx)
            {
                for (int a = 0; a < 400; a = a + 1)
                {
                    for (int j = 0; j < 3; j = j + 1)
                    {
                        int x = 300;
                        dm.MoveTo((x + a * 15) % 1000, 450 + 50 * j);//
                        dm.LeftClick();
                        dm.delay(190);
                        dm.MoveTo(900, 350);
                        dm.RightClick();
                        dm.delay(6000);
                    }
                }
            }
        }

        public void Fishtasks()
        {
            //进入区域2


            
            for (int a = 0; a < 7; a = a + 1)
            {
                for (int j = 0; j < 3; j = j + 1)
                {
                    int x = 300;
                    dm.MoveTo((x + a * 15) % 1000, 450 + 50 * j);//
                    dm.LeftClick();
                    dm.delay(190);
                    dm.MoveTo(900, 350);
                    dm.RightClick();
                    dm.delay(6000);
                }
            }





            /* 主界面进入七星堂
             * 点击老头接去每日任务
             * （钓鱼挖矿）
             * 创建矿坑房间
             * 移动房间挖矿
             * 判断挖矿次数
             * 退出房间创建钓鱼房间 创建房间可以写方法
             * 开始钓鱼
             */
        }

        public void Fish()
        {
            scriptx = true;
            dm.MoveTo(320, 570);
            dm.LeftClick();
            dm.delay(400);
            dm.MoveTo(120, 173);
            dm.delay(20);
            dm.LeftClick();
            dm.delay(100);
            while (scriptx)
            {
                if (dm.CmpColor(402, 469, "ffffff", 1) == 0)//如果进度条没出现就抬起
                {
                    if (dm.CmpColor(402, 517, "04c76e", 1) == 0)//通过中间颜色判断上下
                    {
                        while (dm.CmpColor(402, 469, "ffffff", 1) == 0)
                        {
                            dm.KeyDown(38);//38上 40下
                            if (dm.CmpColor(402, 499, "ffffff", 1) == 1)
                            {
                                dm.KeyUp(38);
                                dm.delay(100);
                            }
                        }
                        dm.KeyUp(38);
                    }
                    else
                    {
                        while (dm.CmpColor(402, 469, "ffffff", 1) == 0)
                        {
                            dm.KeyDown(40);
                            if (dm.CmpColor(402, 533, "ffffff", 1) == 0)
                            {
                                dm.KeyUp(40);
                                dm.delay(100);
                            }
                        }
                        dm.KeyUp(40);
                    }
                }
            }
        }

        public void SingleMapguaji()
        {
            scriptx = true;

            int x =0;int y=0;
            //识别地图，SingleMapguaji传递地图参数
            while (scriptx)
            {
                int ret = dm.FindPic(0, 200, 1279, 902, "草莓.bmp|栗子.bmp|露水.bmp|铁皮.bmp|酒瓶.bmp|垃圾桶.bmp|方便面袋.bmp|鼻涕纸.bmp|鞋子.bmp|炒锅.bmp|易拉罐.bmp|破碗.bmp|破礼帽.bmp|破锅.bmp|苹果核.bmp|农药瓶.bmp|帽子.bmp|轮胎.bmp", "000000", 0.7, 0, out x, out y);//
                if (ret != -1)
                {
                    //Log.WriteTxt("发现食物垃圾");
                    dm.MoveTo(x + 14, y + 14);
                    dm.LeftClick();
                }
                dm.delay(4000);
                //Log.WriteTxt("返回值="+ret);
                //Log.WriteTxt("检查运行中");
            }
            //Log.WriteTxt("exit");
        }

        public void Jishi()
        {
            //计时
            //DispatcherTimer timer = new DispatcherTimer();//创建timer定时器
            //timer.Interval = TimeSpan.FromMilliseconds(10000);//设置周期为10000毫秒10秒
            //timer.Tick += new EventHandler(SingleMapguaji);
        }


        public void Stop()
        {
            dm.UnBindWindow();

        }

    }
}
