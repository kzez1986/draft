using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 15;
            int b = 20;
            Console.WriteLine("{0} {1}", a, b);
            Swap<int>(ref a, ref b);
            Console.WriteLine("{0} {1}", a, b);
            Console.WriteLine("");
            string c = "Kot";
            string d = "Pies";
            Console.WriteLine(c + " " + d);
            Swap<string>(ref c, ref d);
            Console.WriteLine(c + " " + d);
            Rectangle e = new Rectangle(5, 12);
            Rectangle f = new Rectangle(4, 3);
            Console.WriteLine(e + " " + f);
            Swap<Rectangle>(ref e, ref f);
            Console.WriteLine(e + " " + f);
            DisplayBaseClass<MemberAccessException>();
            Console.WriteLine("");
            Point<int> p1 = new Point<int>(1, 10);
            p1.Reset();
            Console.WriteLine(p1.ToString());
            Point<double> p2 = new Point<double>(12.12, 2.3);
            p2.Reset();
            Console.WriteLine(p2.ToString());
            Console.ReadLine();
        }

        static void Swap<T>(ref T a, ref T b) 
        {
            Console.WriteLine("Swap typ: {0}", typeof(T));
            T temp;
            temp = a;
            a = b;
            b = temp;
        }

        public static void DisplayBaseClass<T>()
        {
            Console.WriteLine("Base type of {0} is {1}", typeof(T), typeof(T).BaseType);
        }
    }

    class Rectangle : IComparable<Rectangle>
    {
        public int a { get; set; }
        public int b { get; set; }

        public Rectangle() { }

        public Rectangle(int _a, int _b)
        {
            a = _a;
            b = _b;
        }

        public int Area()
        {
            return a * b;
        }

        public override string ToString()
        {
            return "A = " + a.ToString() + " " + "B = " + b.ToString();
        }

        int IComparable<Rectangle>.CompareTo(Rectangle obj)
        {
            if (this.Area() > obj.Area()) return 1;
            else if (this.Area() < obj.Area()) return -1;
            else return 0;
        }

    }

    //Generyczna struktura Point
    public struct Point<T> where T: struct
    {
        //dane
        private T xPos;
        private T yPos;

        //konstruktor

        public Point(T _x, T _y)
        {
            xPos = _x;
            yPos = _y;
        }

        public T X
        {
            get { return xPos; }
            set { xPos = value; }
        }

        public T Y
        {
            get { return yPos; }
            set { yPos = value; }
        }

        public override string ToString()
        {
            return xPos + " " + yPos;
        }

        public void Reset()
        {
            xPos = default(T);
            yPos = default(T);
        }
    }
}
