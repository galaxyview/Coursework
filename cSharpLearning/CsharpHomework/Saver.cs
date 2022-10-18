using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MagicTower
{
    //维持一个字典保存地图和角色信息，并实现读、存功能
    class Saver
    {
        public Dictionary<string, string> information { get; set; } = new Dictionary<string, string>();
        private string DefaultSaveFile = @"Save\\map1.txt";
        private string initialFile = @"Maps\\Initial.txt";

        public Saver()
        {
            Read(initialFile);
        }

        //根据路径初始化
        public Saver(string path)
        {
            Read(path);
        }


        ~Saver()
        {
        }

        //读txt，初始化字典  数据格式： #key:\r\nvalue\r\n
        public void Read(string path) 
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            string data = sr.ReadToEnd();
            string[] data2 = data.Split('#');   //首个值为空，因开头第一个字符为#
            foreach (string piece in data2)
            {
                if (piece != "")
                {
                    string[] li = piece.Split(':');
                    information.Add(li[0], li[1]);
                }
            }
            sr.Close();
        }


        //将字典写入txt
        public void Write() 
        {
            FileStream fs = new FileStream(DefaultSaveFile, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            foreach (var d in information)
            {
                sw.Write("#" + d.Key + ":" + d.Value); //数据格式： #key:\r\nvalue\r\n
            }
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }

    }
}
