using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithMethods
{
    enum EmpType : byte
    {
        Manager = 10,
        Grunt = 20, 
        Contractor = 30,
        VicePresident = 40
    }

    class Person
    {
        public string personName;
        public int personAge;

        //Konstruktory
        public Person(string name) : this(name, 0) { }

        public Person(string name, int age)
        {
            personName = name;
            personAge = age;
        }

        public Person() { }
        public void Display()
        {
            Console.WriteLine("Name: {0}, Age: {1}", personName, personAge);
        }

        
    }

    class Point
    {
        public int X { get; set; } = 1;
        public int Y { get; set; } = 12;

        public Point() :this(0, 0) { }
        public Point(int _X) : this(_X, 0) { }

        public Point(ConsoleColor cc)
        {
            Console.ForegroundColor = cc;
            Console.WriteLine("Nowy kolor");
        }

        public Point(int _X, int _Y)
        {
            X = _X;
            Y = _Y;
        }

        public void Increment()
        {
            X++; Y++;
        }

        public void Decrement()
        {
            X--; Y--;
        }

        public void Display()
        {
            Console.WriteLine("X = {0}, Y = {1}", X, Y);
        }
    }

    class Program
    {
        static void SendAPersonByValue(ref Person p)
        {
            p.personAge = 99;
            p = new Person("Nikki", 99);
        }

        static void Main(string[] args)
        {
            int ans;
            Add(90, 90, out ans);
            Console.WriteLine("90 + 90 = {0}", ans);

            Console.WriteLine("{0}", CalculateAverage(3.4, 4.5, 6.5, 1.2));

            DisplayFancyMessage(message: "Wow! Very Fancy indeed!", textColor: ConsoleColor.DarkRed, backgroundColor: ConsoleColor.White);
            DisplayFancyMessage(backgroundColor: ConsoleColor.Green, message: "Testing...", textColor: ConsoleColor.DarkBlue);

            Console.WriteLine();
            //PascalTriangle(30);
            string[] a = { "a", "b", "c", "d" };
            Array.Reverse(a);
            Array.Clear(a, 1, a.Length - 1);
            foreach(string val in a)
                Console.WriteLine(val + " ");

            EmpType emp = EmpType.Contractor;
            Array empData = Enum.GetValues(emp.GetType());
            Console.WriteLine(empData.Length);
            Console.WriteLine("{0:D}",empData.GetValue(3));

            Point myPoint = new Point(ConsoleColor.DarkGreen) { X = 2, Y = 5 };
            myPoint.Display();
            myPoint.Decrement();
            myPoint.Decrement();
            myPoint.Display();
            myPoint.Increment();

            Person fred = new Person("Fred", 12);
            fred.Display();
            SendAPersonByValue(ref fred);
            fred.Display();

            Console.ReadLine();
        }

        static void Add(int x, int y, out int ans)
        {
            ans = x + y;
        }

        public Program()
        {

        }

        public static void SwapStrings(ref string s1, ref string s2)
        {
            string tempStr = s1;
            s1 = s2;
            s2 = tempStr;
        }

        static double CalculateAverage(params double[] values)
        {
            Console.WriteLine("You sent me {0} doubles.", values.Length);
            double sum = 0;
            if (values.Length == 0)
                return sum;
            for (int i = 0; i < values.Length; i++)
                sum += values[i];
            return sum / values.Length;

        }

        static void DisplayFancyMessage(ConsoleColor textColor, ConsoleColor backgroundColor, string message)
        {
            ConsoleColor oldTextColor = Console.ForegroundColor;
            ConsoleColor oldBackgroundColor = Console.BackgroundColor;
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(message);
            Console.ForegroundColor = oldTextColor;
            Console.BackgroundColor = oldBackgroundColor;
        }

        static void PascalTriangle(int size)
        {
            if (size == 1)
            {
                Console.WriteLine("1");
                return;
            }
            else if(size == 2)
            {
                Console.WriteLine("1");
                Console.WriteLine("1 1");
                return;
            }
            long[][] pascalTriangle = new long[size][];
            for(int i = 0; i < size; i++)
            {
                pascalTriangle[i] = new long[i + 1];
                pascalTriangle[i][0] = 1;
                pascalTriangle[i][pascalTriangle[i].Length - 1] = 1;
                for(int j=1;j<pascalTriangle[i].Length - 1; j++)
                {
                    pascalTriangle[i][j] = pascalTriangle[i - 1][j - 1] + pascalTriangle[i - 1][j];
                }
            }

            for (int i = 0; i < pascalTriangle.Length; i++)
            {
                for (int j = 0; j < pascalTriangle[i].Length; j++)
                {
                    Console.Write(pascalTriangle[i][j] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
