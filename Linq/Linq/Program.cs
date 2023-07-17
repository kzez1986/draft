using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    static class ExtendedString
    {
        public static string StrangeFunction(this String i)
        {
            i = i + "wee";
            return i;
        }
    }

    class Program
    {
        static public void QueryOverStrings()
        {
            string[] zwierzeta = { "Pies", "Kot", "Kura", "Małpa", "Krowa", "Kanarek", "Mors", "Pingwin" };
            IEnumerable<string> subset = from g in zwierzeta where g.Contains("a") orderby g select g;

            foreach (string s in subset)
            {
                Console.WriteLine("Item: {0}", s);
                
            }

            Console.WriteLine(subset.GetType().Name);
            Console.WriteLine(subset.GetType().Assembly.GetName().Name);

        }

        public class Car
        {
            public string PetName { get; set; } = "";
            public string Color { get; set; } = "";
            public int Speed { get; set; }
            public string Make { get; set; } = "";

        }

        static void Main(string[] args)
        {
            QueryOverStrings();

            List<int> nums = new List<int> { 1, 22, 3, 5, 12, 3, 44};
            List<int> numsGreaterThan10 = (from i in nums where i > 10 orderby i select i).ToList();
            foreach (int item in numsGreaterThan10)
            {
                Console.WriteLine(item);
            }
            IEnumerable<int> numsLessThan10 = from i in nums where i < 10 orderby i select i;
            foreach (var item in numsLessThan10)
            {
                Console.WriteLine(item);
            }

            nums.Add(2);
            Console.WriteLine();

            foreach (var item in numsLessThan10)
            {
                Console.WriteLine(item);
            }

            string a = "";
            a = a.StrangeFunction();
            Console.WriteLine(a);

            List<Car> cars = new List<Car>()
            {
                new Car{PetName = "Mickey", Color = "Red", Speed = 100, Make = "Fiat"},
                new Car{PetName = "Hunk", Color = "Blue", Speed = 120, Make = "Mercedes"},
                new Car{PetName = "Bibi", Color = "Green", Speed = 95, Make = "Renault"},
                new Car{PetName = "Koko", Color = "Black", Speed = 130, Make = "Voltsvagen"}
            };

            ArrayList myCars = new ArrayList()
            {
                new Car{PetName = "Mickey", Color = "Red", Speed = 100, Make = "Fiat"},
                new Car{PetName = "Hunk", Color = "Blue", Speed = 120, Make = "Mercedes"},
                new Car{PetName = "Bibi", Color = "Green", Speed = 95, Make = "Renault"},
                new Car{PetName = "Koko", Color = "Black", Speed = 130, Make = "Voltsvagen"}
            };

            var myCarsEnum = myCars.OfType<Car>();
            var fastestCar = from c in myCarsEnum where c.Speed > 100 select c;


            Console.WriteLine();

            foreach (var item in fastestCar)
            {
                Console.WriteLine(item.PetName);
            }

            Console.WriteLine();

            GetFastCar(cars);

            ArrayList ar = new ArrayList { 1, "string", new Car(), 12, 44 };
            var ints = ar.OfType<int>();

            foreach (var item in ints)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        public static void GetFastCar(List<Car> cars)
        {
            var fastertCars = from c in cars where c.Speed >= 100 && c.Speed < 125 select c;

            foreach (var item in fastertCars)
            {
                Console.WriteLine(item.PetName);
            }
        }
    }
}
