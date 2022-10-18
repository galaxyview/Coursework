using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowsHomework3_Winform
{
    public partial class Form2 : Form
    {
        #region 定义常量消息值
        public const int WM_COPYDATA = 0x004A;
        #endregion
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        protected override void DefWndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case WM_COPYDATA:
                    //接收字符串消息
                    String msgToStr = Marshal.PtrToStringAnsi(m.LParam); //地址值转为String
                    //textBox1.Text = msgToStr;
                    richTextBox1.Text += "Sender:" + msgToStr + "\n";
                    break;
                default:
                    base.DefWndProc(ref m); //调用基类函数
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
