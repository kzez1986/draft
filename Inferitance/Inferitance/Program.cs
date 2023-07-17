using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inferitance
{
    class Program
    {
        static void Main(string[] args)
        {
            Square sq1 = new Square(10);
            Console.WriteLine(sq1.Area());
            Console.ReadLine();
        }
    }

    class Shape
    {
        public int width;
        public Shape(int width)
        {
            this.width = width;
        }
    }

    sealed class Square : Shape
    {
        public Square(int w) : base(w) { }

        public int Area()
        {
            return width * width;
        }
    }
}
