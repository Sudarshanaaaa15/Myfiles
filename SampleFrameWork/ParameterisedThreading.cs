using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleFrameWork
{
    class ParameterisedThreading
    {
        static void LargeFuncWithParmeters(object data)
        {
            //here data is the argument of type object.
            string file = data.ToString();
            var contents = File.ReadAllLines(file);
            foreach (var lines in contents)
            {
                Thread.Sleep(100);
                foreach (var ch in lines.ToCharArray())
                {
                    Console.Write(ch);
                    Thread.Sleep(100);
                }
                Console.WriteLine();
            }
            Console.WriteLine("The file reading is completed");
        }
        static void ParameterisedThreadOper()
        {
            ParameterizedThreadStart threadStart = new ParameterizedThreadStart(LargeFuncWithParmeters);
            Thread the = new Thread(threadStart);
            the.IsBackground = true;
            the.Start("../../Names.csv");
            the.Join();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Main is started");
            ParameterisedThreadOper();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main is doing some job");
                Thread.Sleep(100);
            }
            Console.WriteLine("The main has ended , application will terminate");
        }
    }
}
