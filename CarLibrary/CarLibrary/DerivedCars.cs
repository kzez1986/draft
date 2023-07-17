using System;
using System.Collections.Generic;
using System.Text;


namespace CarLibrary
{
    public class SportsCar : Car
    {
        public SportsCar() { }
        public SportsCar(string name, int maxSp, int currSp)
            : base(name, maxSp, currSp) { }

        public override void TurboBoost()
        {
            Console.WriteLine("Ramming speed!", "Faster is better...");
        }
    }

    public class MiniVan : Car
    {
        public MiniVan() { }
        public MiniVan(string name, int maxSp, int currSp)
        : base(name, maxSp, currSp) { }

        public override void TurboBoost()
        {
            engState = EngineState.engineDead;
            Console.WriteLine("Eek!", "Your engine block exploded!");
        }
    }
    class DerivedCars
    {
    }
}
