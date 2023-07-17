using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadOperator
{
    public class VeryBigNumberMath
    {
        string bigNumber { get; set; }

        public override string ToString()
        {
            return bigNumber;
        }

        public int Length
        {
            get { return bigNumber.Length; }
        }
           
        

        public VeryBigNumberMath(string num1)
        {
            bigNumber = num1;
        }

        public static VeryBigNumberMath Add(VeryBigNumberMath bigNumberA, VeryBigNumberMath bigNumberB)
        {
            string result = "";
            int tmp_a, tmp_b, longer;
            longer = bigNumberA.Length > bigNumberB.Length ? bigNumberA.Length : bigNumberB.Length;
            byte shift = 0;

            for (int i = 1; i <= longer; i++)
            {
                if (bigNumberA.Length - i >= 0)
                    tmp_a = Int32.Parse(bigNumberA.bigNumber[bigNumberA.Length - i].ToString());
                else
                    tmp_a = 0;

                if (bigNumberB.Length - i >= 0)
                    tmp_b = Int32.Parse(bigNumberB.bigNumber[bigNumberB.Length - i].ToString());
                else
                    tmp_b = 0;

                tmp_a += tmp_b + shift;
                if (tmp_a >= 10)
                {
                    tmp_a -= 10;
                    result = result.Insert(0, tmp_a.ToString());
                    shift = 1;

                }
                else
                {
                    result = result.Insert(0, tmp_a.ToString());
                    shift = 0;
                }


            }

            if (shift == 1) result = result.Insert(0, "1");




            return new VeryBigNumberMath(result);
        }

        public static VeryBigNumberMath Increment(VeryBigNumberMath bigNumberA)
        {
            VeryBigNumberMath bigNumberB = new VeryBigNumberMath("1");

            string result = "";
            int tmp_a, tmp_b, longer;
            longer = bigNumberA.Length > bigNumberB.Length ? bigNumberA.Length : bigNumberB.Length;
            byte shift = 0;

            for (int i = 1; i <= longer; i++)
            {
                if (bigNumberA.Length - i >= 0)
                    tmp_a = Int32.Parse(bigNumberA.bigNumber[bigNumberA.Length - i].ToString());
                else
                    tmp_a = 0;

                if (bigNumberB.Length - i >= 0)
                    tmp_b = Int32.Parse(bigNumberB.bigNumber[bigNumberB.Length - i].ToString());
                else
                    tmp_b = 0;

                tmp_a += tmp_b + shift;
                if (tmp_a >= 10)
                {
                    tmp_a -= 10;
                    result = result.Insert(0, tmp_a.ToString());
                    shift = 1;

                }
                else
                {
                    result = result.Insert(0, tmp_a.ToString());
                    shift = 0;
                }


            }

            if (shift == 1) result = result.Insert(0, "1");




            return new VeryBigNumberMath(result);
        }

        public static VeryBigNumberMath operator + (VeryBigNumberMath m1, VeryBigNumberMath m2)
        {
            string addResult = Add(m1, m2).ToString();

            return new VeryBigNumberMath(addResult);
        }

        public static VeryBigNumberMath operator ++ (VeryBigNumberMath m1)
        {
            VeryBigNumberMath result = Increment(m1);
            return new VeryBigNumberMath(result.ToString());
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            VeryBigNumberMath b1 = new VeryBigNumberMath("10");
            VeryBigNumberMath b2 = new VeryBigNumberMath("9");
            b2 += b1;
            Console.WriteLine(b2.ToString());
            b2++;
            Console.WriteLine(b2.ToString());
            b2++;
            Console.WriteLine(b2.ToString());
            Console.ReadLine();
        }
    }
}
