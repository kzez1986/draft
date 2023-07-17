using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace SimpleCSharpApp
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Hello World");
            string[] theArgs = Environment.GetCommandLineArgs();
            foreach (string arg in theArgs)
            {
                Console.WriteLine("Arg {0} {1:g}", arg, 12);
            }
            Console.WriteLine(Environment.ProcessorCount);
            Console.WriteLine(char.Parse("w") + "\a\a\a\a\a");
            BigInteger b1 = BigInteger.Parse("90000000000");
            BigInteger b2 = BigInteger.Parse("9999999999999999999999999999");
            Console.WriteLine(BigInteger.Multiply(b1, b2));
            string s = "t1111";
            string s2 = s.Replace("t1", "t2");
            Console.WriteLine(s2);
            StringBuilder sb = new StringBuilder("**** Fantastic Games ****", 256);
            sb.Append("\n");
            sb.AppendLine("Half Life");
            sb.AppendLine("Marrowind");
            Console.WriteLine(sb.ToString());
            sb.Replace("Half", "2");
            Console.WriteLine($"sb has {sb.Length} chars.");

            byte byte1 = 100;
            byte byte2 = 250;
            try
            {
                unchecked
                {
                    byte sum = ((byte)(byte1 + byte2));
                    Console.WriteLine("sum = {0}", sum);
                }

            }
            catch(OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }

            var myInt = 0;
            var myBool = true;
            var myString = "Time, marches on...";

            Console.WriteLine("myInt is a... {0}", myInt.GetType().Name);
            Console.WriteLine(myBool.GetType().Name);
            Console.WriteLine(myString.GetType().Name);

            Console.ReadLine();
            return -1;
        }
    }
}
