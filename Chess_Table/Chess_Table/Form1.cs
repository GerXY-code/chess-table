using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Table
{
    public partial class Form1 : Form
    {
        Graphics g;
        SolidBrush b;
        SolidBrush b2;
        public Form1()
        {
            InitializeComponent();

        }
       
       
        public void DrawFromTop(float x, float y, float width, float heigth)
        {
            
            bool nextLine = false;
            y = canvas.Top;
           
                for (int i = 0; i < 4; i++)
                {

                    for (int j = 0; j < 8; j++)
                    {
                        if (nextLine)
                        {
                            if (j % 2 == 0)
                            {
                                b = new SolidBrush(Color.White);
                            }
                            else
                            {
                                b = new SolidBrush(Color.Black);
                            }

                        }
                        if (!(nextLine))
                        {
                            if (!(j % 2 == 0))
                            {
                                b = new SolidBrush(Color.White);
                            }
                            else
                            {
                                b = new SolidBrush(Color.Black);
                            }

                        }

                        g = canvas.CreateGraphics();
                        x += 50;
                        g.FillRectangle(b, x, y, width, heigth);
                        Thread.Sleep(50);
                       


                    }
                    if (nextLine)
                    {
                        nextLine = false;
                    }
                    else
                    {
                        nextLine = true;
                    }

                    y += width;
                    x -= 8 * 50;
                }

            


        }

        public void DrawFromBottom(float x2,float y2,float width2,float heigth2)
        {
            bool nextLine = false;
            y2 -= canvas.Top-8*50;
            for (int i = 0; i < 4; i++)
            {

                for (int j = 0; j < 8; j++)
                {
                    if (nextLine)
                    {
                        if (j % 2 == 0)
                        {
                            b2 = new SolidBrush(Color.Black);
                        }
                        else
                        {
                            b2 = new SolidBrush(Color.White);
                        }

                    }
                    if (!(nextLine))
                    {
                        if (!(j % 2 == 0))
                        {
                            b2 = new SolidBrush(Color.Black);
                        }
                        else
                        {
                            b2 = new SolidBrush(Color.White);
                        }

                    }

                    g = canvas.CreateGraphics();

                    x2 += 50;
                    g.FillRectangle(b2, x2, y2, width2, heigth2);
                    Thread.Sleep(50);
                  


                }
                if (nextLine)
                {
                    nextLine = false;
                }
                else
                {
                    nextLine = true;
                }

                y2 -= width2;
                x2 -= 8 * 50;
            }

        }


        private void startBtn_Click(object sender, EventArgs e)
        {

            float x=0;
            float y=0;
            float width = 50;
            float heigth = 50;
            float x2 = 0;
            float y2 = 0;
            float width2 = 50;
            float heigth2 = 50;
            Thread t1 = new Thread(() => DrawFromTop(x, y, width, heigth));
            Thread t2 = new Thread(() => DrawFromBottom(x2, y2, width2, heigth2));
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
           
        }
    }
}
