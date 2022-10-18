using System;
using System.Linq;

namespace Homework5._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = new int[100];
            int sum = 0;
            Random ran = new Random();
            for(int i = 0; i < 100; i++)
            {
                num[i] = ran.Next(1,1000);
            }
            var query = from n in num orderby n descending select n;
            foreach(var n in query)
            {
                Console.WriteLine(n);
                sum += n;
            }
            Console.WriteLine("和为：" + sum + " 平均数为：" + sum / 100);
        }
    }
}
