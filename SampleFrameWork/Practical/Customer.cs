using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWork.Practical
{
    class Customer : IComparable<Customer>
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public int BillAmount { get; set; }

        public void Copy(Customer cst)
        {
            CustomerId = cst.CustomerId;
            CustomerName = cst.CustomerName;
            CustomerAddress = cst.CustomerAddress;
            BillAmount = cst.BillAmount;
        }
        public override int GetHashCode()
        {
            return CustomerId.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Customer)
            {
                var unBox = obj as Customer;
                if (CustomerId == unBox.CustomerId && CustomerName == unBox.CustomerName && CustomerAddress == unBox.CustomerAddress)
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            // return $"Name: {CustomerName} from {CustomerAddress} with Bill Amount:{BillAmount
            return ($"{CustomerId},{CustomerName},{CustomerAddress},{BillAmount}\n");
        }
        public int CompareTo(Customer other)
        {
            return CustomerName.CompareTo(other.CustomerName);
        }

    }
    enum Criteria
    {
        ID,Name,Address,Bill
    }
    class CustomerComparer : IComparer<Customer>
    {
        private Criteria criteria;
        public CustomerComparer(Criteria criteria)
        {
            this.criteria = criteria;
        }
        public int Compare(Customer x, Customer y)
        {
            switch (criteria)
            {
                
                case Criteria.ID:
                    return x.CustomerId.CompareTo(y.CustomerId);
                    
                case Criteria.Name:
                    return x.CustomerName.CompareTo(y.CustomerName);
                    
                case Criteria.Address:
                    return x.CustomerAddress.CompareTo(y.CustomerAddress);
                    
                case Criteria.Bill:
                    return x.BillAmount.CompareTo(y.BillAmount);
                    
               
            }
            return 0;
        }
    }

}
