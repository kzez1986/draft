using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{


    

    class Program
    {
        static void Main(string[] args)
        {
            //Wszystkie te klasy obsługują interfejs ICloneable.
            string myStr = "Hello";
            OperatingSystem unixOS = new OperatingSystem(PlatformID.Unix, new Version());
            System.Data.SqlClient.SqlConnection sqlCnn = new System.Data.SqlClient.SqlConnection();

            //Dlatego każdąz nich można przesłać do metody przyjmującej ICloneable.
            CloneMe(myStr);
            CloneMe(unixOS);
            CloneMe(sqlCnn);
            Console.ReadLine();

        }

        private static void CloneMe(ICloneable c)
        {
            //Sklonuj co tam masz, i wyświetl nazwę
            object theClone = c.Clone();
            Console.WriteLine("Your clone is a: {0}", theClone.GetType().Name);
        }
    }
}
