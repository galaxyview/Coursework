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

    public partial class FightScene : Form
    {
        Dictionary<string, string> monsterDic = new Dictionary<string, string>
        {
            ["0"] = "50,20,1,1,1",
            ["2"] = "70,15,2,2,2",
            ["4"] = "200,35,10,5,5",
            ["6"] = "100,20,5,3,3",
            ["8"] = "150,65,30,10,8 ",
            ["10"] = "110,25,5,5,4",
            ["12"] = "150,40,20,8,6",
            ["14"] = "400,90,50,15,12",
            ["16"] = "125,50,25,10,7",
            ["18"] = "100,200,110,30,25",
            ["20"] = "300,75,45,13,10",
            ["22"] = "900,450,330,50,50",
            ["24"] = "500,115,65,15,15 "
        };

        int monsterNo;
        SoundPlayer sp = new SoundPlayer();
        int[] thisMonster = new int[5];
        System.Resources.ResourceManager rm = new System.Resources.ResourceManager(typeof(Properties.Resources));
        Hero hero;

        //用于关闭窗口时快速结束
        int initialMonsterBlood;
        int initialHeroBlood;

        public FightScene(Hero hero,int ObjectNo)
        {
            InitializeComponent();

            //获取敌人编号
            monsterNo = ObjectNo;

            //根据monsterDic和编号获取敌人数据
            string[] tempData = monsterDic[$"{monsterNo}"].Split(',');
            int i = 0;
            foreach (string data in tempData)
            {
                thisMonster[i] = Convert.ToInt32(data);
                i++;
            }


            pictureBox1.Image = (System.Drawing.Image)rm.GetObject($"_1_{monsterNo}");
            this.hero = hero;
            initialHeroBlood = hero.Blood;
            initialMonsterBlood = thisMonster[0];
            timer1.Enabled = true;
        }

        private void FightScene_Load(object sender, EventArgs e)
        {
            ShowAttr();
        }

        public void ShowAttr()
        {
            label_MonsterBlood.Text = $"生命值:{thisMonster[0]}";
            label_MonsterAttack.Text = label_MonsterAttack.Text + thisMonster[1];
            label_MonsterDefence.Text = label_MonsterDefence.Text + thisMonster[2];
            label_HeroBlood.Text = hero.Blood.ToString() + label_HeroBlood.Text;
            label_HeroAttack.Text = hero.Attack.ToString() + label_HeroAttack.Text;
            label_HeroDefence.Text = hero.Defence.ToString() + label_HeroDefence.Text;
        }


        int num = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            SoundEffect("FistSE");
            int HeroDemage = hero.Attack - thisMonster[2];
            int MonsterDemage = thisMonster[1] - hero.Defence;
            if (HeroDemage > 0)
            {
                thisMonster[0] -= HeroDemage;
                if (thisMonster[0] <= 0)
                {
                    label_MonsterBlood.Text = $"生命值:0";
                    this.Close();
                }
                label_MonsterBlood.Text = $"生命值:{thisMonster[0]}";
                textBox_Detail.Text += $"回合{num} 对敌人造成伤害：{HeroDemage}\r\n";
            }
            else
            {
                textBox_Detail.Text += "未能击穿敌人的护甲\r\n";
            }
            //文本滚动
            textBox_Detail.SelectionStart = textBox_Detail.Text.Length-2;
            textBox_Detail.ScrollToCaret();


            System.Threading.Thread.Sleep(300);

            if (MonsterDemage > 0 && thisMonster[0]>0)
            {
                hero.Blood -= MonsterDemage;
                if (hero.Blood <= 0)
                {
                    label_HeroBlood.Text = $"0:生命值";
                    MessageBox.Show("你死了", "END");
                    this.Close();
                    
                }
                label_HeroBlood.Text = $"{hero.Blood}:生命值";
                textBox_Detail.Text += $"回合{num} 受到伤害：{MonsterDemage}\r\n";
            }
            else
            {
                textBox_Detail.Text += "收到伤害0\r\n";
            }
            //文本滚动
            textBox_Detail.SelectionStart = textBox_Detail.Text.Length-2;
            textBox_Detail.ScrollToCaret();

            //下一回合
            num++;
        }



        //关闭画面 快速结束战斗
        private void FightScene_FormClosed(object sender, FormClosedEventArgs e)
        {
            //战斗未结束,快速计算战斗结果 扣血 获得战斗结果等
            //由于不确定会在什么时刻点击结束，根据记录的初始数值计算且排除不确定因素
            timer1.Stop();
            if (thisMonster[0] > 0 & hero.Blood > 0)
            {
                int damage = hero.Attack - thisMonster[2];
                if (damage <= 0)    //无法破防,战斗必然失败
                {
                    hero.Blood = 0;
                    MessageBox.Show("九折水平？", "END");
                }
                else 
                {
                    int roundNum = initialMonsterBlood / damage - 1;
                    int damageSum = (thisMonster[1] - hero.Defence) * roundNum;
                    if (damageSum > initialHeroBlood)      //
                    {
                        hero.Blood = 0;
                        MessageBox.Show("九折水平？", "END");
                    }
                    else 
                    {
                        hero.Blood = initialHeroBlood - damageSum;
                        hero.Money += thisMonster[3];
                        hero.Exp += thisMonster[4];
                    }
                }
            }
        }

        private void SoundEffect(string s)
        {
            sp.SoundLocation = $"Audio\\SE\\{s}.wav";
            sp.Play();
        }


    }
}
