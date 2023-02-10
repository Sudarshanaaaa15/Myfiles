using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWork
{
    class SoretdDictionary
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, long> ContactNos = new SortedDictionary<string, long>();
            ContactNos.Add("Rajesh", 9902258741);
            ContactNos.Add("Ramesh", 9902253741);
            ContactNos.Add("Rakesh", 9902257741);
            ContactNos.Add("Ranjith", 9902238741);
            ContactNos.Add("Ravi", 9902258941);
            ContactNos.Add("Ravikiran", 9802258741);
            ContactNos.Add("Ramu", 9202258741);
            foreach (var item in ContactNos)
            {
                Console.WriteLine(item.Key, item.Value);
                //Console.WriteLine(item.Value);
            }
        }
    }
}
