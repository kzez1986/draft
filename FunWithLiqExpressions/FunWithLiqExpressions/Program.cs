using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithLiqExpressions
{
    class ProductInfo
    {
        public string Name { get; set; } = "";
        public string Desription { get; set; } = "";
        public int NumberInStock { get; set; } = 0;

        public override string ToString()
        {
            return "Name: " + Name + " Description: " + Desription + " Numbers in stock: " + NumberInStock;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ProductInfo[] pi = new[]
            {
                new ProductInfo{Name = "Książki", Desription = "Najnowsza encyklopedia", NumberInStock=12},
                new ProductInfo{Name = "Filiżanka", Desription = "Filiżanka do kawy", NumberInStock=200},
                new ProductInfo{Name = "Kawa", Desription="Kawa ekspresowa", NumberInStock=150},
                new ProductInfo{Name = "Herbata", Desription="Zapachowa", NumberInStock=90},
                new ProductInfo{Name = "Klawiatura", Desription="Klawiatura do komputera", NumberInStock=30},
                new ProductInfo{Name = "Mysz", Desription="Mysz komputerowa", NumberInStock=340}
            };

            var subset = from p in pi orderby p.NumberInStock descending select new { p.Name, p.Desription, p.NumberInStock };
            foreach (var item in subset)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();

            Array objs = ProjectedSubset(pi);
            foreach (object o in objs)
            {
                Console.WriteLine(o);
            }

            int subset_count = (from p in pi select p).Count();
            Console.WriteLine(subset_count);

            List<int> num1 = new List<int> { 1, 2, 3, 4, 5 };
            List<int> num2 = new List<int> { 1, 2, 3, 5, 6, 7 };

            Console.WriteLine();

            var int_result = (from n in num1 select n).Concat(from n in num2 select n);
            foreach (var item in int_result.Distinct())
            {
                Console.WriteLine(item);
            }

            int subset_max = (from m in num2 select m).Max();
            Console.WriteLine("Max: {0}", subset_max);

            int subset_min = (from m in num2 select m).Min();
            Console.WriteLine("Min: {0}", subset_min);

            int sum = (from m in num2 select m).Sum();
            Console.WriteLine("Suma: {0}", sum);

            double avg = (from m in num2 select m).Average();
            Console.WriteLine("Średnia: {0}", avg);

            QuesryStringsWithEnumerableAndLambdas();
            Console.WriteLine();
            QueryStringWithAnonymousMethods();

            Console.WriteLine();
            ComplexQuery.QueryRawDelegates();

            Console.ReadLine();
        }

        static Array ProjectedSubset(ProductInfo[] pr)
        {
            var result = from p in pr select new { p.Name, p.Desription };
            return result.ToArray();
        }

        static void QueryStringWithAnonymousMethods()
        {
            Console.WriteLine("Anonymou Methods");
            List<int> l_Num = new List<int> { 1, -100, 23, 400, 10, 0, -10, 40, 50 };
            Func<int, bool> filter = delegate (int number) { return number > 10; };
            Func<int, int> item = delegate (int s) { return s; };
            var subset = l_Num.Where(filter).OrderBy(item).Select(item);
            foreach (var item_N in subset)
            {
                Console.WriteLine(item_N);
            }
        }

        static void QuesryStringsWithEnumerableAndLambdas()
        {
            Console.WriteLine("Enumerable / Lambda expressions");
            List<int> nums = new List<int> { 1, 23, 200, 2, -5 };
            var subset = nums.Where(n => n < 10).OrderBy(n => n).Select(g => g);
            foreach (var item in subset)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

        }

        class ComplexQuery
        {
            public static bool Filter(int n) { return n > 0; }
            public static int ItemProcess(int n) { return n; }


            public static void QueryRawDelegates() {
                List<int> nums = new List<int> { 1, -10, 22, 33, 100, -30, -40, 0, -1 };
                
                Func<int, bool> searchFilter = new Func<int, bool>(Filter);
                Func<int, int> itemToProcess = new Func<int, int>(ItemProcess);

                var subset = nums.Where(Filter).OrderBy(ItemProcess).Select(ItemProcess);

                foreach (var item in subset)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
