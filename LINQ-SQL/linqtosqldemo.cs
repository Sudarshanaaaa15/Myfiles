using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleData.LINQ_SQL
{
    class linqtosqldemo
    {
        static void Main(string[] args)
        {
            //readingRecords();
            var record = new tlEmployee
            {
                EmpName = "Ram",
                EmpAddress = "Ramnagar",
                EmpSalary = 20000,
                DeptID = 3
            };
            //addRecord(record);
            //updaterecord(5026,"ramesh arvind","bangalore",50000,2);
            deleteRecord(5025);
        }

        private static void deleteRecord(int empid)
        {
            var context = new linqtosqlDemoDataContext();
            var emplist = (from emp in context.tlEmployees where emp.EmpId == empid select emp).FirstOrDefault();
            context.tlEmployees.DeleteOnSubmit(emplist);
            context.SubmitChanges();

        }

        private static void updaterecord(int id,string name,string address,int salary,int deptid)
        {
            var context = new linqtosqlDemoDataContext();
            var emplist = (from emp in context.tlEmployees where emp.EmpId == id select emp).FirstOrDefault();
            if (emplist == null)
            {
                throw new Exception("No emp found to update");
            }
            emplist.EmpName = name;
            emplist.EmpAddress = address;
            emplist.EmpSalary = salary;
            emplist.DeptID = deptid;
            context.SubmitChanges();
        }

        private static void readingRecords()
        {
            var context = new linqtosqlDemoDataContext();
            var emplist = from emp in context.tlEmployees
                          select emp;
            foreach (var emp in emplist)
            {
                Console.WriteLine(emp.EmpName + "works in" + emp.tlDept.DeptName);
            }
        }
        private static void addRecord(tlEmployee record)
        {
            var context = new linqtosqlDemoDataContext();

            context.tlEmployees.InsertOnSubmit(record);
            context.SubmitChanges();
        }
    }
}
