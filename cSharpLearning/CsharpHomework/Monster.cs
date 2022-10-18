using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MagicTower
{
    class Monster
    {
        //名字
        private string name;


        //定义血量属性
        public int Blood { get; }


        //定义攻击力属性
        public int Attack { get; }


        //定义防御力属性
        public int Defence { get; }


        //定义金币属性
        public int Money { get; }


        //定义经验属性
        public int Exp { get; }


        //位置数组 position[0]为横坐标 position[1]为纵坐标
        private int[] position;


        public Monster(string name,int blood,int attack,int defence,int money,int exp,int x,int y)
		{
			this.name = name;
			this.Blood = blood;
			this.Attack = attack;
			this.Defence = defence;
			this.Money = money;
			this.Exp = exp;
			position = new int[2] { x, y };
		}

	}


}
