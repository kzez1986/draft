using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypyGeneryczne
{
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

    class SortByArea : IComparer<Rectangle>
    {
        public int Compare(Rectangle r1, Rectangle r2)
        {
            if (r1.Area() > r2.Area()) return 1;
            if (r1.Area() < r2.Area()) return -1;
            else return 0;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Rectangle> rSet = new List<Rectangle>();
            rSet.Add(new Rectangle(3, 4));
            rSet.Add(new Rectangle(4, 5));
            rSet.Add(new Rectangle(1, 2));
            rSet.Add(new Rectangle(7, 8));

            foreach(Rectangle element in rSet)
            {
                Console.WriteLine(element.Area().ToString());
            }

            Console.WriteLine("");
            rSet.Sort();

            foreach(Rectangle element in rSet)
            {
                Console.WriteLine(element.Area().ToString());
            }

            Console.WriteLine("");

            Stack<int> stack1 = new Stack<int>();
            stack1.Push(12);
            Console.WriteLine(stack1.Peek());
            if(stack1.Count > 0)
                Console.WriteLine(stack1.Peek());

            Queue<string>  queue1 = new Queue<string>();
            List<int> list1 = new List<int> { 1, 2, 3, 4 };

            queue1.Enqueue("a");

            Console.WriteLine("");
            SortedSet<Rectangle> ssr = new SortedSet<Rectangle>
            {
                new Rectangle(1, 2),
                new Rectangle(10, 12),
                new Rectangle(8, 6),
                new Rectangle(3, 4),
                new Rectangle(5, 7)
            };

            foreach(Rectangle element in ssr)
            {
                Console.WriteLine(element.Area().ToString());
            }

            Console.WriteLine("");

            Dictionary<int, Rectangle> dzialki = new Dictionary<int, Rectangle>()
            {
                [1] = new Rectangle(1, 4),
                [2] = new Rectangle { a = 12, b = 22 },
                [3] = new Rectangle { a = 7, b = 5},
                [4] = new Rectangle { a = 23, b = 4}
            };

            Console.WriteLine(dzialki[4].Area().ToString());

            ObservableCollection<Rectangle> rectSet = new ObservableCollection<Rectangle>()
            {
                new Rectangle(4 ,5),
                new Rectangle(7, 18),
                new Rectangle(11, 44),
                new Rectangle(4, 5)
            };

            rectSet.CollectionChanged += rectSet_CollectionChanged;

            rectSet.Add(new Rectangle(10, 20));
            rectSet.RemoveAt(2);
            Console.WriteLine(rectSet.ElementAt(1).Area().ToString());

            Console.ReadLine();
        }

        static void rectSet_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Usunięto:");
                foreach(Rectangle r in e.OldItems)
                {
                    Console.WriteLine(r.ToString());
                }
            }
            if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Dodano:");
                foreach(Rectangle r in e.NewItems)
                {
                    Console.WriteLine(r.ToString());
                }
            }
        }
    }
}
