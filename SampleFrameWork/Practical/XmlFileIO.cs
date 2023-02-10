using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace SampleFrameWork.Practical
{
    class XmlFileIO
    {
        static Customer[] getAllCustomers(string fileName)
        {
            List<Customer> allCustomers = new List<Customer>();
            var allLines = File.ReadAllLines(fileName);
            foreach (var line in allLines)
            {
                var words = line.Split(',');
                Customer cst = new Customer();
                cst.CustomerId = int.Parse(words[0]);
                cst.CustomerName = words[1];
                cst.CustomerAddress = words[2];
                cst.BillAmount = int.Parse(words[3]);
                allCustomers.Add(cst);
            }
            return allCustomers.ToArray();
        }

        static void writeToxml(Customer[] data, string fileName)
        {
            DataTable table = new DataTable("Customer");
            table.Columns.Add("CustomerId", typeof(int));
            table.Columns.Add("CustomerName", typeof(string));
            table.Columns.Add("CustomerAddress", typeof(string));
            table.Columns.Add("BillAmount", typeof(int));
            //Populate the data into the Table....
            foreach (var cst in data)
            {
                DataRow row = table.NewRow();
                row[0] = cst.CustomerId;
                row[1] = cst.CustomerName;
                row[2] = cst.CustomerAddress;
                row[3] = cst.BillAmount;
                table.Rows.Add(row);
            }
            table.AcceptChanges();
            DataSet ds = new DataSet("Customers");
            ds.Tables.Add(table);
            ds.WriteXml(fileName);

        }
        static void Main(string[] args)
        {
            var data = getAllCustomers("../../Customers.csv");
            writeToxml(data, "../../Customers.xml");
            
        }

    }
}
