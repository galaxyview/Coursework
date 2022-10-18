using System;

namespace ConsoleApp1
{
    interface IShape 
    {
        double Area();
        bool isLegitimate();
    }
    
    class shape:Object ,IShape
    {
        protected double edge1, edge2, edge3, edge4;
        public bool isLegitimate()
        {
            return false;
        }

        public double Area()
        {
            return 0;
        }
    }
    
    
    class Triangle:shape
    {
        public Triangle(double edge1,double edge2, double edge3,double edge4)
        {
            this.edge1 = edge1;
            this.edge2 = edge2;
            this.edge3 = edge3;
        }
        new public double Area()
        {
            double p, sum;
            p = (edge1 + edge2 + edge3) / 3;
            sum = Math.Sqrt( p*(p - edge1)*(p - edge2)*(p - edge3));
            return sum;
        }
        new public void isLegitimate(double sum)
        {
            Console.WriteLine("随机生成的三角形的三边分别为："+edge1+"," +edge2+ "," + edge3);
            if (edge1 + edge2 > edge3 && edge1 + edge1 + edge3 > edge2 && edge2 + edge3 > edge1)
            {
                Console.WriteLine("该三角形合法。三角形面积为：" + Area().ToString() + "\n");
                sum += Area();
                
            }
            else
                Console.WriteLine("该三角形不合法。\n");
        }

    }

    class rectangle:shape
    {
        public rectangle(double edge1,double edge2,double edge3,double edge4)
        {
            this.edge1 = edge1;
            this.edge2 = edge2;
            this.edge3 = edge3;
            this.edge4 = edge4;
        }

        new public double Area()
        {

            if (edge1 == edge2)
            {
                return edge1 * edge3;
            }
            else
            {
                return edge1 * edge2;
            }
        }

        new public void isLegitimate(double sum)
        {
            Console.WriteLine("随机生成的长方形的四边分别为：" + edge1 + "," + edge2 + "," + edge3+","+edge4);
            if ((edge1 == edge2 && edge3 == edge4) || (edge1 == edge3 && edge2 == edge4) || (edge1 == edge4 && edge2 == edge3))
            {
                Console.WriteLine("该长方形合法。长方形面积为：" + Area()+"\n");
                sum += Area();
            }
            else
                Console.WriteLine("该长方形不合法。\n");
        }
    }

    class Square:rectangle
    {
        public Square(double edge1, double edge2, double edge3, double edge4):base(edge1,edge2,edge3,edge4)
        {
           
        }

        new public void isLegitimate(double sum)
        {
            Console.WriteLine("随机生成的正方形的四边分别为：" + edge1 + "," + edge2 + "," + edge3 + "," + edge4);
            if (edge1 == edge2&& edge1 == edge3&&edge1==edge4)
            {
                Console.WriteLine("该正方形合法。正方形面积为：" + Area()+"\n");
                sum += Area();
            }
            else
                Console.WriteLine("该正方形不合法。\n");
        }
        new public double Area()
        {
            return edge1 * edge1;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Random flag = new Random();
            Random ran = new Random();
            int a;
            double sum = 0;
            for(int i = 0; i < 10; i++)
            {
                a = flag.Next(1, 4);
                if(a == 1)
                {
                    Triangle t = new Triangle(ran.Next(1, 10), ran.Next(1, 10), ran.Next(1, 10), ran.Next(1, 10));
                    t.isLegitimate(sum);
                }
                else
                {
                    if (a == 2)
                    {
                        rectangle r = new rectangle(ran.Next(1, 10), ran.Next(1, 10), ran.Next(1, 10), ran.Next(1, 10));
                        r.isLegitimate(sum);
                    }
                    else
                    {
                        Square s = new Square(ran.Next(1, 10), ran.Next(1, 10), ran.Next(1, 10), ran.Next(1, 10));
                        s.isLegitimate(sum);
                    }
                }
            }
            Console.WriteLine("面积之和为：" + sum);
        }
    }
}
