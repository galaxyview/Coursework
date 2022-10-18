using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MagicTower
{
	public class Hero
	{
		//定义等级属性
		public int Level { get; set; }
		//定义血量属性
		public int Blood { get; set; }
		//定义攻击力属性
		public int Attack { get; set; }
		//定义防御力属性
		public int Defence { get; set; }
		//定义金币属性
		public int Money { get; set; }
		//定义经验属性
		public int Exp { get; set; }

		//钥匙数量数组 key[0]为红色钥匙数量 key[1]为黄色钥匙数量 key[2]为蓝色钥匙数量
		public int[] key = new int[3];

		public int[] items = new int[5];
		public int x { get; set; } 
		public int y { get; set; }
		public int h { get; set; } 




		//默认构造函数
		public Hero()
		{
			Blood = 1000;
			Attack = 10;
			Defence = 10;
			key[0] = 0;
			key[1] = 0;
			key[2] = 0;
			items[0] = 0;
			items[1] = 0;
			items[2] = 0;
			items[3] = 0;
			items[4] = 0;
			Level = 1;
			Money = 0;
			Exp = 0;
			x = 5;
			y = 9;
			h = 0;
		}




		public Hero(string data)
		{
			data = data.Replace("\r\n", " ");
			string[] num = data.Split(' ');
			x = Convert.ToInt32(num[1]);
			y = Convert.ToInt32(num[2]);
			h = Convert.ToInt32(num[3]);
			Blood = Convert.ToInt32(num[4]);
			Attack = Convert.ToInt32(num[5]);
			Defence = Convert.ToInt32(num[6]);
			Money  = Convert.ToInt32(num[7]);
			Exp = Convert.ToInt32(num[8]);
			Level = Convert.ToInt32(num[9]);
			key[0]  = Convert.ToInt32(num[10]);
			key[1] = Convert.ToInt32(num[11]);
			key[2] = Convert.ToInt32(num[12]);
		}


		//等级提升
		public void levelUp()
		{
			Level++;
			Attack += 7;
			Defence += 7;
		}


	}
}



