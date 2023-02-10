using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Utilities
    {

            internal static string Prompt(string question)
            {
                Console.WriteLine(question);
                return Console.ReadLine();
            }

            internal static int GetNumber(string question)
            {
                return int.Parse(Prompt(question));
            }
        internal static string GetValue(string question)
        {
            return (GetValue(question));
        }



    }
}
