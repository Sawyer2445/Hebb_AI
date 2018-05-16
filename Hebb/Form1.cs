using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hebb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Pen pen;
        Bitmap bmp;
        Web NW1;
        
        int sec;
        /// <summary>
        /// Painting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                using (Graphics gr = Graphics.FromImage(bmp))
                {
                    gr.DrawEllipse(pen, e.X, e.Y, 11, 11);
                }
                pictureBox1.Image = bmp;
            }
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            Brush brush = new SolidBrush(Color.Black);
            pen = new Pen(brush, 11);
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            for (int i = 0; i < pictureBox1.Width; i++)
            {
                for (int j = 0; j < pictureBox1.Height; j++)
                {
                    bmp.SetPixel(i, j, Color.White);
                }
            }
            pictureBox1.Image = bmp;
            NW1 = new Web(pictureBox1.Width, pictureBox1.Height);
        }

       

    
        private void button1_Click(object sender, EventArgs e)
        {
            int[,] inp = new int[pictureBox1.Width, pictureBox1.Height];
            for (int x = 0; x < pictureBox1.Width; x++)
            {
                for (int y = 0; y < pictureBox1.Height; y++)
                {
                    int n = (bmp.GetPixel(x, y).R);
                    if (n >= 250)
                        n = 0;
                    else
                        n = 1;
                    inp[x, y] = n;                 
                }
            }
            NW1.input = inp; 
              
            //Распознавание
            NW1.mul_w();
            NW1.Sum();
            if (NW1.Rez())
            {
                label2.Text = "ДА";
                label2.Visible = true;
            }
            else
            {
                label2.Text = "НЕТ";
                label2.Visible = true;
            }
            button1.Enabled = false;
            sec = 2;
            timer1.Start();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!NW1.Rez())
            {
                NW1.incW();
            }
            else
                NW1.decW();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < pictureBox1.Width; i++)
            {
                for (int j = 0; j < pictureBox1.Height; j++)
                {
                    bmp.SetPixel(i, j, Color.White);
                }
            }
            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NW1 = new Web(pictureBox1.Width, pictureBox1.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            --sec;
            if (sec < 0)
            {
                timer1.Stop();
                for (int i = 0; i < pictureBox1.Width; i++)
                {
                    for (int j = 0; j < pictureBox1.Height; j++)
                    {
                        bmp.SetPixel(i, j, Color.White);
                    }
                }
                pictureBox1.Image = bmp;
                label2.Text = "";
                button1.Enabled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
