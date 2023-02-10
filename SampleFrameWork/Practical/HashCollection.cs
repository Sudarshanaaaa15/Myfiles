using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWork.Practical
{
    class HashCollection
    {
        HashSet<Customer> customers = new HashSet<Customer>();
        public void AddNewCustomer(Customer cst)
        {
            customers.Add(cst);
        }
        public HashSet<Customer> AllCustomers => customers;
    }
}
