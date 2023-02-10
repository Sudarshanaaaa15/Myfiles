using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWork.Practical
{
    class CSVFile
    {
        const string FileName = "../../customerdata.csv";
        static void Main(string[] args)
        {
            var choice = Utilities.Prompt("What do U want to do today? Add or View. Press A for adding or V for Viewing");
            if (choice.ToUpper() == "A")
                WritingFile();
            else if (choice.ToUpper() == "V")
                ReadingFile();
            else
                Console.WriteLine("Wrong Choice");
        }
        private static void ReadingFile()
        {
            List<Customer> customers = new List<Customer>();
            var allLines = File.ReadAllLines(FileName);

            foreach (var lines in allLines)
            {
                var words = lines.Split(',');
                Customer cust = new Customer();
                cust.CustomerId = int.Parse(words[0]);
                cust.CustomerName = words[1];
                cust.CustomerAddress = words[2];
                cust.BillAmount = int.Parse(words[3]);
                customers.Add(cust);
            }

            foreach (var cust in customers)
            {
                Console.WriteLine(cust.CustomerId);
                Console.WriteLine(cust.CustomerName);
            }
        }
        private static void WritingFile()
        {
            Customer cst = new Customer
            {
                CustomerId = Utilities.GetNumber("Enter the Customer ID"),
                CustomerName = Utilities.Prompt("Enter the Customer name"),
                CustomerAddress = Utilities.Prompt("Enter the Customer Address"),
                BillAmount = Utilities.GetNumber("Enter the Bill Amount")
            };
            File.AppendAllText(FileName, cst.ToString());
        }


    }

}
