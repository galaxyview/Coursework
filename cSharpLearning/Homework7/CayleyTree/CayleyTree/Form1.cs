using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayleyTree
{
    public partial class Form1 : Form
    {
        Color c = Color.Red;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           


            try
            {
                int n = int.Parse(textBox1.Text);
                double leng = double.Parse(textBox5.Text);
                double th1 = double.Parse(textBox2.Text) * Math.PI / 180;
                double th2 = double.Parse(textBox6.Text) * Math.PI / 180;
                double per1 = double.Parse(textBox4.Text);
                double per2 = double.Parse(textBox3.Text);
                if (graphics == null) graphics = pictureBox1.CreateGraphics();
                    drawCayleyTree(n, 200, 310, leng, -Math.PI / 2, th1, th2, per1, per2);
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private Graphics graphics;


        void drawCayleyTree(int n,double x0, double y0, double leng, double th,double th1,double th2,double per1,double per2)
        {
            if (n == 0) return;


            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1, th1, th2, per1, per2);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2, th1, th2, per1, per2);
        }
        void drawLine(double x0, double y0, double x1, double y1)
        {
            Pen pen = new Pen(c);
            graphics.DrawLine(pen,(int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            pictureBox1.Image = null;
            pictureBox1.Refresh();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            colorDialog1.ShowDialog();
            c = colorDialog1.Color;
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
