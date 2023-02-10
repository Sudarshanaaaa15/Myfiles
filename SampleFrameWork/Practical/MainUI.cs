using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using UtilitiesLayer;


namespace SampleFrameWork.Practical
{
    class MainUI
    {
        static IDataComponent component = null;
        static void Main(string[] args)
        {
        
            HashCollection collection = new HashCollection();
            collection.AddNewCustomer(new Customer { CustomerId = 111, CustomerName = "Phaniraj", CustomerAddress = "Bangalore", BillAmount = 5600 });
            collection.AddNewCustomer(new Customer { CustomerId = 111, CustomerName = "Phaniraj", CustomerAddress = "Bangalore", BillAmount = 5600 });
            foreach (var customer in collection.AllCustomers)
                Console.WriteLine(customer);
        }

        private static void factoryTesting()
        {
            component.AddNewCustomer(new Customer { CustomerId = 111, CustomerName = "Ramesh Adiga", CustomerAddress = "Kundapur", BillAmount = 56000 });
            component.UpdateCustomer(new Customer { CustomerId = 111, CustomerName = "Rajesh", CustomerAddress = "Karvar", BillAmount = 56000 });
            var data = component.GetAllCustomers();
            foreach (Customer customer in data)
                Console.WriteLine(customer);
            component.DeleteCustomer(111);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

    }

}
