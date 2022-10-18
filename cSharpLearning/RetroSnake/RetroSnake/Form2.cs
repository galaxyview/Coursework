using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace RetroSnake
{
    public partial class Form2 : Form
    {
        public string victory = "";
        public string TestValue
        {
            get
            {
                return victory;
            }
            set
            {
                this.victory = value;
                
            }
        }

        public Form2()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form1 frm1 = new Form1();
            frm1.Owner = this;
            frm1.Show();
            
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确认删除？", "此删除不可恢复", MessageBoxButtons.YesNo);
        }
    }
}
