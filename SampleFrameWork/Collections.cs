using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SampleFrameWork
{
    class Collections
    {
        static void Main(string[] args)
        {
            ArrayList();
        }
        private static void ArrayList()
        {
            ArrayList list = new ArrayList();
            list.Add("oranges");
            list.Add("PineApples");
            list.Add("CuaturdApples");
            list.Add("Bananas");
            Console.WriteLine("No of fruits" + list.Count);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
