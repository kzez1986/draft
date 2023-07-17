using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Losowanie
{
    class Program
    {
        static void Main(string[] args)
        {
            Random los = new Random();
            int liczba_losowa = 0;
            int max = 0;
            int licznik = 0;
            //liczba_losowa = los.Next(450);
            List<int> lista_licznikow = new List<int>();
            
            for (int i = 0; i < 1000; i++)
            {
                while (liczba_losowa != 1)
                {
                    liczba_losowa = los.Next(20);
                    licznik++;
                }
                if (max < licznik) max = licznik;
                licznik = 0;
                liczba_losowa = 0;
            }
            //for (int i = 0; i < lista_licznikow.Count; i++) Console.WriteLine(lista_licznikow.ElementAt(i));
            Console.WriteLine(max);
            
            Console.ReadLine();
        }
    }
}
