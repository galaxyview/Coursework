using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MagicTower
{
    class Key
    {
        //定义颜色属性
        public int KeyColor { get; }

        //位置数组 position[0]为横坐标 position[1]为纵坐标
        private int[] position;


        //构造函数
        public Key(int color,int x,int y)
        {
            this.KeyColor = color;
            position = new int[2] { x, y };
        }

	}


}
