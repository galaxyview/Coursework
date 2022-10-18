using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Interop;


namespace WindowsHomework3_WPF
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
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

        public Window1()
        {
            InitializeComponent();
            this.SourceInitialized += new EventHandler(MainWindow_SourceInitialized);
            this.richtextbox1.Document.Blocks.Clear();
            this.richtextbox1.AppendText("\n");
            
        }
        void MainWindow_SourceInitialized(object sender, EventArgs e)
        {
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            HwndSource.FromHwnd(hwnd).AddHook(new HwndSourceHook(WndProc));
        }
        
        IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_COPYDATA)
            {
                COPYDATASTRUCT cds = (COPYDATASTRUCT)Marshal.PtrToStructure(lParam, typeof(COPYDATASTRUCT)); // 接收封装的消息
                string rece = cds.lpData; // 获取消息内容
                this.richtextbox1.AppendText("Sender:" + rece + "\n");
            }
            return hwnd;
        }

        private void textbox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }   
}
