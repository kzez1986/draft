using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CustomEnumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            SquareSet ss = new SquareSet();

            foreach(Square sq in ss)
            {
                Console.WriteLine(sq.Length);
            }
            //Console.ReadLine();

            //IEnumerator i = ss.GetEnumerator();
            //i.MoveNext();
            //i.MoveNext();
            //Square testSquare = (Square)i.Current;
            //Console.WriteLine(testSquare.Length.ToString());
            Console.ReadLine();
        }
    }

    public class SquareSet : IEnumerable
    {
        private Square[] squareArray = new Square[4];

        public SquareSet()
        {
            squareArray[0] = new Square(4);
            squareArray[1] = new Square(15);
            squareArray[2] = new Square(3);
            squareArray[3] = new Square(7);
        }

        
        public IEnumerator GetEnumerator()
        {
            yield return squareArray[1];

            foreach (Square s in squareArray)
            {
                yield return s;
            }
        }
        
        
        /*
        IEnumerator IEnumerable.GetEnumerator()
        {
            return squareArray.GetEnumerator();
        }
        */
    }
}
