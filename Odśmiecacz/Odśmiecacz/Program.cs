using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odśmiecacz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Przewidywana liczba bajtów na stercie {0}", GC.GetTotalMemory(false));
            Console.WriteLine("Ilość generacji: {0}", GC.MaxGeneration + 1);
            ConsoleColor cc = new ConsoleColor();
            cc = ConsoleColor.Black;
            Console.WriteLine("Generacja koloru konsoli: {0}", GC.GetGeneration(cc));

            object[] tonOdObjects = new object[50000];
            for (int i = 0; i < 50000; i++)
            {
                tonOdObjects[i] = new object();
            }

            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Generation of cc is: {0}", GC.GetGeneration(cc));
            if(tonOdObjects[9000] != null)
            {
                Console.WriteLine("Generation of tonsOfObjects[9000] is: {0}", GC.GetGeneration(tonOdObjects[9000]));
            }
            else
                Console.WriteLine("tonsOfObjects no longer alive");

            Console.WriteLine("Gen 0 swept {0} times", GC.CollectionCount(0));
            Console.WriteLine("Gen 1 swept {0} times", GC.CollectionCount(1));
            Console.WriteLine("Gen 2 swept {0} times", GC.CollectionCount(2));


            Console.ReadLine();

        }
    }
}
