using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfizm
{
    class Program
    {
        static void Main(string[] args)
        {
            Square s1 = new Square(10);
            Console.WriteLine(s1.Area());
            Shape s2 = new Triangle(10, 2);
            Console.WriteLine(s2.Area());
            Square s3 = new Square(-2);
            Console.WriteLine(s3.ToString());
            Console.WriteLine("Ilość wierzchołków: {0}", s3.Points);
            Console.WriteLine("Ilość wierzchołków: {0}", s1.Points);
            Circle c1 = new Circle(10);

            IPointy[] pointyObjects = { new Hexagon(10), new Square(10) };
            foreach(IPointy pointyObj in pointyObjects)
            {
                Console.WriteLine("Object {0} has: {1} elements", pointyObj.GetType().Name, pointyObj.Points);
            }

            Shape[] shapes = { new Square(3), new Circle(10), new Hexagon(3), new Circle(5), new ThreeDCircle(12) };
            foreach(Shape s in shapes)
            {
                if(s is IDraw3D)
                {
                    DrawIn3D((IDraw3D)s);
                }
                if(s is IPointy)
                {
                    Console.WriteLine(((IPointy)s).Points);
                }
                else
                    Console.WriteLine("{0} No IPointy",s.GetType().Name);
            }

            IPointy itfPt = null;
            try
            {
                itfPt = (IPointy)s1;
                Console.WriteLine(itfPt.Points);
            }
            catch(InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }

            

            if( s1 is IPointy) Console.WriteLine(s1.Points);
            else Console.WriteLine("No IPointy");

            object obj = new Square(-3);
            if (obj is Square)
                Console.WriteLine(obj.ToString());
            try
            {
                s3.Area();
            }
            catch(ShapeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.HelpLink);
                Console.WriteLine(e.StackTrace);
            }

            IPointy firstPointy = FirstPointy(shapes);
            if (firstPointy == null) Console.WriteLine("No IPointy shape");
            else Console.WriteLine("First pointy shape has {0} points.", firstPointy.Points);

            Console.ReadLine();
        }

        static IPointy FirstPointy(Shape[] shapes)
        {
            foreach (Shape s in shapes)
            {
                if (s is IPointy) return (IPointy)s;
            }
            return null;
        }

        static void DrawIn3D(IDraw3D itf3d)
        {
            itf3d.Draw3D();
        }
    }

    public abstract class Shape
    {
        abstract public double Area();
        protected double width;
    }

    class Circle : Shape
    {
        public Circle(double radius)
        {
            width = radius;
        }

        public override double Area()
        {
            return Math.PI * width * width;
        }
    }

    class Square : Shape, IPointy
    {
        public byte Points
        {
            get { return 4; }
        }

        public Square(double w)
        {
            width = w;
        }

        public override double Area()
        {
            if (width <= 0) throw new ShapeException("Invalid square width.");
            return width * width;
        }

        public override string ToString()
        {
            string result = String.Format("Bok kwadratu = {0}", width);
            return result;
        }
    }

    class Triangle : Shape, IPointy
    {
        private double height;

        public byte Points
        {
            get { return 4; }
        }

        public Triangle(double w, double h)
        {
            width = w;
            height = h;
        }

        public override double Area()
        {
            return 0.5 * width * height;
        }

       
    }

    class ThreeDCircle : Circle, IDraw3D
    {
        public ThreeDCircle(double radius) :base(radius)
        {
            
            width = radius;
        }

        public void Draw3D()
        {
            Console.WriteLine("Drawing circle in 3D");
        }

        public override double Area()
        {
            return 4 / 3 * Math.PI * Math.Pow(width, 3);
        }
    }

    class Hexagon : Shape, IPointy, IDraw3D
    {
        public Hexagon(double w)
        {

        }

        public override double Area()
        {
            return (3 * width * width * Math.Sqrt(3)) / 2;
        }

        public byte Points
        {
            get { return 6; }
        }

        public void Draw3D()
        {
            Console.WriteLine("Drawing hexagon in 3D");
        }

    }

    class PointyClassTEst : IPointy
    {
        public byte Points => throw new NotImplementedException();
    }

    [Serializable]
    public class ShapeException : Exception
    {
        public ShapeException() { }
        public ShapeException(string message) : base(message) { message = "Invalid square width."; }
        public ShapeException(string message, Exception inner) : base(message, inner) { }
        protected ShapeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    }
}
