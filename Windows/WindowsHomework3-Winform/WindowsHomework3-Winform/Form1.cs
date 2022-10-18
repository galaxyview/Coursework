using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowsHomework3_Winform
{
    public partial class Form1 : Form
    {
        #region 动态链接库引入
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);

        /*
        private static extern int SendMessage(
        IntPtr hWnd, // handle to destination window 
        int Msg, // message 
        int wParam, // first message parameter 
        ref COPYDATASTRUCT lParam // second message parameter 
        );
        */
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, uint hwndChildAfter, string lpszClass, string lpszWindow);
        #endregion

        #region 定义结构体
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }
        #endregion

        #region 定义常量消息值
        public const int WM_COPYDATA = 0x004A;
        #endregion
        public Form1()
        {
            InitializeComponent();
            Form2 fm2 = new Form2();
            fm2.Text = "Receiver";
            fm2.Show();
            this.Text = "Sender";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = textBox1.Text;
            IntPtr hWnd = FindWindow(null, "Receiver");
            if (message == null)
            {
                MessageBox.Show("请输入要发送的消息内容");
                return;
            }
            IntPtr msgToInt = Marshal.StringToHGlobalAnsi(message);
            SendMessage(hWnd, WM_COPYDATA, 0, msgToInt);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 fm3 = new Form3();
            fm3.ChangeTextEvent += new ChangeTextHandler(method);
            fm3.Show();
        }

        private void method(string text)
        {
            this.textBox1.Text = text;
        }
    }
}
