using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wskazniki
{
    unsafe struct Point
    {
        public int x;
        public int y;
        

        public override string ToString()
        {
            return "X: " + x + " Y: " + y;
        }
    }

    class PointerType
    {
        public String tekst;
        public int num;
        public char znaki;
    }

    class Program
    {
        unsafe static void Main(string[] args)
        {

            int number = 10;
            SquareIntPointer(&number);
            Console.WriteLine(number);

            int number2 = 8;
            SquareIntPointer(&number2);
            Console.WriteLine(number2);

            int n;
            int* num = &n;
            *num = 100;

            Console.WriteLine("n: {0}", n);
            Console.WriteLine("Adres: {0}", (int)&num);

            int a = 10;
            int b = 20;

            Console.WriteLine("{0} {1}", a, b);
            Swap(&a, &b);
            Console.WriteLine("{0} {1}", a, b);

            Point point;
            Point* p = &point;
            Console.WriteLine("Size of Point is: {0}",sizeof(Point));
            p->x = 100;
            p->y = 50;
            Console.WriteLine(p->ToString());

            Point point2;
            Point* p2 = &point2;
            (*p2).x = 10;
            (*p2).y = 20;
            Console.WriteLine((*p2).ToString());

            int* linia = UnsafeStackAlloc();
            Console.WriteLine((linia[2560]).ToString());

            PointerType pt = new PointerType();
            pt.num = 100;
            pt.tekst = "Tekst";

            fixed(char* charptr = &pt.znaki)
            {
                *charptr = 'a';

            }

            Console.WriteLine(pt.num);

            Console.ReadLine();
        }

        unsafe static void SquareIntPointer(int* myIntPointer)
        {
            *myIntPointer *= *myIntPointer;
        }

        unsafe static void Swap(int* n1, int* n2)
        {
            int temp = *n1;
            *n1 = *n2;
            *n2 = temp;
        }

        unsafe static int* UnsafeStackAlloc()
        {
            int* p = stackalloc int[256];
            for (int i = 0; i < 256; i++)
            {
                p[i] = i;
            }
            return p;
        }
    }
}
