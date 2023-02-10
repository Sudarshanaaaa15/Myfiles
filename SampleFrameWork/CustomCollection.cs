using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace SampleFrameWork
{
    class CustomerArray :IEnumerable
    {
        List<string> names = new List<string>();
        
        public void AddName(string name)
        {
            names.Add(name);
        }
        public void DeleteName(int index)
        {
            if(index < names.Count)
            {
                names.RemoveAt(index);
            }
            else
            {
                throw new Exception("id is not there to remove");
            }
        }
        public string this[int index]
        {
            get
            {
                return names[index];
            }
            set
            {
                if (index < names.Count)
                {
                    names[index] = value;
                }
            }
        }
        public IEnumerator GetEnumerator()
        {
            foreach (var item in names)
            {
                yield return item;
            }
        }
        public int NamesCount => names.Count;

    }
    class CustomCollection
    {
        static void Main(string[] args)
        {
            CustomerArray Array = new CustomerArray();
            Array.AddName("Rajesh");
            Array.AddName("Muragesh");
            Array.AddName("Siddu");

            for (int i = 0; i < Array.NamesCount; i++)
            {
                string old = Array[i];
                Array[i] = "Welcome to " + old;
                Console.WriteLine(Array[i]);
            }
            //foreach (string name in Array)
            //    Console.WriteLine(name);

        }

    }
}
