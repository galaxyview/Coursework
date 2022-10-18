using System;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32;
using System.Xml;

namespace ConsoleApp1
{

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
        private static extern int RegOpenKeyEx(IntPtr hKey, string lpSubKey, uint ulOptions, int samDesired, out IntPtr phkResult);

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
                    Console.WriteLine("Unable to create key {0} - {1}: {2}!", key, subKey, ret);
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
                Console.WriteLine(ex.ToString());
                return -1;
            }

            return ret;
        }



        //枚举子键
        public static void getEnumKey(string key, string subKey)
        {
            int ret = 0;
            int index = 0;
            int len = 200;
            int i = -1;
            XmlDocument xml = new XmlDocument();
            xml.Load("XMLFile1.xml");
            StringBuilder b = new StringBuilder(200);
            while (ret == 0)
            {
                
                try
                {
                    IntPtr hKey = TransferKeyName(key);
                    IntPtr pHKey = IntPtr.Zero;
                    ret = RegUtil.RegOpenKeyEx(hKey, subKey, 0, KEY_ALL_ACCESS, out pHKey);

                    if (ret != 0)
                    {
                        Console.WriteLine("Failed to open Reg {0}\\{1}\\{2},return {3}", key, subKey, ret);
                    }

                    ret = RegUtil.RegEnumKey(pHKey, index, b, len);
                    

                    if (ret != 0)
                    {
                        Console.WriteLine("Failed to List EnumKey{0}\\{1}\\{2},return {3}", key, subKey, ret);
                    }
                    Console.WriteLine(b);
                    index++;
                }
                catch
                {

                }
            }
        }
        //枚举值
        public static void getEnumValue(string key, string subKey)
        {
            int ret = 0;
            int index = 0;
            StringBuilder valueName = new StringBuilder(50);
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
                    if (ret != 0)
                    {
                        Console.WriteLine("Failed to open Reg {0}\\{1}\\{2},return {3}", key, subKey, ret);
                        return;
                    }
                    ;

                    uint valueNameLen = 50;

                    ret = RegUtil.RegEnumValue(pHKey, index, valueName, ref valueNameLen, IntPtr.Zero, ref valuetype, IntPtr.Zero, IntPtr.Zero);
                    if (ret != 0)
                    {
                        Console.WriteLine("Failed to List EnumKey{0}\\{1},return {2}", key, subKey, ret);
                        return;
                    }
                    uint len = 1024;
                    int ret2 = RegUtil.RegQueryValueEx(pHKey, valueName.ToString(), 0, ref valuetype, value, ref len);

                    Console.WriteLine("{0}—{1}—{2}", valueName.ToString(), valuetype.ToString(), value);
                    index++;
                }
                catch
                {

                }
            }
        }
    }

    class Program
    {

        static string Winrarpath = @"SOFTWARE\Microsoft\Windows\CurrentVersion";
        static string key = "DevicePath";

        static void Main(string[] args)
        {
            Console.WriteLine("请输入操作码   0:退出   1：查看当前项的值   2：修改与创建数值    3：回退   4：转向子项  5：查看子项");
            while (true)
            {
                char op = Console.ReadLine()[0];
                string name = "";
                string value = "";
                switch (op)
                {
                    case '0':
                        return;

                    case '1':
                        //value = RegUtil.GetRegistryValue(Winrarpath, key);
                        //Console.WriteLine("注册表项{0}\r\n值{1}为:{2}",Winrarpath,key,value);
                        RegUtil.getEnumValue("HKEY_LOCAL_MACHINE", Winrarpath);
                        break;

                    case '2':
                        //修改项的数据，若不存在该名称的数据则自动创建，若不存在该项也会创建
                        Console.WriteLine("当前位置{0}", Winrarpath);
                        Console.WriteLine("输入子项名（输入则创建子项，否则不创建）");
                        string subkey = @"\" + Console.ReadLine();
                        Console.WriteLine("请输入数据名称:");
                        name = Console.ReadLine();
                        Console.WriteLine("请输入数值:");
                        value = Console.ReadLine();
                        RegUtil.SetRegistryKey("HKEY_LOCAL_MACHINE", Winrarpath + subkey, name, value);
                        break;

                    case '3':
                        Winrarpath = Winrarpath.Substring(0, Winrarpath.LastIndexOf(@"\"));
                        Console.WriteLine("当前路径为{0}", Winrarpath);
                        break;

                    case '4':
                        Console.WriteLine("输入子项名称(没有则创建)");
                        string subkey4 = @"\" + Console.ReadLine();
                        Winrarpath += subkey4;
                        RegUtil.SetRegistryKey("HKEY_LOCAL_MACHINE", Winrarpath, "", "");
                        Console.WriteLine("当前位置{0}", Winrarpath);
                        break;

                    case '5':
                        RegUtil.getEnumKey("HKEY_LOCAL_MACHINE", Winrarpath);
                        break;

                    default:
                        Console.WriteLine("未定义的操作");
                        break;
                }
                Console.WriteLine("**************************************************");
            }
        }

    }

}


