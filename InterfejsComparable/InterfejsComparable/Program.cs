using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace InterfejsComparable
{
    class Program
    {
        static void Main(string[] args)
        {
            Point[] points = new Point[10];
            Random los = new Random();
            for(int i=0;i<points.Length;i++)
            {
                points[i] = new Point(los.Next(10), los.Next(10), "punkt" + los.Next(10).ToString());
                Console.WriteLine(points[i].ToString());
            }
            Console.WriteLine("");
            Console.WriteLine("Posortowane:");
            Array.Sort(points, Point.SortByPointName);
            foreach(Point element in points)
            {
                Console.WriteLine(element.ToString());
            }
            Console.ReadLine();
        }
       
    }

    class Point : IComparable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; set; }

        public Point(int _x, int _y, string _name)
        {
            X = _x;
            Y = _y;
            Name = _name;
        }

        public override string ToString()
        {
            return Name + " " + X.ToString() + " " + Y.ToString();
        }

        int IComparable.CompareTo(object obj)
        {
            Point tmp = obj as Point;
            if (tmp != null)
            {
                return (tmp.X + tmp.Y).CompareTo(this.X + this.Y);
            }
            else
                throw new ArgumentException("To nie Punkt!");
        }

        public static IComparer SortByPointName
        {
            get
            {
                return (IComparer)new PointNameComparer();
            }
        }
    }

    class PointNameComparer : IComparer
    {
        int IComparer.Compare(object obj1, object obj2)
        {
            Point p1 = obj1 as Point;
            Point p2 = obj2 as Point;

            if (p1 != null && p2 != null)
            {
                return String.Compare(p1.Name, p2.Name);
            }
            else
                throw new ArgumentException("To nie jest Point!");
        }
    }
}
