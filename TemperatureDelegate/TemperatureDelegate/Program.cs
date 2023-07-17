using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureDelegate
{
    public delegate void MyGenericDelegate<T>(T arg);

    public class Temperatura
    {
        public int MaksymalnaTemperatura { get; set; } = 35;
        public int AktualnaTemperatura { get; set; }
        public int MinimalnaTemperatura { get; set; } = 10;
        public string Komunikat { get; set; }

        private bool PoprawnaTemperatura;

        public Temperatura() { }
        public Temperatura(int _max, int _min, int _cur)
        {
            AktualnaTemperatura = _cur;
            MaksymalnaTemperatura = _max;
            MinimalnaTemperatura = _min;
            PoprawnaTemperatura = true;
        }

        public delegate void TemperatureHandler(string msg);

        private TemperatureHandler listOfHandlers;
        public void RejestrujTemperature(TemperatureHandler wywolywacz)
        {
            listOfHandlers += wywolywacz;
        }

        public void WyrejestrujElement(TemperatureHandler method)
        {
            listOfHandlers -= method;
        }

        public void Podgrzej(int ile)
        {
            if (!PoprawnaTemperatura)
            {
                if (listOfHandlers != null)
                    listOfHandlers("Temperatura niepoprawna");
            }
            else
            {
                AktualnaTemperatura += ile;
                if ((MaksymalnaTemperatura - AktualnaTemperatura <= 3 || AktualnaTemperatura - MinimalnaTemperatura <= 3)
                    && listOfHandlers != null)
                    listOfHandlers("UWAGA! Niebezpieczna temperatura");
                if (AktualnaTemperatura > MaksymalnaTemperatura || AktualnaTemperatura < MinimalnaTemperatura)
                    PoprawnaTemperatura = false;
                else
                    Console.WriteLine("Aktualna temperatura: {0}", AktualnaTemperatura.ToString());
            }
                
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Temperatura t1 = new Temperatura(30, 5, 15);
            t1.RejestrujTemperature(new Temperatura.TemperatureHandler(OnTemperatureEvent));
            Temperatura.TemperatureHandler handler2 = new Temperatura.TemperatureHandler(OnTemperatureEvent2);
            t1.RejestrujTemperature(OnTemperatureEvent2);
            Console.WriteLine("Podgrzewanie");
            for (int i = 0; i < 6; i++)
                t1.Podgrzej(5);
            t1.WyrejestrujElement(handler2);
            for (int i = 0; i < 6; i++)
            {
                t1.Podgrzej(-10);
            }

            MyGenericDelegate<string> mg = new MyGenericDelegate<string>(StringFunc);
            StringFunc("String example");

            MyGenericDelegate<int> mgi = new MyGenericDelegate<int>(IntFunc);
            IntFunc(100);

            Console.ReadLine();

        }

        public static void OnTemperatureEvent(string msg)
        {
            Console.WriteLine("Informacja od obiektu temperatura:");
            Console.WriteLine(msg);
        }

        public static void OnTemperatureEvent2(string msg)
        {
            Console.WriteLine("=> {0}", msg.ToUpper());
        }

        public static void StringFunc(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void IntFunc(int msg)
        {
            Console.WriteLine(msg.ToString());
        }
    }
}
