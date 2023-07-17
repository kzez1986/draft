using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CarLibrary;
using EasterEgg;
using System.Windows.Forms;

namespace CarCSharpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("C# Car Library Clint App");
            SportsCar viper = new SportsCar("Viper", 240, 40);
            viper.TurboBoost();

            MiniVan mv = new MiniVan();
            mv.TurboBoost();

            Console.WriteLine("Done. Press any key to terminate.");

            ConsoleKeyInfo k = Console.ReadKey();
            if(k.Key == ConsoleKey.F5)
                Application.Run(new ShowImage());
            
            
            

            //Console.ReadLine();
        }
    }
}
