using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace WindowsHomework2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            writeData();
        }
        
        static string getRootKeyName(int i)
        {
            string rootkeyName = null;
            switch (i)
            {
                case 0:
                    rootkeyName = "HKEY_CLASSES_ROOT"; break;
                case 1:
                    rootkeyName = "HKEY_CURRENT_USER"; break;
                case 2:
                    rootkeyName = "HKEY_LOCAL_MACHINE"; break;
                case 3:
                    rootkeyName = "HKEY_USERS"; break;
                case 4:
                    rootkeyName = "HKEY_CURRENT_CONFIG"; break;
                default:
                    break;
            }
            return rootkeyName;
        }
        void writeData()
        {
            string rootkeyName = null;

            for (int i = 0; i < 5; i++)
            {
                rootkeyName = getRootKeyName(i);
                TreeNode node = new TreeNode(rootkeyName);
                treeView1.Nodes.Add(node);
                
                RegUtil.getEnumKey(rootkeyName, null, treeView1.Nodes[i].Nodes);
                
            }
        }
        public void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
        
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)  //单击鼠标左键才响应
            {
                    textBox1.Text = e.Node.FullPath;                    //文件框中显示鼠标点击的节点名称
            }
            treeView2.Nodes.Clear();
            currentNode1 = e.Node.Nodes;

        }

        TreeNodeCollection currentNode1;

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string currentPath = this.textBox1.Text.ToString();
            for (int i = 0; i < 5; i++)
            {
                if (currentPath == getRootKeyName(i) || currentPath == "") return;
            }
            string Key = currentPath.Substring(0, currentPath.IndexOf('\\'));
            string subKey = currentPath.Substring(currentPath.IndexOf('\\') + 1);
            RegUtil.getEnumValue(Key, subKey, treeView2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void treeView2_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Node.Level == 0)
            {
                
                string currentPath = this.textBox1.Text.ToString();
                for (int i = 0; i < 5; i++)
                {
                    if (currentPath == getRootKeyName(i) || currentPath == "") return;
                }
                string Key = currentPath.Substring(0, currentPath.IndexOf('\\'));
                string subKey = currentPath.Substring(currentPath.IndexOf('\\') + 1);
                string name = e.Node.Text;
                string value;
                Form2 form2 = new Form2();
                form2.Owner = this;
                form2.Show();
                value = label2.Text;
                RegUtil.SetRegistryKey(Key, subKey, name, value);
                
            }
            if(e.Button == MouseButtons.Right)
            {

            }
            
        }

        private void treeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Node.Level == 0)
            {
                label4.Text = e.Node.Text;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string currentPath = textBox1.Text;
            for (int i = 0; i < 5; i++)
            {
                if (currentPath == getRootKeyName(i) || currentPath == "") return;
            }
            string Key = currentPath.Substring(0, currentPath.IndexOf('\\'));           
            string subKey = currentPath.Substring(currentPath.IndexOf('\\') + 1);
            string keyName = label4.Text;
            RegUtil.DeleteKeyValue(Key, subKey, keyName, treeView2);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string currentPath = textBox1.Text;
            for (int i = 0; i < 5; i++)
            {
                if (currentPath == getRootKeyName(i) || currentPath == "") return;
            }
            string Key = currentPath.Substring(0, currentPath.IndexOf('\\'));
            string subKey = currentPath.Substring(currentPath.IndexOf('\\') + 1);
            RegUtil.AddKey(Key, subKey, currentNode1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string currentPath = textBox1.Text;
            for (int i = 0; i < 5; i++)
            {
                if (currentPath == getRootKeyName(i) || currentPath == "") return;
            }
            string Key = currentPath.Substring(0, currentPath.IndexOf('\\'));
            string subKey = currentPath.Substring(currentPath.IndexOf('\\') + 1);
            RegUtil.AddKeyValue(Key, subKey, treeView2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string currentPath = textBox1.Text;
            for (int i = 0; i < 5; i++)
            {
                if (currentPath == getRootKeyName(i) || currentPath == "") return;
            }
            string Key = currentPath.Substring(0, currentPath.IndexOf('\\'));
            string subKey = currentPath.Substring(currentPath.IndexOf('\\') + 1);
            RegUtil.deleteKey(Key, subKey);
            treeView1.Nodes.Clear();
            writeData();
        }

    }
    public static class RegUtil
    {
        static readonly IntPtr HKEY_CLASSES_ROOT = new IntPtr(unchecked((int)0x80000000));
        static readonly IntPtr HKEY_CURRENT_USER = new IntPtr(unchecked((int)0x80000001));
        static readonly IntPtr HKEY_LOCAL_MACHINE = new IntPtr(unchecked((int)0x80000002));
        static readonly IntPtr HKEY_USERS = new IntPtr(unchecked((int)0x80000003));
        static readonly IntPtr HKEY_PERFORMANCE_DATA = new IntPtr(unchecked((int)0x80000004));
        static readonly IntPtr HKEY_CURRENT_CONFIG = new IntPtr(unchecked((int)0x80000005));
        static readonly IntPtr HKEY_DYN_DATA = new IntPtr(unchecked((int)0x80000006));
        static int STANDARD_RIGHTS_ALL = (0x001F0000);
        static int KEY_QUERY_VALUE = (0x0001);
        static int KEY_SET_VALUE = (0x0002);
        static int KEY_CREATE_SUB_KEY = (0x0004);
        static int KEY_ENUMERATE_SUB_KEYS = (0x0008);
        static int KEY_NOTIFY = (0x0010);
        static int KEY_CREATE_LINK = (0x0020);
        static int SYNCHRONIZE = (0x00100000);
        static int KEY_WOW64_64KEY = (0x0100);
        static int REG_OPTION_NON_VOLATILE = (0x00000000);
        static int KEY_ALL_ACCESS = (STANDARD_RIGHTS_ALL | KEY_QUERY_VALUE | KEY_SET_VALUE | KEY_CREATE_SUB_KEY | KEY_ENUMERATE_SUB_KEYS
                                | KEY_NOTIFY | KEY_CREATE_LINK) & (~SYNCHRONIZE);
        

        /// <summary>
        /// 获取操作Key值句柄（打开现有项）
        /// </summary>
        /// <param name="hKey" 已打开句柄，或标准名 ></param>
        /// <param name="lpSubKey" 欲打开注册表名字></param>
        /// <param name="ulOptions" 未用设为0></param>
        /// <param name="samDesired" 带有前缀KEY_XX的常数></param>
        /// <param name="phkResult"  装载打开项的名字 句柄></param>
        [DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int RegOpenKeyEx(IntPtr hKey, string lpSubKey, uint ulOptions, int samDesired, out IntPtr phkResult);

        //创建或打开Key值：32位
        [DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int RegCreateKeyEx(IntPtr hKey, string lpSubKey, int reserved, string type, int dwOptions, int REGSAM, IntPtr lpSecurityAttributes, out IntPtr phkResult,
                                                    out int lpdwDisposition);

        //关闭注册表转向（禁用特定项的注册表反射）
        [DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int RegDisableReflectionKey(IntPtr hKey);

        //开启注册表转向（开启特定项的注册表反射）
        [DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int RegEnableReflectionKey(IntPtr hKey);

        //获取Key值（即：Key值句柄所标志的Key对象的值）   lpData为装载内容的缓冲区
        [DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int RegQueryValueEx(IntPtr hKey, string lpValueName, int lpReserved, ref RegistryValueKind lpType, System.Text.StringBuilder lpData, ref uint lpcbData);

        //枚举键的值（即：Key值句柄所标志的Key对象的值）   IpValueName:存放值名的缓冲区  IpType:数值类型   IpData：数值
        [DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int RegEnumValue(IntPtr hKey, int dwIndex, StringBuilder IpValueName, ref uint IpcbValueName, IntPtr IpReserved, ref RegistryValueKind lpType, IntPtr IpData, IntPtr lpcbData);

        //设置Key值
        [DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int RegSetValueEx(IntPtr hKey, string lpValueName, uint unReserved, uint unType, byte[] lpData, uint dataCount);

        //关闭Key值
        [DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int RegCloseKey(IntPtr hKey);

        //获取子键内容
        [DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int RegEnumKey(IntPtr hKey, int dwIndex, System.Text.StringBuilder lpData, int IpcbName);

        //删除键值
        [DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int RegDeleteValue(IntPtr Key, string lpValueName);

        //删除键
        [DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int RegDeleteTree(IntPtr hKey, string lpSubKey);

        //用于将跟键字符串转化为32位句柄
        public static IntPtr TransferKeyName(string keyName)
        {
            IntPtr ret = IntPtr.Zero;
            switch (keyName)
            {
                case "HKEY_CLASSES_ROOT":
                    ret = HKEY_CLASSES_ROOT;
                    break;
                case "HKEY_CURRENT_USER":
                    ret = HKEY_CURRENT_USER;
                    break;
                case "HKEY_LOCAL_MACHINE":
                    ret = HKEY_LOCAL_MACHINE;
                    break;
                case "HKEY_USERS":
                    ret = HKEY_USERS;
                    break;
                case "HKEY_PERFORMANCE_DATA":
                    ret = HKEY_PERFORMANCE_DATA;
                    break;
                case "HKEY_CURRENT_CONFIG":
                    ret = HKEY_CURRENT_CONFIG;
                    break;
                case "HKEY_DYN_DATA":
                    ret = HKEY_DYN_DATA;
                    break;
                default:
                    ret = HKEY_LOCAL_MACHINE;
                    break;
            }
            return ret;
        }

        /// <summary>
        /// 设置64位注册表
        /// </summary>
        /// <param name="key"></param>
        /// <param name="subKey"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int SetRegistryKey(string key, string subKey, string name, string value)
        {

            int ret = 0;
            try
            {
                //将Windows注册表主键名转化成为不带正负号的整形句柄（与平台是32或者64位有关）
                IntPtr hKey = TransferKeyName(key);

                //声明将要获取Key值的句柄 
                IntPtr pHKey = IntPtr.Zero;

                //获得操作Key值的句柄(有就指向该项，没有则创建）
                int lpdwDisposition = 0;
                ret = RegCreateKeyEx(hKey, subKey, 0, "", REG_OPTION_NON_VOLATILE, KEY_ALL_ACCESS | KEY_WOW64_64KEY, IntPtr.Zero, out pHKey, out lpdwDisposition);
                if (ret != 0)
                {
                    return ret;
                }

                //关闭注册表转向（禁止特定项的注册表反射）
                RegDisableReflectionKey(pHKey);

                //设置访问的Key值
                uint REG_SZ = 1;
                byte[] data = Encoding.Unicode.GetBytes(value);

                RegSetValueEx(pHKey, name, 0, REG_SZ, data, (uint)data.Length);

                //打开注册表转向（开启特定项的注册表反射）
                RegEnableReflectionKey(pHKey);
                //关闭句柄
                RegCloseKey(pHKey);
            }
            catch (Exception ex)
            {
                return -1;
            }

            return ret;
        }



        //枚举子键
        public static void getEnumKey(string key, string subKey,TreeNodeCollection currentNode)
        {
            int ret = 0;           
            int len = 2000;
            StringBuilder b = new StringBuilder(2000);
            int index = 0;
            while (ret == 0 && index<1000)
            {
                try
                {
                    IntPtr hKey = TransferKeyName(key);
                    IntPtr pHKey = IntPtr.Zero;
                    ret = RegUtil.RegOpenKeyEx(hKey, subKey, 0, KEY_ALL_ACCESS, out pHKey);
                    if (ret == 0)
                    {
                        ret = RegUtil.RegEnumKey(pHKey, index, b, len);
                    }

                    if (ret == 0) { 
                    TreeNode node1 = new TreeNode(b.ToString());
                    currentNode.Add(node1);
                    getEnumKey(key, subKey+b.ToString()+"\\", node1.Nodes);
                    
                    Console.WriteLine(b);
                    index++;
                    }
                }
                catch
                { }
            }
        }
        //枚举值
        public static void getEnumValue(string key, string subKey, TreeView treeView2)
        {
            int ret = 0;
            int index = 0;
            StringBuilder valueName = new StringBuilder(500);
            Byte[] buffer = new Byte[1024];
            RegistryValueKind valuetype = 0;

            StringBuilder value = new StringBuilder(1024);

            while (ret == 0)
            {
                try
                {
                    IntPtr hKey = TransferKeyName(key);
                    IntPtr pHKey = IntPtr.Zero;
                    ret = RegUtil.RegOpenKeyEx(hKey, subKey, 0, KEY_ALL_ACCESS, out pHKey);
                    if (ret != 0) return;

                    uint valueNameLen = 50;

                    ret = RegUtil.RegEnumValue(pHKey, index, valueName, ref valueNameLen, IntPtr.Zero, ref valuetype, IntPtr.Zero, IntPtr.Zero);
                    if (ret != 0) return;
                    TreeNode node1;
                    string valuenm = valueName.ToString();
                    if (valuenm == "")
                    {
                        node1 = new TreeNode("(默认)");
                    }
                    else
                    {
                        node1 = new TreeNode(valueName.ToString());
                    }
                    
                    treeView2.Nodes.Add(node1);
                    

                    uint len = 1024;
                    int ret2 = RegUtil.RegQueryValueEx(pHKey, valueName.ToString(), 0, ref valuetype, value, ref len);
                    TreeNode node2 = new TreeNode("类型："+valuetype.ToString());
                    TreeNode node3 = new TreeNode("数据：" + value.ToString());
                    node1.Nodes.Add(node2);
                    node1.Nodes.Add(node3);
                    index++;
                }
                catch
                {

                }
            }
            
            
        }
        public static void DeleteKeyValue(string key, string subKey, string keyName, TreeView treeView2)
        {
            IntPtr hKey = TransferKeyName(key);
            IntPtr pHKey = IntPtr.Zero;
            int ret = RegOpenKeyEx(hKey, subKey, 0, KEY_ALL_ACCESS, out pHKey);
            ret = RegDeleteValue(pHKey, keyName);
            if (ret == 0)
            {
                MessageBox.Show("删除键值成功");
                //刷新键值
                if (subKey != "")
                {
                    treeView2.Nodes.Clear();
                    getEnumValue(key, subKey + "\\" + keyName, treeView2);
                }
                else
                {
                    treeView2.Nodes.Clear();
                    getEnumValue(key, keyName, treeView2);
                }
            }
            else
            {
                MessageBox.Show("删除键值失败");
                
            }
        }
        public static void AddKey(string key,string subKey,TreeNodeCollection cureentNode)
        {
            try
            {
                IntPtr hKey = TransferKeyName(key);
                IntPtr pHKey = IntPtr.Zero;
                int ret;
                int retur;
                IntPtr lp = IntPtr.Zero;
                retur = RegCreateKeyEx(hKey, subKey + "\\新建项", 0, null, 0, KEY_ALL_ACCESS, lp, out pHKey, out ret);
                if (retur == 0)
                {
                    MessageBox.Show("创建新键成功");
                    getEnumKey(key, subKey, cureentNode);
                }
                else
                {
                    MessageBox.Show("创建新键失败");
                }
            }
            catch
            {

            }
            
        }
        public static void AddKeyValue(string key, string subKey, TreeView treeView2)
        {
            int ret;
            ret = SetRegistryKey(key, subKey, "新建键值", "0");
            //刷新
            if(ret == 0)
            {
                MessageBox.Show("新建键值成功！");
                treeView2.Nodes.Clear();
            }else{
                MessageBox.Show("新建键值失败！");
                treeView2.Nodes.Clear();
            }

        }
        public static void deleteKey(string key, string subKey)
        {
            int ret;
            IntPtr hKey = TransferKeyName(key);
            ret = RegDeleteTree(hKey, subKey);
            if (ret == 0)
            {
                MessageBox.Show("删除项成功，正在刷新，请稍后！");
            }
            else
            {
                MessageBox.Show("删除项失败！");
            }
        }
    }
}
