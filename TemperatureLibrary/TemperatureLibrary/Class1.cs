using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureLibrary
{
    public enum TypPogody { mróz, zimno, chłodno, ciepło, upał}

    public abstract class Temperatura
    {
        public int AktualnaTemperatura { get; set; }

        protected TypPogody tp = TypPogody.chłodno;
        public abstract void Zmiana();
        public Temperatura() { }
        public Temperatura(int akt) { AktualnaTemperatura = akt; }

        public TypPogody TypPogody
        {
            get { return TypPogody; }
        }
    }

    public class Class1
    {
    }
}
