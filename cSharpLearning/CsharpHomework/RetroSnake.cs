using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace MagicTower
{
    public partial class RetroSnake : Form
    {
        public RetroSnake()
        {
            InitializeComponent();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            int InitialPosition = ran.Next(1, FormSize) * SnakeShape;
            for (int i = 0; i < 5; i++)
            {
                //身段
                Label Snake_Body_Content = new Label
                {
                    Height = SnakeShape,
                    Width = SnakeShape,
                    Top = InitialPosition,//蛇的位置
                    Left = InitialPosition - (i * SnakeShape),
                    BackColor = Color.Empty,//背景色
                    ForeColor = Color.Black,
                    Tag = i
                };

                //把创建的label对象加入到代表蛇身的数组当中
                SnakeBody[i] = Snake_Body_Content;
                panel1.Controls.Add(Snake_Body_Content);
            }
            for (int i = 1; i <= 4; i++)
            {
                Image image1 = (Image)rm.GetObject($"body");
                SnakeBody[i].Image = image1;
            }
            
        }

        private void RetroSnake_Load(object sender, EventArgs e)
        {
            
        }

        //为蛇的身体建立一个label数组，蛇的每一节身体为一个label对象
        Label[] SnakeBody = new Label[1000];
        //keyname的作用是记录上一次按键的值
        string KeyName = "Start";
        string KeyNameOld = "Start";
        int SnakeShape = 15;
        int FoodMax = 10;
        int Snake_Boby_content_x = 0, Snake_Boby_content_y = 0;
        int VictoryScore = 5;
        Random ran = new Random();
        System.Resources.ResourceManager rm = new System.Resources.ResourceManager(typeof(RetroSnake));
        int point = 0;
        int FormSize = 32;
        SoundPlayer sp = new SoundPlayer();

        private void Timer_Tick(object sender, EventArgs e)
        {
            int x, y;//记录Snake的Head的XY坐标
            x = SnakeBody[0].Left;
            y = SnakeBody[0].Top;
            if (KeyName == "Start")
            {
                SnakeBody[0].Left = x + SnakeShape;
                Image image1 = (Image)rm.GetObject($"right");
                SnakeBody[0].Image = image1;
                SnakeMove(x, y);
            }
            if (KeyName == "Right")
            {
                SnakeBody[0].Left = x + SnakeShape;
                SnakeMove(x, y);

            }
            if (KeyName == "Up")
            {
                SnakeBody[0].Top = y - SnakeShape;
                SnakeMove(x, y);
            }
            if (KeyName == "Left")
            {
                SnakeBody[0].Left = x - SnakeShape;
                SnakeMove(x, y);
            }
            if (KeyName == "Down")
            {
                SnakeBody[0].Top = y + SnakeShape;
                SnakeMove(x, y);
            }
            //穿墙设置
            if (x > 480)
            {
                SnakeBody[0].Left = 0;
            }
            if (y > 475)
            {

                SnakeBody[0].Top = 0;
            }
            if (x < 0)
            {

                SnakeBody[0].Left = 480;
            }
            if (y < 0)
            {

                SnakeBody[0].Top = 475;
            }
            Eat_time();
            CollitionDetect();
            GameLevel();
        }

        //随机生成食物
        public void Snake_food()
        {
            int i = 0;
            Image image1 = (Image)rm.GetObject($"grass");
            //获取地图上食物的总数，小于最大限制时，才可以添加食物。
            foreach (Label label in this.panel1.Controls)
            {
                if (label.Tag.ToString() == "Food".ToString())
                    i++;
            }
            if (i <= FoodMax)
            {

                Label Food = new Label
                {
                    Width = SnakeShape,
                    Height = SnakeShape,
                    Top = ran.Next(3, FormSize) * SnakeShape,
                    Left = ran.Next(3, FormSize) * SnakeShape,
                    Tag = "Food",
                    BackColor = Color.Empty,
                    ForeColor = Color.Black,
                    Image = image1
                };
                panel1.Controls.Add(Food);
            }
        }


        //将蛇头改变后的位置传入该函数，该函数会将蛇的身体按照规则进行移动。
        public void SnakeMove(int x, int y)
        {
            //记录XY中间变量
            int Temp_X = 0, Temp_Y = 0;

            //蛇身移动
            for (int i = 1; SnakeBody[i] != null; i++)
            {
                if (i >= 3)
                {
                    //将记录每个位置都给中间变量
                    Temp_X = Snake_Boby_content_x;
                    Temp_Y = Snake_Boby_content_y;
                }

                if (i == 1)
                {
                    Temp_X = SnakeBody[i].Left; //将改变前的位置记录 X
                    Temp_Y = SnakeBody[i].Top; //将改变前的位置记录 Y
                    SnakeBody[i].Left = x; //并且赋值给第一蛇段
                    SnakeBody[i].Top = y;//并且赋值给第一蛇段

                }
                else
                {
                    Snake_Boby_content_x = SnakeBody[i].Left; //记录蛇段的改变前的位置x
                    Snake_Boby_content_y = SnakeBody[i].Top;//记录蛇段的改变前的位置y

                    SnakeBody[i].Left = Temp_X; //temp_赋给第二-N个蛇段,
                    SnakeBody[i].Top = Temp_Y; //temp_赋给第二-N个蛇段,
                }
            }
        }

        public void Eat_time()
        {
            //蛇头部位置

            //取得食物的位置
            double x1 = 1, y1 = 1, x2 = 1, y2 = 1;
            foreach (Label label in this.panel1.Controls)
            {

                if (label.Tag.ToString() == "Food".ToString())
                { //食物

                    x2 = label.Left;
                    y2 = label.Top;
                }
                if (label.Tag.ToString() == "0".ToString())//Snake 
                {
                    x1 = label.Left;
                    y1 = label.Top;
                }

                if (x1 == x2 && y1 == y2)
                {
                    //吃掉食物 
                    Snake_Eat();
                    point++;
                    this.label2.Text = point.ToString();
                    if (point >= VictoryScore)
                    {
                        timer1.Enabled = false;
                        MessageBox.Show("胜利！");
                        Game game = (Game)this.Owner;
                        game.data_transport.Text = "1";
                        Close();
                    }
                    //将食物移位 更换坐标
                    foreach (Label lb in this.panel1.Controls)
                    {
                        if (lb.Tag.ToString() == "Food".ToString())
                        {
                            lb.Top = ran.Next(3, FormSize) * SnakeShape;
                            lb.Left = ran.Next(3, FormSize) * SnakeShape;
                        }
                    }
                    break;
                }
            }
        }

        //当蛇吃到食物的时候，删除原来的食物，并且将蛇段加长一
        public void Snake_Eat()
        {
            SoundEffect("GetKeySE");
            int i = 0;
            //遍历到蛇尾
            for (; SnakeBody[i] != null; i++) ;
            Label Snake_Boby_content = new Label
            {
                Width = SnakeShape,
                Height = SnakeShape,
                Top = Snake_Boby_content_x, //蛇尾位置X
                Left = Snake_Boby_content_y, //蛇尾位置Y
                BackColor = Color.Empty,
                Tag = i,
            };
            SnakeBody[i] = Snake_Boby_content;
            Image image1 = (Image)rm.GetObject($"body");
            SnakeBody[i].Image = image1;
            panel1.Controls.Add(Snake_Boby_content);
        }
        //检测蛇是否吃到了自己
        public void CollitionDetect()
        {
            double x1 = 1, y1 = 1, x2 = 1, y2 = 1;
            for (int i = 1; SnakeBody[i] != null; i++)
            {
                if (SnakeBody[i].Left == SnakeBody[0].Left && SnakeBody[i].Top == SnakeBody[0].Top)
                {
                    SoundEffect("GameFailSE");
                    timer1.Enabled = false;
                    MessageBox.Show("游戏失败，最终得分为：" + label2.Text);
                    Game game = (Game)this.Owner;
                    game.data_transport.Text = "0";
                    Close();
                    this.KeyPreview = false;
                }
            }

        }
        //蛇行走的速度会随着身体的长度逐渐加快
        public void GameLevel()
        {
            int level = (int)1000 / ((int)point / 2 + 1);
            timer1.Interval = level;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            //this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            
            timer1.Start();
            this.KeyPreview = true;
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            this.KeyPreview = false;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            int x, y;
            x = SnakeBody[0].Left;
            y = SnakeBody[0].Top;
            KeyNameOld = KeyName;
            KeyName = e.KeyCode.ToString();


            if ((KeyName == "Right" && KeyNameOld == "Left") || (KeyName == "Left" && KeyNameOld == "Right") || (KeyName == "Up" && KeyNameOld == "Down") || (KeyName == "Down" && KeyNameOld == "Up") || (KeyName == "Left" && KeyNameOld == "Start") || KeyName == KeyNameOld)
            {
                KeyName = KeyNameOld;
                return;
            }

            //获取键盘代码

            if (KeyName == "Right")
            {
                SnakeBody[0].Left = x + SnakeShape;
                Image image1 = (Image)rm.GetObject($"right");
                SnakeBody[0].Image = image1;
                SnakeMove(x, y);
            }
            if (KeyName == "Left")
            {
                SnakeBody[0].Left = x - SnakeShape;
                Image image1 = (Image)rm.GetObject($"left");
                SnakeBody[0].Image = image1;
                SnakeMove(x, y);

            }
            if (KeyName == "Up")
            {
                SnakeBody[0].Top = y - SnakeShape;
                Image image1 = (Image)rm.GetObject($"up");
                SnakeBody[0].Image = image1;
                SnakeMove(x, y);
            }
            if (KeyName == "Down")
            {
                SnakeBody[0].Top = y + SnakeShape;
                Image image1 = (Image)rm.GetObject($"down");
                SnakeBody[0].Image = image1;
                SnakeMove(x, y);
            }
            //每按一次，判断是否与食物重合
            Eat_time();
            GameLevel();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Snake_food();

            
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.Down ||

            keyData == Keys.Left || keyData == Keys.Right)

                return false;
            else
                return base.ProcessDialogKey(keyData);

        }


        private void SoundEffect(string s)
        {
            sp.SoundLocation = $"Audio\\SE\\{s}.wav";
            sp.Play();
        }


    }
}
