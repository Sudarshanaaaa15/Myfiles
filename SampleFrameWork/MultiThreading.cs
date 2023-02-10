using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleFrameWork
{
    class MultiThreading
    {
        static void LargeFunction()
        {
            Console.WriteLine("The large function has been started");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("The large function is doing a job...!");
            }
            Console.Clear();
            Console.WriteLine("The large function has been ended");
        }
        static void Main(string[] args)
        {
            ThreadStart thread = new ThreadStart(LargeFunction);
            Thread t1 = new Thread(thread);
            t1.Start();
            Console.WriteLine("The main mehod has been started");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("The main method is doing a job...!");
            }
           
            Console.WriteLine("The main method has been ended");
        }
    }
}
