using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWork
{ 
    class HashTable
    {
        static void Main(string[] args)
        {
            arrayListExample();
        }
        private static void arrayListExample()
        {
            HashTable hashTable = new HashTable();
            hashTable.add("hire", "ex123");
            hashTable["hire"] = "hire123";
            foreach (DictionaryEntry pair in hashTable)
            {
                Console.WriteLine("{0}-{1}", pair.Key,pair.Value);
            }
        }
    }
}
