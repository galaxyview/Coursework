using System;
using System.Linq;

namespace Homework5
{
    
    class Program
    {
        public bool checkPrime(int num)
        {
            for (int j = 2; j < num; j++)
            {
                if (num % j == 0) return false;
            }
            return true;
        }

        public void ChangeIntoPrime(int num)
        {
            var numbers = Enumerable.Range(1, (int)(num / 2) + 1);
            var PrimeNumbers = from w in numbers where checkPrime(w) && checkPrime(num-w) select w;
            foreach(var n in PrimeNumbers)
            {
                Console.WriteLine(n + "+" + (num - n) + "=" + num);
            }
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            var numbers = Enumerable.Range(6, 100);
            var EvenNumbers = from n in numbers where n % 2 == 0 select n;
            foreach(var n in EvenNumbers)
            {
                p.ChangeIntoPrime(n);
            }
        }
    }
}
