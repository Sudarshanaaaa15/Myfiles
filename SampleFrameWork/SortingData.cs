using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWork
{
    using SampleFrameWork.Practical;

    class SortingData
    {
        static void Main()
        {
            //SortingOnCustomer();
            //SortingOnString();
            SortingOnMultiCriteria();
        }
        private static void SortingOnMultiCriteria()
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer
            {
                CustomerId = 1,
                CustomerName = "ramu",
                CustomerAddress = "raichur",
                BillAmount = 500,
            });

            customers.Add(new Customer
            {
                CustomerId = 2,
                CustomerName = "raju",
                CustomerAddress = "raichur",
                BillAmount = 500
            });

            customers.Add(new Customer
            {
                CustomerId = 3,
                CustomerName = "ramesh",
                CustomerAddress = "raipur",
                BillAmount = 600
            });

            customers.Add(new Customer
            {
                CustomerId = 4,
                CustomerName = "rajesh",
                CustomerAddress = "raipur",
                BillAmount = 700
            });
            customers.Add(new Customer
            {
                CustomerId = 5,
                CustomerName = "rama",
                CustomerAddress = "raipur",
                BillAmount = 800
            });
            Console.WriteLine("Enter the Criteria to Sort");
            Array values = Enum.GetValues(typeof(Criteria));
            foreach (var item in values)
            {
                Console.WriteLine(item);
            }

            Criteria selected = (Criteria)Enum.Parse(typeof(Criteria), Console.ReadLine());
            customers.Sort(new CustomerComparer(selected));
            foreach (var cst in customers)
                Console.WriteLine(cst);
        }

        public static void SortingOnCustomer()
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer
            {
                CustomerId = 1,
                CustomerName = "ramu",
                CustomerAddress = "Raichur",
                BillAmount = 500
            });
            customers.Add(new Customer
            {
                CustomerId = 2,
                CustomerName = "raju",
                CustomerAddress = "Raichur",
                BillAmount = 500
            });
            customers.Add(new Customer
            {
                CustomerId = 3,
                CustomerName = "ramesh",
                CustomerAddress = "Raipur",
                BillAmount = 600
            });
            customers.Add(new Customer
            {
                CustomerId = 4,
                CustomerName = "rajesh",
                CustomerAddress = "Raipur",
                BillAmount = 700
            });
            customers.Add(new Customer
            {
                CustomerId = 5,
                CustomerName = "rama",
                CustomerAddress = "Raipur",
                BillAmount = 800
            });


            customers.Sort();
            foreach (var cst in customers)
            {
                Console.WriteLine(cst);
            }


        }
        private static void SortingOnString()
        {
            List<string> storedData = new List<string>();
            storedData.Add("ramu");
            storedData.Add("raju");
            storedData.Add("ramesh");
            storedData.Add("rajesh");
            storedData.Add("rama");

            storedData.Sort();
            foreach (var value in storedData)
            {
                Console.WriteLine(value);
            }

        }
    }
}
