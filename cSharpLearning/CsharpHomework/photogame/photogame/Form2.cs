using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace photogame
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            PictureBox[] pic = new PictureBox[25];
            pic[0] = pictureBox1;
            pic[1] = pictureBox2;
            pic[2] = pictureBox3;
            pic[3] = pictureBox4;
            pic[4] = pictureBox5;
            pic[5] = pictureBox6;
            pic[6] = pictureBox7;
            pic[7] = pictureBox8;
            pic[8] = pictureBox9;
            pic[9] = pictureBox10;
            pic[10] = pictureBox11;
            pic[11] = pictureBox12;
            pic[12] = pictureBox13;
            pic[13] = pictureBox14;
            pic[14] = pictureBox15;
            pic[15] = pictureBox16;
            pic[16] = pictureBox17;
            pic[17] = pictureBox18;
            pic[18] = pictureBox19;
            pic[19] = pictureBox20;
            pic[20] = pictureBox21;
            pic[21] = pictureBox22;
            pic[22] = pictureBox23;
            pic[23] = pictureBox24;
            pic[24] = pictureBox25;

            for(int i=0;i<pic.Length;i++)
            {
                pic[i].Image = imageList1.Images[i];
            }

            Random r = new Random();
            for(int j=0;j<4;j++)
            {
                int[] n = new int[4];
                n[j] = r.Next(0, 24);
                pic[n[j]].Image = imageList1.Images[25];
            }
        }

     
        






    }
}
