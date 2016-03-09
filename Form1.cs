using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;


//TODO    延迟显示路径点
namespace maze_withGUI_
{
    public partial class Form1 : Form
    {
        int[,] a = new int[,] { { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }};

        int [,]route=new int[81,2];//route数组用来记录走过的路径信息
        int routei=0;


        //扫描周围一圈是否可走
        char scan(int x, int y)
        {
            if (a[x,y + 1] == 0) return 'r';
            if (a[x + 1,y] == 0) return 'd';
            if (a[x,y - 1] == 0) return 'l';
            if (a[x - 1,y] == 0) return 'u';
            return 'n';
        }

        void next(int x, int y)
        {
            //判断是否走到终点
            if (x == 8 && y == 8)
            {
                return;//如果到达终点直接返回1
            }

            if (a[x,y + 1] == 0)
            {//右
                //记录这一步的信息
                routei++;
                route[routei,0] = x;
                route[routei,1] = y + 1;
                a[x,y + 1] = 2;//把该格子标成2
                next(x, y + 1);//再继续走下一步
            }
            else if (a[x + 1,y] == 0)
            {//下
                routei++;
                route[routei,0] = x + 1;
                route[routei,1] = y;
                a[x + 1,y] = 2;
                next(x + 1, y);
            }
            else if (a[x,y - 1] == 0)
            {//左
                routei++;
                route[routei,0] = x;
                route[routei,1] = y - 1;
                a[x,y - 1] = 2;
                next(x, y - 1);
            }
            else if (a[x - 1,y] == 0)
            {//上
                routei++;
                route[routei,0] = x - 1;
                route[routei,1] = y;
                a[x - 1,y] = 2;
                next(x - 1, y);
            }
            else//无路可走
            {
                back();
            }
        }

        void back()
        {
            //routei倒退  直到周围有路可以走
            do
            {
                routei--;
            } while (scan(route[routei,0], route[routei,1]) == 'n');
            //继续往下走
            next(route[routei,0], route[routei,1]);
        }








        public Form1()
        {
            InitializeComponent();
        }


        //开始计算路线
        private void button1_Click(object sender, EventArgs e)
        {
            //初始化route
            route[0,0] = 1;
            route[0,1] = 1;

            //从1,1开始走
            a[1, 1] = 2;
            next(1, 1);

            //输出路径
            for (int i = 0; i <= routei; i++)
            {
                Thread.Sleep(500);
                ((Button)(this.Controls.Find("button" + route[i, 0] + route[i, 1], false)[0])).Text = "●";
                Application.DoEvents();
            }

        }


        private void clear_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    if ((i == 1 && j == 1) || (i == 8 && j == 8))
                    {
                        a[i, j] = 0;//清空a数组
                        ((Button)(this.Controls.Find("button" + i + j, false)[0])).Text = "";//清空按钮的文字
                    }
                    else
                    {
                        a[i, j] = 0;//清空a数组
                        ((Button)(this.Controls.Find("button" + i + j, false)[0])).Text = "";//清空按钮的文字
                        ((Button)(this.Controls.Find("button" + i + j, false)[0])).BackColor = Color.Gainsboro;//清空颜色
                    }
                }
            }
            routei = 0;//清空route
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <=9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    if (i == 0 || i == 9 || j == 0 || j == 9)
                    {
                        //墙
                        a[i, j] = 1;
                        ((Button)(this.Controls.Find("button" + i + j, false)[0])).BackColor = Color.Maroon;
                    }
                    else
                    {
                        ((Button)(this.Controls.Find("button" + i + j, false)[0])).BackColor = Color.Gainsboro;//初始化颜色
                    }
                }
            }

            //初始化起点和终点
            ((Button)(this.Controls.Find("button11",false)[0])).BackColor = Color.Yellow;
            ((Button)(this.Controls.Find("button88", false)[0])).BackColor = Color.LawnGreen;
        }


        private void button00_Click(object sender, EventArgs e)
        {
            button00.BackColor = Color.Maroon; a[0, 0] = 1;
        }

        private void button01_Click(object sender, EventArgs e)
        {
            button01.BackColor = Color.Maroon; a[0, 1] = 1;
        }

        private void button02_Click(object sender, EventArgs e)
        {
            button02.BackColor = Color.Maroon; a[0, 2] = 1;
        }

        private void button03_Click(object sender, EventArgs e)
        {
            button03.BackColor = Color.Maroon; a[0, 3] = 1;
        }

        private void button04_Click(object sender, EventArgs e)
        {
            button04.BackColor = Color.Maroon; a[0, 4] = 1;
        }

        private void button05_Click(object sender, EventArgs e)
        {
            button05.BackColor = Color.Maroon; a[0, 5] = 1;
        }

        private void button06_Click(object sender, EventArgs e)
        {
            button06.BackColor = Color.Maroon; a[0, 6] = 1;
        }

        private void button07_Click(object sender, EventArgs e)
        {
            button07.BackColor = Color.Maroon; a[0, 7] = 1;
        }

        private void button08_Click(object sender, EventArgs e)
        {
            button08.BackColor = Color.Maroon; a[0, 8] = 1;
        }

        private void button09_Click(object sender, EventArgs e)
        {
            button09.BackColor = Color.Maroon; a[0, 9] = 1;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button10.BackColor = Color.Maroon; a[1, 0] = 1;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button11.BackColor = Color.Maroon; a[1, 1] = 1;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button12.BackColor = Color.Maroon; a[1, 2] = 1;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            button13.BackColor = Color.Maroon; a[1, 3] = 1;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            button14.BackColor = Color.Maroon; a[1, 4] = 1;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            button15.BackColor = Color.Maroon; a[1, 5] = 1;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            button16.BackColor = Color.Maroon; a[1, 6] = 1;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            button17.BackColor = Color.Maroon; a[1, 7] = 1;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            button18.BackColor = Color.Maroon; a[1, 8] = 1;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            button19.BackColor = Color.Maroon; a[1, 9] = 1;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            button20.BackColor = Color.Maroon; a[2, 0] = 1;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            button21.BackColor = Color.Maroon; a[2, 1] = 1;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            button22.BackColor = Color.Maroon; a[2, 2] = 1;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            button23.BackColor = Color.Maroon; a[2, 3] = 1;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            button24.BackColor = Color.Maroon; a[2, 4] = 1;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            button25.BackColor = Color.Maroon; a[2, 5] = 1;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            button26.BackColor = Color.Maroon; a[2, 6] = 1;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            button27.BackColor = Color.Maroon; a[2, 7] = 1;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            button28.BackColor = Color.Maroon; a[2, 8] = 1;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            button29.BackColor = Color.Maroon; a[2, 9] = 1;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            button30.BackColor = Color.Maroon; a[3, 0] = 1;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            button31.BackColor = Color.Maroon; a[3, 1] = 1;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            button32.BackColor = Color.Maroon; a[3, 2] = 1;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            button33.BackColor = Color.Maroon; a[3, 3] = 1;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            button34.BackColor = Color.Maroon; a[3, 4] = 1;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            button35.BackColor = Color.Maroon; a[3, 5] = 1;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            button36.BackColor = Color.Maroon; a[3, 6] = 1;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            button37.BackColor = Color.Maroon; a[3, 7] = 1;
        }

        private void button38_Click(object sender, EventArgs e)
        {
            button38.BackColor = Color.Maroon; a[3, 8] = 1;
        }

        private void button39_Click(object sender, EventArgs e)
        {
            button39.BackColor = Color.Maroon; a[3, 9] = 1;
        }

        private void button40_Click(object sender, EventArgs e)
        {
            button40.BackColor = Color.Maroon; a[4, 0] = 1;
        }

        private void button41_Click(object sender, EventArgs e)
        {
            button41.BackColor = Color.Maroon; a[4, 1] = 1;
        }

        private void button42_Click(object sender, EventArgs e)
        {
            button42.BackColor = Color.Maroon; a[4, 2] = 1;
        }

        private void button43_Click(object sender, EventArgs e)
        {
            button43.BackColor = Color.Maroon; a[4, 3] = 1;
        }

        private void button44_Click(object sender, EventArgs e)
        {
            button44.BackColor = Color.Maroon; a[4, 4] = 1;
        }

        private void button45_Click(object sender, EventArgs e)
        {
            button45.BackColor = Color.Maroon; a[4, 5] = 1;
        }

        private void button46_Click(object sender, EventArgs e)
        {
            button46.BackColor = Color.Maroon; a[4, 6] = 1;
        }

        private void button47_Click(object sender, EventArgs e)
        {
            button47.BackColor = Color.Maroon; a[4, 7] = 1;
        }

        private void button48_Click(object sender, EventArgs e)
        {
            button48.BackColor = Color.Maroon; a[4, 8] = 1;
        }

        private void button49_Click(object sender, EventArgs e)
        {
            button49.BackColor = Color.Maroon; a[4, 9] = 1;
        }

        private void button50_Click(object sender, EventArgs e)
        {
            button50.BackColor = Color.Maroon; a[5, 0] = 1;
        }

        private void button51_Click(object sender, EventArgs e)
        {
            button51.BackColor = Color.Maroon; a[5, 1] = 1;
        }

        private void button52_Click(object sender, EventArgs e)
        {
            button52.BackColor = Color.Maroon; a[5, 2] = 1;
        }

        private void button53_Click(object sender, EventArgs e)
        {
            button53.BackColor = Color.Maroon; a[5, 3] = 1;
        }

        private void button54_Click(object sender, EventArgs e)
        {
            button54.BackColor = Color.Maroon; a[5, 4] = 1;
        }

        private void button55_Click(object sender, EventArgs e)
        {
            button55.BackColor = Color.Maroon; a[5, 5] = 1;
        }

        private void button56_Click(object sender, EventArgs e)
        {
            button56.BackColor = Color.Maroon; a[5, 6] = 1;
        }

        private void button57_Click(object sender, EventArgs e)
        {
            button57.BackColor = Color.Maroon; a[5, 7] = 1;
        }

        private void button58_Click(object sender, EventArgs e)
        {
            button58.BackColor = Color.Maroon; a[5, 8] = 1;
        }

        private void button59_Click(object sender, EventArgs e)
        {
            button59.BackColor = Color.Maroon; a[5, 9] = 1;
        }

        private void button60_Click(object sender, EventArgs e)
        {
            button60.BackColor = Color.Maroon; a[6, 0] = 1;
        }

        private void button61_Click(object sender, EventArgs e)
        {
            button61.BackColor = Color.Maroon; a[6, 1] = 1;
        }

        private void button62_Click(object sender, EventArgs e)
        {
            button62.BackColor = Color.Maroon; a[6, 2] = 1;
        }

        private void button63_Click(object sender, EventArgs e)
        {
            button63.BackColor = Color.Maroon; a[6, 3] = 1;
        }

        private void button64_Click(object sender, EventArgs e)
        {
            button64.BackColor = Color.Maroon; a[6, 4] = 1;
        }

        private void button65_Click(object sender, EventArgs e)
        {
            button65.BackColor = Color.Maroon; a[6, 5] = 1;
        }

        private void button66_Click(object sender, EventArgs e)
        {
            button66.BackColor = Color.Maroon; a[6, 6] = 1;
        }

        private void button67_Click(object sender, EventArgs e)
        {
            button67.BackColor = Color.Maroon; a[6, 7] = 1;
        }

        private void button68_Click(object sender, EventArgs e)
        {
            button68.BackColor = Color.Maroon; a[6, 8] = 1;
        }

        private void button69_Click(object sender, EventArgs e)
        {
            button69.BackColor = Color.Maroon; a[6, 9] = 1;
        }

        private void button70_Click(object sender, EventArgs e)
        {
            button70.BackColor = Color.Maroon; a[7, 0] = 1;
        }

        private void button71_Click(object sender, EventArgs e)
        {
            button71.BackColor = Color.Maroon; a[7, 1] = 1;
        }

        private void button72_Click(object sender, EventArgs e)
        {
            button72.BackColor = Color.Maroon; a[7, 2] = 1;
        }

        private void button73_Click(object sender, EventArgs e)
        {
            button73.BackColor = Color.Maroon; a[7, 3] = 1;
        }

        private void button74_Click(object sender, EventArgs e)
        {
            button74.BackColor = Color.Maroon; a[7, 4] = 1;
        }

        private void button75_Click(object sender, EventArgs e)
        {
            button75.BackColor = Color.Maroon; a[7, 5] = 1;
        }

        private void button76_Click(object sender, EventArgs e)
        {
            button76.BackColor = Color.Maroon; a[7, 6] = 1;
        }

        private void button77_Click(object sender, EventArgs e)
        {
            button77.BackColor = Color.Maroon; a[7, 7] = 1;
        }

        private void button78_Click(object sender, EventArgs e)
        {
            button78.BackColor = Color.Maroon; a[7, 8] = 1;
        }

        private void button79_Click(object sender, EventArgs e)
        {
            button79.BackColor = Color.Maroon; a[7, 9] = 1;
        }

        private void button80_Click(object sender, EventArgs e)
        {
            button80.BackColor = Color.Maroon; a[8, 0] = 1;
        }

        private void button81_Click(object sender, EventArgs e)
        {
            button81.BackColor = Color.Maroon; a[8, 1] = 1;
        }

        private void button82_Click(object sender, EventArgs e)
        {
            button82.BackColor = Color.Maroon; a[8, 2] = 1;
        }

        private void button83_Click(object sender, EventArgs e)
        {
            button83.BackColor = Color.Maroon; a[8, 3] = 1;
        }

        private void button84_Click(object sender, EventArgs e)
        {
            button84.BackColor = Color.Maroon; a[8, 4] = 1;
        }

        private void button85_Click(object sender, EventArgs e)
        {
            button85.BackColor = Color.Maroon; a[8, 5] = 1;
        }

        private void button86_Click(object sender, EventArgs e)
        {
            button86.BackColor = Color.Maroon; a[8, 6] = 1;
        }

        private void button87_Click(object sender, EventArgs e)
        {
            button87.BackColor = Color.Maroon; a[8, 7] = 1;
        }

        private void button88_Click(object sender, EventArgs e)
        {
            button88.BackColor = Color.Maroon; a[8, 8] = 1;
        }

        private void button89_Click(object sender, EventArgs e)
        {
            button89.BackColor = Color.Maroon; a[8, 9] = 1;
        }

        private void button90_Click(object sender, EventArgs e)
        {
            button90.BackColor = Color.Maroon; a[9, 0] = 1;
        }

        private void button91_Click(object sender, EventArgs e)
        {
            button91.BackColor = Color.Maroon; a[9, 1] = 1;
        }

        private void button92_Click(object sender, EventArgs e)
        {
            button92.BackColor = Color.Maroon; a[9, 2] = 1;
        }

        private void button93_Click(object sender, EventArgs e)
        {
            button93.BackColor = Color.Maroon; a[9, 3] = 1;
        }

        private void button94_Click(object sender, EventArgs e)
        {
            button94.BackColor = Color.Maroon; a[9, 4] = 1;
        }

        private void button95_Click(object sender, EventArgs e)
        {
            button95.BackColor = Color.Maroon; a[9, 5] = 1;
        }

        private void button96_Click(object sender, EventArgs e)
        {
            button96.BackColor = Color.Maroon; a[9, 6] = 1;
        }

        private void button97_Click(object sender, EventArgs e)
        {
            button97.BackColor = Color.Maroon; a[9, 7] = 1;
        }

        private void button98_Click(object sender, EventArgs e)
        {
            button98.BackColor = Color.Maroon; a[9, 8] = 1;
        }

        private void button99_Click(object sender, EventArgs e)
        {
            button99.BackColor = Color.Maroon; a[9, 9] = 1;
        }

    }
}
