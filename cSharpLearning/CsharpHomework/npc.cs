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
    public partial class npc : Form
    {
        public npc(Hero hero)
        {
            InitializeComponent();
            this.hero = hero;
        }

        public Hero hero;

        private void npc_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LevelUp(object sender, EventArgs e)
        {
            if (hero.Exp >= 100)
            {
                hero.levelUp();
                hero.Exp -= 100;
            }
            else
            {
                MessageBox.Show("经验不足");
            }
        }

        private void Attack(object sender, EventArgs e)
        {
            if (hero.Exp >= 30)
            {
                hero.Attack += 5 ;
                hero.Exp -= 30;
            }
            else
            {
                MessageBox.Show("经验不足");
            }

        }

        private void Defence(object sender, EventArgs e)
        {
            if (hero.Exp >= 30)
            {
                hero.Defence += 5;
                hero.Exp -= 30;
            }
            else
            {
                MessageBox.Show("经验不足");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
