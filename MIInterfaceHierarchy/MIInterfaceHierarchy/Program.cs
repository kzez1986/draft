using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIInterfaceHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
        }


    }

    interface IDrawable
    {
        void Draw();
    }

    interface IPrintable
    {
        void Print();
        void Draw();
    }

    interface IShape : IDrawable, IPrintable
    {
        int GetNumberOfSides();
    }

    class Rectangle : IShape
    {
        public int GetNumberOfSides()
        {
            return 4;
        }

        public void Draw()
        {
            Console.WriteLine("Drawing...");
        }

        public void Print()
        {
            Console.WriteLine("Printing...");
        }
    }

    class Square : IShape
    {
        //Jawna implementacja
        void IPrintable.Draw()
        {
            // Wyślij do drukarki
        }

        void IDrawable.Draw()
        {
            // Narysuj na ekranie...
        }

        public void Print()
        {
            // Wydrukuj...
        }

        public int GetNumberOfSides()
        {
            return 4;
        }


    }
}
