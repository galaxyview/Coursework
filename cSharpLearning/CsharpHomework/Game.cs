using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using photogame;

namespace MagicTower
{
    enum img { wallY = 160, floor = 168, doorY = 156, keyY = 143, doorB = 157,keyB = 144, keyR = 145, doorR = 158, down = 162, up = 163, hero1 = 66, 
        swordSolderR = 44, swordSolderB = 42, gemB = 124, gemR = 123, wallW = 155, wallB = 156, gateBar = 159, npc1 = 98, npc2 = 108, bottleB = 134,
        bottleR = 133, roundmonsterR = 2, roundmonsterG = 0, skeleton1 = 10, bat1 = 6, shop1 = 116, shop2 = 117, shop3 = 118,bigKey = 152,
        ironSword = 126,ironShield = 136,snake = 170,burger = 171};

    public partial class Game : Form
    {
        List<PictureBox> picList = new List<PictureBox>(); //存储所有PictureBox控件（地图元素）
        FightScene Fight;
        npc Shop;
        Map myMap;
        Hero myHero;
        Saver save;
        SoundPlayer sp;
        System.Resources.ResourceManager rm = new System.Resources.ResourceManager(typeof(Properties.Resources));
        
        int[,,] layerArray = { {{ 6,9}, {1,0} },{ {0,1 },{0,9} }, { {1,10 },{10,9 }},{ {10,9 },{0,9 } },
                                {{0,9},{9,10 } }, {{9,9},{4,9} }, { {5,10 },{1,0  } },{ {0,1 }, {7,5 } },
                                {{6,3 },{6,7 } },{{4,6 },{0,9} }, { {1,10 },{9,10 } },{ {9,10 },{1,10 } } };


        //从传入的文件路径初始化
        public Game(string path)
        {
            InitializeComponent();
            sp = new SoundPlayer();
            save = new Saver(path);
            myHero = new Hero(save.information["hero"]);
            myMap = new Map(save.information["Map"]);   //通过Saver对象信息字典中的 “Map" 键的值创建地图
            MusicPlay();
        }

        

        private void Game_Load(object sender, EventArgs e)
        {
            LoadMap(myHero.h);
            ShowInfo();
        }



        //按键控制
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            SoundEffect("MoveSE");
            switch (e.KeyCode)
            {
                case Keys.Left:  //左移
                    {
                        int[] oldPosition = { myHero.x, myHero.y };
                        int[] newPosition = { myHero.x-1, myHero.y  };
                        moveJudge(oldPosition, newPosition);
                        ChangeHeroGif(e);
                    }
                    break;   
                case Keys.Right:   //右移
                    {
                        int[] oldPosition = { myHero.x, myHero.y };
                        int[] newPosition = { myHero.x + 1 , myHero.y };
                        ChangeHeroGif(e);
                        moveJudge(oldPosition, newPosition);
                    }
                    break;
                case Keys.Up:  //上移
                    {
                        int[] oldPosition = { myHero.x, myHero.y };
                        int[] newPosition = { myHero.x, myHero.y - 1 };
                        moveJudge(oldPosition, newPosition);
                        ChangeHeroGif(e);
                    }
                    break;
                case Keys.Down: //下移
                    {
                        int[] oldPosition = { myHero.x, myHero.y };
                        int[] newPosition = { myHero.x, myHero.y + 1 };
                        moveJudge(oldPosition, newPosition);
                        ChangeHeroGif(e);
                    }
                    break;

            }
        }





        private void LoadMap(int nextlayer)
        {
            int row = 0;
            int column = 0;
            foreach (Control obj in flowLayoutPanel1.Controls)
            {
                if (obj is PictureBox)
                {
                    PictureBox pic = (PictureBox)obj;
                    pic.Image = (System.Drawing.Image)rm.GetObject($"_1_{myMap.layer1[nextlayer, row, column]}");
                    column = (column + 1) % 11;
                    if (column == 0)
                        row++;
                    picList.Add(pic);
                }
            }
        }

        private void moveJudge(int[] oldPosition, int[] newPosition)
        {   
            

            if (newPosition[0] > 10 || newPosition[1] > 10 || newPosition[0] < 0 || newPosition[1] < 0)  
                return;
            int nextObj = myMap.layer1[myHero.h, newPosition[1], newPosition[0]];   //下一个物体的编号
            switch (nextObj)
            {
                case (int)img.wallY:break;   //新位置为墙

                case (int)img.floor:         //新位置为地板，移动，更新位置、地图、图像
                    myHero.x = newPosition[0];
                    myHero.y = newPosition[1];
                    myMap.layer1[myHero.h, newPosition[1], newPosition[0]] = (int)img.hero1;
                    myMap.layer1[myHero.h, oldPosition[1], oldPosition[0]] = (int)img.floor;
                    picList[newPosition[1] * 11 + newPosition[0]].Image = picList[oldPosition[1] * 11 + oldPosition[0]].Image;
                    picList[oldPosition[1] * 11 + oldPosition[0]].Image = (System.Drawing.Image)rm.GetObject($"_1_{(int)img.floor}");
                    break;

                case (int)img.up:     //上楼，更新地图、层数、位置、图像
                    SoundEffect("UpDownStairsSE");
                    myMap.layer1[myHero.h, myHero.y, myHero.x] = (int)img.floor;
                    myHero.h++;
                    myHero.x = layerArray[myHero.h, 0, 0];
                    myHero.y = layerArray[myHero.h, 0, 1];
                    myMap.layer1[myHero.h,myHero.y,myHero.x] = (int)img.hero1;
                    //更新整个地图和英雄位置
                    LoadMap(myHero.h);
                    ShowInfo();
                    ShowSpreadInfo($"来到第{myHero.h}层");
                    break;

                case (int)img.down:  //下楼
                    SoundEffect("UpDownStairsSE");
                    myMap.layer1[myHero.h, myHero.y, myHero.x] = (int)img.floor;
                    myHero.h--;
                    myHero.x = layerArray[myHero.h, 1, 0];
                    myHero.y = layerArray[myHero.h, 1, 1];
                    myMap.layer1[myHero.h, myHero.y, myHero.x] = (int)img.hero1;
                    //更新整个地图和英雄位置
                    LoadMap(myHero.h);
                    ShowInfo();
                    ShowSpreadInfo($"来到第{myHero.h}层");
                    break;

                case (int)img.keyR:  //拾取红色钥匙
                    SoundEffect("GetKeySE");
                    myHero.key[0]++;
                    label_redkey.Text = myHero.key[0].ToString();
                    heroMove(oldPosition, newPosition);
                    break;

                case (int)img.keyY:   //拾取黄色钥匙
                    SoundEffect("GetKeySE");
                    myHero.key[1]++;
                    label_yellowkey.Text = myHero.key[1].ToString();
                    heroMove(oldPosition, newPosition);
                    break;

                case (int)img.keyB:   //拾取蓝色钥匙
                    SoundEffect("GetKeySE");
                    myHero.key[2]++;
                    label_bluekey.Text = myHero.key[2].ToString();
                    heroMove(oldPosition, newPosition);
                    break;

                case (int)img.ironSword: //拾取铁剑
                    SoundEffect("GetSwordSE");
                    myHero.Attack += 10;
                    ShowInfo();
                    break;

                case (int)img.ironShield: //拾取铁盾
                    SoundEffect("GetSwordSE");
                    myHero.Defence += 10;
                    ShowInfo();
                    break;

                case (int)img.bigKey:  //拾取大钥匙
                    SoundEffect("GetSwordSE");
                    myHero.key[0]++;
                    myHero.key[1]++;
                    myHero.key[2]++;
                    ShowInfo();
                    heroMove(oldPosition, newPosition);
                    break;

                case (int)img.bottleR:  //拾取红色药水
                    SoundEffect("GetKeySE");
                    myHero.Blood += 200;
                    label_health.Text = myHero.Blood.ToString();
                    heroMove(oldPosition, newPosition);
                    break;

                case (int)img.bottleB:  //拾取蓝色药水
                    SoundEffect("GetKeySE");
                    myHero.Blood += 500;
                    label_health.Text = myHero.Blood.ToString();
                    heroMove(oldPosition, newPosition);
                    break;

                case (int)img.gemR:  //拾取红色宝石
                    SoundEffect("GetKeySE");
                    myHero.Attack += 3;
                    label_attack.Text = myHero.Attack.ToString();
                    heroMove(oldPosition, newPosition);
                    break;

                case (int)img.gemB:  //拾取蓝色宝石
                    SoundEffect("GetKeySE");
                    myHero.Defence += 3;
                    label_defence.Text = myHero.Defence.ToString();
                    heroMove(oldPosition, newPosition);
                    break;

                case (int)img.doorR:  //开红色的门
                    if(myHero.key[0]>0)
                    {
                        SoundEffect("DoorOpenSE");
                        myHero.key[0]--;
                        label_redkey.Text = myHero.key[0].ToString();
                        heroMove(oldPosition, newPosition);
                        break;
                    }
                    else break;
                   
                case (int)img.doorY:  //开黄色的门
                    if(myHero.key[1]>0)
                    {
                        SoundEffect("DoorOpenSE");
                        myHero.key[1]--;
                        label_yellowkey.Text = myHero.key[1].ToString();
                        heroMove(oldPosition, newPosition);
                        break;
                    }
                    else break;
                    
                case (int)img.doorB:  //开蓝色的门
                    if(myHero.key[2]>0)
                    {
                        SoundEffect("DoorOpenSE");
                        myHero.key[2]--;
                        label_bluekey.Text = myHero.key[2].ToString();
                        heroMove(oldPosition, newPosition);
                        break;
                    }
                    else break;


                //遇到不同怪物
                case (int)img.roundmonsterG:
                case (int)img.roundmonsterR:
                case (int)img.bat1:
                case (int)img.skeleton1:
                    Fight = new FightScene(myHero, nextObj);
                    Fight.ShowDialog();
                    ShowInfo();
                    heroMove(oldPosition, newPosition);
                    break;

                case (int)img.shop1:            //商店
                case (int)img.shop2:
                case (int)img.shop3:
                    Shop = new npc(myHero);
                    Shop.StartPosition = FormStartPosition.CenterParent;    //使弹出窗口位于父窗体中央
                    ShowInfo();
                    Shop.ShowDialog();
                    break;
                case (int)img.snake:            //贪吃蛇隐藏关卡
                    if(MessageBox.Show("是否花费50金币进入到奖励关卡?", "奖励关卡", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        myHero.Money -= 50;
                        RetroSnake rsf = new RetroSnake();
                        rsf.Owner = this;
                        rsf.Show();
                        if (int.Parse(this.data_transport.Text) == 1)
                        {
                            myHero.items[0]++;
                            this.data_transport.Text = 0.ToString();
                        }
                    }
                    break;
                case (int)img.burger:           //图片翻转隐藏关卡
                    if(MessageBox.Show("是否花费50金币进入到奖励关卡", "奖励关卡", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        myHero.Money -= 50;
                        PhotoGame pgf = new PhotoGame();
                        pgf.Owner = this;
                        pgf.Show();
                        if (int.Parse(this.data_transport.Text) == 1)
                        {
                            myHero.items[1]++;
                            this.data_transport.Text = 0.ToString();
                        }
                    }
                    break;
                default:
                    heroMove(oldPosition, newPosition);
                    break;
            }
            ShowInfo();
        }

        private void heroMove(int[] oldPosition, int[] newPosition)
        {
            myHero.x = newPosition[0];
            myHero.y = newPosition[1];
            myMap.layer1[myHero.h, oldPosition[1], oldPosition[0]] = (int)img.floor;
            picList[newPosition[1] * 11 + newPosition[0]].Image = picList[oldPosition[1] * 11 + oldPosition[0]].Image;
            picList[oldPosition[1] * 11 + oldPosition[0]].Image = (System.Drawing.Image)rm.GetObject($"_1_{(int)img.floor}");
        }

        //任务控制方向更改
        private void ChangeHeroGif(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    picList[myHero.y * 11 + myHero.x].Image = (System.Drawing.Image)rm.GetObject("herodown");
                    break;

                case Keys.Left:
                    picList[myHero.y * 11 + myHero.x].Image = (System.Drawing.Image)rm.GetObject("heroleft");
                    break;
                case Keys.Right:
                    picList[myHero.y * 11 + myHero.x].Image = (System.Drawing.Image)rm.GetObject("heroright");
                    break;
                case Keys.Up:
                    picList[myHero.y * 11 + myHero.x].Image = (System.Drawing.Image)rm.GetObject("heroup");
                    break;
                default:
                    break;
            }
        }





        
        private void ShowInfo()
        {   //显示左侧所有标签的值
            label_health.Text = myHero.Blood.ToString();
            label_attack.Text = myHero.Attack.ToString();
            label_defence.Text = myHero.Defence.ToString();
            label_money.Text = myHero.Money.ToString();
            label1_exp.Text = myHero.Exp.ToString();
            label_yellowkey.Text = myHero.key[0].ToString()  ;
            label_bluekey.Text = myHero.key[1].ToString()  ;
            label_redkey.Text = myHero.key[2].ToString()  ;
            label_layer.Text = "第" + myHero.h + "层";
        }

        private void ShowSpreadInfo(String str)
        {   //控制出现横条
            label20.Text = str;
            tableLayoutPanel5.Visible = true;
            label20.Visible = true;
            label20.Refresh();
            Thread.Sleep(1000);
            label20.Visible = false;
            tableLayoutPanel5.Visible = false;
        }

        private void label_quit_Click(object sender, EventArgs e)
        {   //点击退出程序
            DialogResult dr = MessageBox.Show("是否确认退出程序并保存？", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {   //关闭窗口，创建存档
            save.information["Map"] = myMap.transTostring();
            save.information["hero"] = $"\r\n{myHero.x} {myHero.y} {myHero.h} {myHero.Blood} {myHero.Attack} " +
                $"{myHero.Defence} {myHero.Money} {myHero.Exp} {myHero.Level} {myHero.key[0]} {myHero.key[0]} {myHero.key[1]} {myHero.key[2]}\r\n";
            save.Write();
          
        }

        private void MusicPlay()
        {
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.URL = @"Audio\BGM\1-7BGM.wav";
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void SoundEffect(string s)
        {
            sp.SoundLocation = $"Audio\\SE\\{s}.wav";
            sp.Play();
        }
    }
}
