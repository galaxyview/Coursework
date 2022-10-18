using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Interop;
//using Utils;


namespace WindowsHomework3_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region 定义常量消息值
        public const int WM_COPYDATA = 0x004A;
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

        #region 动态链接库引入
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(
        IntPtr hWnd, // handle to destination window 
        int Msg, // message 
        int wParam, // first message parameter 
        ref COPYDATASTRUCT lParam // second message parameter 
        );
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, uint hwndChildAfter, string lpszClass, string lpszWindow);
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            Window1 w1 = new Window1();
            w1.Title = "Receiver";
            w1.Show();
            this.Title = "Sender";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string message = textbox1.Text;
            IntPtr hWnd = FindWindow(null, "Receiver");
            if (message == null)
            {
                MessageBox.Show("请输入要发送的消息内容");
                return;
            }
            byte[] sarr = System.Text.Encoding.Default.GetBytes(message);
            int len = sarr.Length;
            COPYDATASTRUCT cds;
            cds.dwData = (IntPtr)Convert.ToInt16(0);//可以是任意值
            cds.cbData = len + 1;//指定lpData内存区域的字节数
            cds.lpData = message;//发送给目标窗口所在进程的数据
            SendMessage(hWnd, WM_COPYDATA, 0, ref cds);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2();
            w2.ChangeTextEvent += new ChangeTextHandler(method);//注册事件
            w2.Show();//打开子窗口
        }
        
        //事件的定义
        private void method(string text)
        {
            this.textbox1.Text = text;
        }
    }
}
