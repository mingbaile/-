using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyGame
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[,] data;
        ucItem[,] items;
        Point curPoint;
        int curlvl = 0;
        int step = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            button3.Enabled = curlvl > 0;
            button4.Enabled = curlvl < Config.Levels.Length - 1;
            //Controls.Clear();
            lblLvl.Text = string.Format("{0:000}", curlvl+1);
            step=0;
            lblStep.Text = string.Format("{0:000}", step);
            data = new int[16, 16];
            if(items==null)
                items = new ucItem[16, 16];
            string[] lvl = Config.Levels[curlvl].Split(",".ToCharArray());
            for (int i = 0; i < lvl.Length; i++)
            {
                string tmp = lvl[i];
                for (int j = 0; j < tmp.Length; j++)
                {
                    ucItem item=null;
                    if (items[i, j] == null)
                    {
                        item = new ucItem();
                        items[i, j] = item;
                    }
                    else
                    {
                        item = items[i, j];
                    }
                    data[i, j] = int.Parse(tmp[j].ToString());                    
                    
                    item.Tag = data[i, j].ToString();
                    item.OldValue = data[i, j];
                    item.Left = j * item.Width + 5;
                    item.Top = i* item.Height + 5;
                    this.Controls.Add(item);
                    item.RefImage();
                    if (data[i, j] >= 6)
                    {
                        curPoint = new Point();
                        curPoint.Y = i;
                        curPoint.X = j;
                    }
                }
            }
            ShowInfo();
            textBox1.Focus();
        }

        private void ShowInfo()
        {
            textBox1.Text = "x:" + curPoint.X + ",y:" + curPoint.Y;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Point newPoint1=curPoint;
            Point newPoint2 = curPoint;
            int key = e.KeyValue;
            switch (key)
            {
                case 38://上
                    newPoint1.Y--;
                    newPoint2.Y -= 2;
                    data[curPoint.Y, curPoint.X] = 6;
                    GoNewPoint(newPoint1,newPoint2);
                    break;
                case 39://右
                    newPoint1.X++;
                    newPoint2.X+=2;
                    data[curPoint.Y, curPoint.X] = 9;
                    GoNewPoint(newPoint1,newPoint2);
                    break;
                case 40://下
                    newPoint1.Y++;
                    newPoint2.Y+=2;
                    data[curPoint.Y, curPoint.X] = 7;
                    GoNewPoint(newPoint1, newPoint2);
                    break;
                case 37://左
                    newPoint1.X--;
                    newPoint2.X-=2;
                    data[curPoint.Y, curPoint.X] = 8;
                    GoNewPoint(newPoint1, newPoint2);
                    break;
            }

            ShowInfo();
        }

        private void GoNewPoint(Point newPoint1,Point newPoint2)
        {
            step++;
            lblStep.Text = string.Format("{0:000}", step);
            bool isFinshed=false;
            if(newPoint1.X<0||newPoint1.Y<0) return;
            int n1 = data[newPoint1.Y, newPoint1.X];
            int n2 = data[newPoint2.Y, newPoint2.X];
            if (n1 <= 1) return;
            if (n1 == 2||n1==3)
            {
                data[newPoint1.Y, newPoint1.X] = data[curPoint.Y, curPoint.X];
                RefImg(newPoint1);
                data[curPoint.Y, curPoint.X] = items[curPoint.Y, curPoint.X].OldValue;
                RefImg(curPoint);
                curPoint = newPoint1;
                return;
            }
            if (n1 == 5)
            {
               
                if (n2 == 1 || n2 == 5) return;
                if (n2 == 2)
                {
                    data[newPoint2.Y, newPoint2.X] = 5;
                }
                if (n2 == 3)
                {
                    data[newPoint2.Y, newPoint2.X] = 4;
                    isFinshed = true;
                }
                RefImg(newPoint2);
                data[newPoint1.Y, newPoint1.X] = data[curPoint.Y, curPoint.X];
                RefImg(newPoint1);
                data[curPoint.Y, curPoint.X] = items[curPoint.Y, curPoint.X].OldValue;
                RefImg(curPoint);
                curPoint = newPoint1;
                CheckFinshed();
            }

            if (n1 == 4)
            {
                if (n2 == 2 || n2 == 3)
                {
                    if (n2 == 2)
                    {
                        data[newPoint2.Y, newPoint2.X] = 5;
                    }
                    if (n2 == 3)
                    {
                        data[newPoint2.Y, newPoint2.X] = 4;                 
                    }

                    RefImg(newPoint2);
                    data[newPoint1.Y, newPoint1.X] = data[curPoint.Y, curPoint.X];
                    RefImg(newPoint1);
                    data[curPoint.Y, curPoint.X] = items[curPoint.Y, curPoint.X].OldValue;
                    RefImg(curPoint);
                    curPoint = newPoint1;
                    CheckFinshed();
                }
            }
            
        }

        private void CheckFinshed()
        {
            
            for (int i = 0; i < items.GetUpperBound(0); i++)
            {
                for (int j = 0; j < items.GetUpperBound(1); j++)
                {
                    if (data[i,j]==5)
                    {
                        return;
                    }
                }
            }
            MessageBox.Show("nice");
            curlvl++;
            if (curlvl >= Config.Levels.Length)
            {
                MessageBox.Show("通关!");
                return;
            }
            Form1_Load(null, null);
        }
        void RefImg(Point p)
        {
            items[p.Y, p.X].Tag = data[p.Y, p.X];
            items[p.Y, p.X].RefImage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            curlvl = 0;
            Form1_Load(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1_Load(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (curlvl > 0)
            {
                curlvl--;
                Form1_Load(null, null);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (curlvl <Config.Levels.Length)
            {
                curlvl++;
                Form1_Load(null, null);
            }
        }
    }
}
