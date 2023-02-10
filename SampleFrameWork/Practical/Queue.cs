using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SampleFrameWork.Practical
{
    class Queue
    {
        private Queue<string> _RecentItems = new Queue<string>();

        public void ViewItem(string str)
        {
            if (_RecentItems.Count == 3)
                _RecentItems.Dequeue();
            _RecentItems.Enqueue(str);
            
                Console.WriteLine(str);
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("The recent viewed items:");

                var store = _RecentItems.Reverse();
                foreach (var item in store)
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine(item);
                    Console.WriteLine("---------------------");

                }
            
        }
    }
    class MainUsage
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();
            do
            {
                var input = Utilities.Prompt("Enter the item you want to see");
                queue.ViewItem(input);
            } while (true);
        }
    }
}
