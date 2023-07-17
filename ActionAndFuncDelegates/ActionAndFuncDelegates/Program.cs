using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegates
{

    class Program
    {
        static void DisplayMessage(string msg, ConsoleColor color, int count)
        {
            ConsoleColor poprzedni = Console.ForegroundColor;
            Console.ForegroundColor = color;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(msg);
            }
            Console.ForegroundColor = poprzedni;
        }

        static int Add(int x, int y)
        {
            return x + y;
        }

        static string SumToString(int x, int y)
        {
            return (x + y).ToString();
        }

        static void Main(string[] args)
        {
            Action<string, ConsoleColor, int> action = new Action<string, ConsoleColor, int>(DisplayMessage);
            action("Hello", ConsoleColor.Yellow, 10);

            Func<int, int, int> sumaIntowa = Add;
            Func<int, int, string> sumaStringowa = SumToString;

            Console.WriteLine(sumaIntowa.Invoke(10, 5).ToString());
            Console.WriteLine(sumaStringowa(10, 20));

            Console.ReadLine();
        }
    }
}
