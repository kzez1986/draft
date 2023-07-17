using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpression
{
    class SimpleMath
    {
        private int x;
        private int y;

        public SimpleMath(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public int Add() => x + y;
        public int Sumbstract() => x - y;
        public int Multiply() => x * y;

    }



    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            numbers.AddRange(new int[] { 1, 33, 2, 4, 5, 6, 12, 33, 44, 1, 11, 22, 100 });
            List<int> div11 = numbers.FindAll(i =>
            {
                Console.WriteLine("Sprawdzanie {0}", i);
                bool isDiv11 = ((i % 11) == 0);
                return isDiv11;
            });
            foreach (int element in div11)
            {
                Console.WriteLine(element.ToString());
            }

            Console.WriteLine();

            SimpleMath sm = new SimpleMath(2, 4);
            Console.WriteLine(sm.Add().ToString());
            Console.WriteLine(sm.Multiply().ToString());
            Console.ReadLine();
        }
    }

}