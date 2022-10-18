using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MagicTower
{
    
    //拿着剑和盾的swardsolder后面是加的，
    //用一个三维数组保存多层地图，实现初始化、从字典值创建、转化为字典值以保存
    class Map
    {

        public int[,,] layer1 { get; set; } = new int[24,11, 11];
        private String SaveFile = @"Save\\map.txt";

        public Map() 
        {
            //检查路径
            if (!Directory.Exists(@"Save"))
            {
                    Directory.CreateDirectory(@"Save");
            }
            if (!File.Exists(SaveFile))
                File.Create(SaveFile);
                //LoadFile(SaveFile);

        }
         
        public Map(string data)      //地图读档，通过字符串创建地图
        {
            data = data.Replace("\r\n"," ");
            string[] num = data.Split(' ');
            Console.WriteLine(num);
            for (int l = 0; l < 20; l++)
            {
                for (int i = 0; i < 11; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {   if(num[l * 121 + i * 11 + j + 1]!="")
                            layer1[l, i, j] = Convert.ToInt32(num[ l * 121 + i * 11 + j + 1]);
                    }
                }
            }
        }

        public string transTostring()
        {
            string stringMap = "";
            int n = 0;
            foreach (int picNum in layer1)
            {
                stringMap += picNum.ToString();
                n = (n + 1) % 11;
                if (n == 0)
                    stringMap += "\r\n";
                else
                    stringMap += " ";
            }
            stringMap = "\r\n" + stringMap;
            return stringMap;
        }


        ~Map()
        {
            //Save();
        }
         

    }
}
