using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWork
{
    delegate int MainOperation(int v1,int v2);
    class Math
    {
        public static void SubOperation(MainOperation main)
        {
            var v1 = int.Parse(Utilities.Prompt("Enter the first value"));
            var v2 = int.Parse(Utilities.Prompt("Enter the second value"));
            var output = main(v1, v2);
            //Console.WriteLine("The sum is " + output);
            Console.WriteLine("The subtracted value is " + output);
            //Console.WriteLine("The product is " + output);
        }
    }
    class Delegates
    {
        static int sum(int a,int b)
        {
            return a + b;
        }
        static void Main(string[] args)
        {
            //Math.SubOperation(new MainOperation(sum));
            Math.SubOperation(delegate (int b, int a)
            {
                return b - a;
            });
            //Math.SubOperation((a, b) => a * b);
        }
    }
}
