using System;

namespace myapp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a;
            int MAX, MIN, SUM = 0;
            string s;
            a = new int[10];
            for(int i = 0;i < 10; i++)
            {
                Console.Write("Input No."+i+"\n");
                s = Console.ReadLine();
                a[i] = int.Parse(s);
            }
            MAX = a[0];
            MIN = a[0];
            for (int i = 1;i < 10; i++)
            {
                if (a[i] > MAX)
                {
                    MAX = a[i];
                }
                else
                {
                    if (a[i] < MIN)
                    {
                        MIN = a[i];
                    }
                }
                SUM += a[i];
            }
            Console.Write("The max number is:" + MAX+"\n");
            Console.Write("The min number is:" + MIN + "\n");
            Console.Write("The average number is:" + SUM/10 + "\n");
            Console.Write("The sum is:" + SUM + "\n");


        }
    }
    
}
