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

namespace WindowsHomework3_WPF
{
    /// <summary>
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public delegate void ChangeTextHandler(string text);
    public partial class Window2 : Window
    {
        public event ChangeTextHandler ChangeTextEvent;
        public Window2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChangeTextEvent(this.textbox1.Text);
            this.Close();
        }
    }
}
