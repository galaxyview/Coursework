using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;
using MagicTower;

namespace photogame
{
    public partial class PhotoGame : Form
    {
        List<PictureBox> picList = new List<PictureBox>();
        int[] index = new int[25];
        SoundPlayer sp = new SoundPlayer();
        
        public PhotoGame()
        {
            InitializeComponent();
            
            
            foreach(Control obj in this.Controls)
            {
                if(obj is PictureBox)
                {
                    PictureBox pic = (PictureBox)obj;
                    picList.Add(pic);

                }               
            }

            for (int i = 0; i < picList.Count; i++)
            {
                picList[i].Image = imageList1.Images[24-i];
                index[i] = 1;
            }

            Random r = new Random();
            
            for (int j = 0; j < 179; j++)
            {
                int[] n = new int[179];
                n[j] = r.Next(1, 11);

                int buttonclicked = n[j];
                switch(buttonclicked)
                {
                    case 1:
                        L6();
                        break;
                    case 2:
                        L7();
                        break;
                    case 3:
                        L8();
                        break;
                    case 4:
                        L9();
                        break;
                    case 5:
                        L10();
                        break;
                    case 6:
                        UL11();
                        break;
                    case 7:
                        U1();
                        break;
                    case 8:
                        U2();
                        break;
                    case 9:
                        U3();
                        break;
                    case 10:
                        U4();
                        break;
                    case 11:
                        U5();
                        break;           
                } 
            }

        }
      
        int sum = 0;

        private void U1()
        {
            for (int i = 0; i < 5; i++)
            {
                if (index[5 * i + 4] == 0)
                {
                    picList[5 * i + 4].Image = imageList1.Images[20 - 5 * i];
                    index[5 * i + 4] = 1;
                }
                else
                {
                    picList[5 * i + 4].Image = imageList1.Images[25];
                    index[5 * i + 4] = 0;
                }
            }
        }

        private void U2()
        {
            for (int i = 0; i < 5; i++)
            {
                if (index[5 * i + 3] == 0)
                {
                    picList[5 * i + 3].Image = imageList1.Images[21 - 5 * i];
                    index[5 * i + 3] = 1;
                }
                else
                {
                    picList[5 * i + 3].Image = imageList1.Images[25];
                    index[5 * i + 3] = 0;
                }
            }
        }

        private void U3()
        {
            for (int i = 0; i < 5; i++)
            {
                if (index[5 * i + 2] == 0)
                {
                    picList[5 * i + 2].Image = imageList1.Images[22 - 5 * i];
                    index[5 * i + 2] = 1;
                }
                else
                {
                    picList[5 * i + 2].Image = imageList1.Images[25];
                    index[5 * i + 2] = 0;
                }
            }
        }

        private void U4()
        {
            for (int i = 0; i < 5; i++)
            {
                if (index[5 * i + 1] == 0)
                {
                    picList[5 * i + 1].Image = imageList1.Images[23 - 5 * i];
                    index[5 * i + 1] = 1;
                }
                else
                {
                    picList[5 * i + 1].Image = imageList1.Images[25];
                    index[5 * i + 1] = 0;
                }
            }
        }

        private void U5()
        {
            for (int i = 0; i < 5; i++)
            {
                if (index[5 * i] == 0)
                {
                    picList[5 * i].Image = imageList1.Images[24 - 5 * i];
                    index[5 * i] = 1;
                }
                else
                {
                    picList[5 * i].Image = imageList1.Images[25];
                    index[5 * i] = 0;
                }
            }
        }

        private void L6()
        {
            for (int i = 20; i < 25; i++)
            {
                if (index[i] == 0)
                {
                    picList[i].Image = imageList1.Images[24 - i];
                    index[i] = 1;
                }
                else
                {
                    picList[i].Image = imageList1.Images[25];
                    index[i] = 0;
                }
            }
        }

        private void L7()
        {
            for (int i = 15; i < 20; i++)
            {
                if (index[i] == 0)
                {
                    picList[i].Image = imageList1.Images[24 - i];
                    index[i] = 1;
                }
                else
                {
                    picList[i].Image = imageList1.Images[25];
                    index[i] = 0;
                }

            }
        }

        private void L8()
        {
            for (int i = 10; i < 15; i++)
            {
                if (index[i] == 0)
                {
                    picList[i].Image = imageList1.Images[24 - i];
                    index[i] = 1;
                }
                else
                {
                    picList[i].Image = imageList1.Images[25];
                    index[i] = 0;
                }
            }
        }

        private void L9()
        {
            for (int i = 5; i < 10; i++)
            {
                if (index[i] == 0)
                {
                    picList[i].Image = imageList1.Images[24 - i];
                    index[i] = 1;
                }
                else
                {
                    picList[i].Image = imageList1.Images[25];
                    index[i] = 0;
                }
            }
        }

        private void L10()
        {
            for (int i = 0; i < 5; i++)
            {
                if (index[i] == 0)
                {
                    picList[i].Image = imageList1.Images[24 - i];
                    index[i] = 1;
                }
                else
                {
                    picList[i].Image = imageList1.Images[25];
                    index[i] = 0;
                }
            }
        }

        private void UL11()
        {
            for (int i = 0; i < 5; i++)
            {
                if (index[6 * i] == 0)
                {
                    picList[6 * i].Image = imageList1.Images[24 - 6 * i];
                    index[6 * i] = 1;
                }
                else
                {
                    picList[6 * i].Image = imageList1.Images[25];
                    index[6 * i] = 0;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SoundEffect("GetKeySE");
            U1();
            sum++;
            textBox1.Text = sum.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoundEffect("GetKeySE");
            U2();
            sum++;
            textBox1.Text = sum.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SoundEffect("GetKeySE");
            U3();
            sum++;
            textBox1.Text = sum.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SoundEffect("GetKeySE");
            U4();
            sum++;
            textBox1.Text = sum.ToString();
        }
 
        private void button5_Click(object sender, EventArgs e)
        {
            SoundEffect("GetKeySE");
            U5();
            sum++;
            textBox1.Text = sum.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SoundEffect("GetKeySE");
            L6();
            sum++;
            textBox1.Text = sum.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SoundEffect("GetKeySE");
            L7();
            sum++;
            textBox1.Text = sum.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SoundEffect("GetKeySE");
            L8();
            sum++;
            textBox1.Text = sum.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SoundEffect("GetKeySE");
            L9();
            sum++;
            textBox1.Text = sum.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SoundEffect("GetKeySE");
            L10();
            sum++;
            textBox1.Text = sum.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SoundEffect("GetKeySE");
            UL11();
            sum++;
            textBox1.Text = sum.ToString();
        }

       
        private void button12_Click(object sender, EventArgs e)  //退出游戏
        {

        }

        private void button13_Click(object sender, EventArgs e)   //检验成果
        {
            bool flag = true;
            for (int k = 0; k < picList.Count; k++)
            {
                if (index[k] == 0)
                {
                    flag = false;
                }
            }

            if (flag == true)
            {
                SoundEffect("GetSwordSE");
                MessageBox.Show("恭喜你成功通关！", "检验信息");
                Game game = (Game)this.Owner;
                game.data_transport.Text = "1";
                Close();
            }
            else
            {
                SoundEffect("GameFailSE");
                MessageBox.Show("请继续加油！", "检验信息");
                Game game = (Game)this.Owner;
                game.data_transport.Text = "0";
                Close();
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void SoundEffect(string s)
        {
            sp.SoundLocation = $"Audio\\SE\\{s}.wav";
            sp.Play();
        }
    }
}
