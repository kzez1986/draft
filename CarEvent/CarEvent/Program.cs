using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvent
{
    public class CarEventsArgs : EventArgs
    {
        public readonly string msg;
        public CarEventsArgs(string message)
        {
            msg = message;
        }
    }

    public class Car
    {
        public delegate void CarEngineHandler(object sender, CarEventsArgs e);

        public event EventHandler<CarEventsArgs> Exploded;
        public event EventHandler<CarEventsArgs> AboutToBlow;

        bool carIsDead;
        int CurrentSpeed, MaxSpeed;
        public string name { get; set; }

        public Car(int ms, int cs, string n)
        {
            carIsDead = false;
            MaxSpeed = ms;
            CurrentSpeed = cs;
            name = n;
        }

        public void Accelerate(int delta)
        {
            

            if (carIsDead)
            {
                
                    Exploded?.Invoke(this, new CarEventsArgs("Sorry, this car is dead..."));
                
            }
            else
            {
                CurrentSpeed += delta;

                //Prawie niesprawny?
                if (10 == MaxSpeed - CurrentSpeed)
                {
                    AboutToBlow?.Invoke(this,new CarEventsArgs("Careful!"));
                }

                //OK
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car(200, 90, "Samochodzik");
            //Car. d = new Car.CarEngineHangler
            car1.AboutToBlow += AlmostDoomed;
            car1.AboutToBlow += NearlyBlow;
            //car1.Exploded += Exploded;
            //car1.Exploded += Car1_Exploded;

            EventHandler<CarEventsArgs> d = new EventHandler<CarEventsArgs>(Exploded);
            car1.Exploded += d;

            car1.Accelerate(20);
            car1.Accelerate(-10);
            car1.Accelerate(40);
            car1.Accelerate(10);
            car1.Accelerate(20);
            car1.Accelerate(20);
            car1.Accelerate(10);
            car1.Accelerate(40);
            Console.ReadLine();
        }

        private static void Car1_Exploded(object sender, CarEventsArgs e)
        {
            Console.WriteLine("------ Automated -------");
        }

        public static void NearlyBlow(object sender, CarEventsArgs e)
        {
            if (sender is Car)
            {
                Car c = (Car)sender;
                Console.WriteLine("{0} {1}", c.name, e.msg);
            }
        }

        public static void AlmostDoomed(object sender, CarEventsArgs e)
        {
            Console.WriteLine("Critical message: {0} {1}", sender, e.msg);
        }

        public static void Exploded(object sender, CarEventsArgs e)
        {
            Console.WriteLine("{0} {1}", sender, e.msg);
        }
    }
}
