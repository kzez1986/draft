using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelegate
{
    public delegate int BinaryOp(int x, int y);

    public class SimpleMath
    {
        public int Add(int x, int y) { return x + y; }
        public int Substract(int x, int y) { return x - y; }
        public static int SquareNumber(int x) { return x * x; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            SimpleMath sm = new SimpleMath();

            Console.WriteLine("Simple Delegate Example");
            BinaryOp b = new BinaryOp(sm.Add);
            Console.WriteLine("10 + 10 is {0}",b.Invoke(10, 10));
            InfoDelegate(b);
            Console.ReadLine();

            
        }

        public static void InfoDelegate(Delegate del)
        {
            foreach(Delegate d in del.GetInvocationList())
            {
                Console.WriteLine("Metoda: {0}", d.Method);
                Console.WriteLine("Typ: {0}", d.Target);
            }
        }
    }
}
