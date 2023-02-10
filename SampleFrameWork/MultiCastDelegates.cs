using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWork
{
    delegate int Mainoperation(int a1, int a2);

    class Maths
    {
        public static void Suboperation(Mainoperation mainoperation)
        {
            var a1 = int.Parse(Utilities.Prompt("Enter the first value"));
            var a2 = int.Parse(Utilities.Prompt("Enter the second value"));
            Delegate[] output = mainoperation.GetInvocationList();
            foreach (Delegate item in output)
            {

                //Console.WriteLine(item);
                //Console.WriteLine(item.Method.Name);
                //Console.WriteLine("The Result are: ");
                Console.WriteLine("The Result are: "  + item.DynamicInvoke(a1, a2));


            }
        }
    }
    class MultiCastDelegates
    {
        //static int sum(int a, int b)
        //{
        //    return a + b;
        //}

        static void Main(string[] args)
        {
            Mainoperation Operations = new Mainoperation(delegate (int a, int b)
            {
                return a + b;
            });
            Operations += new Mainoperation(delegate (int a, int b)
            {
                return a - b;
            });
            Operations += new Mainoperation(delegate (int a, int b)
            {
                return a * b;
            });
            Operations += new Mainoperation(delegate (int a, int b)
            {
                return a / b;
            });
            Maths.Suboperation(Operations);
        }
    }
}
