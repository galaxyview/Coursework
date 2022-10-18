using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsHomework2_CallDll
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        WindowsHomework_csDll.Class1 callDll = new WindowsHomework_csDll.Class1();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = "+";
            int a = int.Parse(textBox1.Text);
            int b = int.Parse(textBox2.Text);
            //textBox3.Text = ImportDll.Add(a, b).ToString();
            textBox3.Text = callDll.Add(a, b).ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label4.Text = "-";
            int a = int.Parse(textBox1.Text);
            int b = int.Parse(textBox2.Text);
            //textBox3.Text = ImportDll.Decline(a, b).ToString();
            textBox3.Text = callDll.Decline(a, b).ToString();
        }
    }
    class ImportDll
    {
        [DllImport(@"WindowsHomework2-CppDll.dll", EntryPoint = "Add", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]

        public extern static int Add(int a, int b);

        [DllImport(@"WindowsHomework2-CppDll.dll", EntryPoint = "Decline", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]

        public extern static int Decline(int a, int b);
    }
    
}
