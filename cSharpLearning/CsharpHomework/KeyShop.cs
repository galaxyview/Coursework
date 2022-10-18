using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicTower
{
    public partial class KeyShop : Form
    {
        public KeyShop(Hero hero)
        {
            InitializeComponent();
            this.hero = hero;
            
        }

        Hero hero;
        private void timer1_Tick(object sender, EventArgs e)
        {
            int cursor_x = Cursor.Position.X - this.Location.X;
            int cursor_y = Cursor.Position.Y - this.Location.Y;
            int button_size_width = this.yellow_key.Size.Width;
            int button_size_height = this.yellow_key.Size.Height;
            if (cursor_x > yellow_key.Location.X && cursor_x < yellow_key.Location.X + button_size_width && cursor_y > 119 && cursor_y < 119 + button_size_height)
            {
                this.label2.Text = "用来打开黄色的门";
                this.label3.Text = "所持数量：" + hero.key[1].ToString();
                
            }
            else
            {
                if(cursor_x > blue_key.Location.X && cursor_x < blue_key.Location.X + button_size_width && cursor_y > 182 && cursor_y < 182 + button_size_height)
                {
                    this.label2.Text = "用来打开蓝色的门";
                    this.label3.Text = "所持数量：" + hero.key[2].ToString();
                }
                else
                {
                    if(cursor_x > blue_key.Location.X && cursor_x < blue_key.Location.X + button_size_width && cursor_y > 249 && cursor_y < 249 + button_size_height)
                    {
                        this.label2.Text = "用来打开红色的门";
                        this.label3.Text = "所持数量：" + hero.key[0].ToString();
                    }
                    else
                    {
                        this.label2.Text = "";
                        this.label3.Text = "";
                    }
                    
                }
                
                
            }
        }

        private void yellow_key_Click(object sender, EventArgs e)
        {
            if (this.hero.Money >= 10)
            {
                this.hero.Money -= 10;
                this.hero.key[1]++;
            }
            else
            {
                MessageBox.Show("金币不足！");
            }
            
        }

        private void blue_key_Click(object sender, EventArgs e)
        {
            if (this.hero.Money >= 50)
            {
                this.hero.Money -= 50;
                this.hero.key[2]++;
            }
            else
            {
                MessageBox.Show("金币不足！");
            }
        }

        private void red_key_Click(object sender, EventArgs e)
        {
            if (this.hero.Money >= 100)
            {
                this.hero.Money -= 100;
                this.hero.key[0]++;
            }
            else
            {
                MessageBox.Show("金币不足！");
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
