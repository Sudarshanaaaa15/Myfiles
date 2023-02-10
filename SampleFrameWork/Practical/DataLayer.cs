using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleFrameWork.Practical;
using System.Collections;

namespace DataLayer
{
    interface IDataComponent
    {
        void AddNewCustomer(Customer cst);
        void UpdateCustomer(Customer cst);
        Customer[] GetAllCustomers();
        void DeleteCustomer(int id);
        
    }

    class CustomerDatabase : IDataComponent
    {
        private ArrayList _listOfCustomers = new ArrayList();//UR Array is replaced by ArrayList.
        public void AddNewCustomer(Customer cst)
        {
            _listOfCustomers.Add(cst);
        }

        public void DeleteCustomer(int id)
        {
            foreach (var cst in _listOfCustomers)
            {
                if (cst is Customer)
                {
                    var unBoxed = cst as Customer;
                    if(unBoxed.CustomerId == id)
                    {
                        _listOfCustomers.Remove(unBoxed);
                        return;
                    }
                }
            }
        }

        public Customer[] GetAllCustomers()
        {
            Customer[] array = new Customer[_listOfCustomers.Count];
            for (int i = 0; i < _listOfCustomers.Count; i++)
            {
                array[i] = _listOfCustomers[i] as Customer;
            }
            return array;
        }

        public void UpdateCustomer(Customer customer)
        {
            foreach (var cst in _listOfCustomers)
            {
                if (cst is Customer)
                {
                    var unBox = cst as Customer;
                    if (unBox.CustomerId == customer.CustomerId)
                    {
                        unBox.CustomerAddress = customer.CustomerAddress;
                        unBox.CustomerName = customer.CustomerName;
                        unBox.BillAmount = customer.BillAmount;
                        return;
                    }
                }
            }
            throw new Exception("Updating");
        }
    }

}
