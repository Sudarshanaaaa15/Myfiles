using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleData.Datamodels
{
    interface IData
    {
        List<tlEmployee> GetAllEmployees();
        List<tlDept> GetAllDepts();
        void AddNewEmployee(tlEmployee emp);
        void UpadateEmployee(tlEmployee emp);
        void DeleteEmployee(int id);
    }
    class DatacomponentImpl : IData
    {
        public void AddNewEmployee(tlEmployee emp)
        {
            var context = new Entities();
            context.tlEmployees.Add(emp);
            context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var context = new Entities();
            var foundid = context.tlEmployees.FirstOrDefault((e) => e.EmpId == id);
            if (foundid == null)
                throw new Exception("Employee not found to delete");
            context.tlEmployees.Remove(foundid);
            context.SaveChanges();

        }

        public List<tlDept> GetAllDepts()
        {
            var context = new Entities();
            var deptlist = context.tlDepts.ToList();
            return deptlist;
        }

        public List<tlEmployee> GetAllEmployees()
        {
            var context = new Entities();
            var emplist = context.tlEmployees.ToList();
            return emplist;
        }

        public void UpadateEmployee(tlEmployee emp)
        {
            var context = new Entities();
            var ExistingEmp = (from data in context.tlEmployees
                               where data.EmpId == emp.EmpId
                               select data).FirstOrDefault();
            if (ExistingEmp == null)
            {
                throw new Exception("Employee not found");
            }
            ExistingEmp.EmpName = emp.EmpName;
            ExistingEmp.EmpAddress = emp.EmpAddress;
            ExistingEmp.EmpSalary = emp.EmpSalary;
            ExistingEmp.DeptID = emp.DeptID;

            context.SaveChanges();
        }
    }

    class FirstE2EEFDemo
    {
        static IData com = new DatacomponentImpl();
        static void Main(string[] args)
        {
            displayAllEmployees();
            displayAllDepts();
            addingEmployee(Utility.Prompt("EmpName"),Utility.Prompt("EmpAddress"),Utility.GetNumber("EmpSalary"),Utility.GetNumber("DeptId"));
            updatingEmployee(Utility.GetNumber("Id"),Utility.Prompt("EmpName"),Utility.Prompt("EmpAddress"),Utility.GetNumber("salary"),Utility.GetNumber("deptid"));
            deletingEmployee(Utility.GetNumber("id"));
        }

        private static void deletingEmployee(int empid)
        {
            com.DeleteEmployee(empid);
        }

        private static void updatingEmployee(int id,string name,string address,int salary,int deptid)
        {
            com.UpadateEmployee(new tlEmployee
            {
                EmpId = id,
                EmpName = name,
                EmpAddress = address,
                EmpSalary = salary,
                DeptID = deptid
            });
        }

        private static void addingEmployee(string name,string address ,int salary,int deptid)
        {
            com.AddNewEmployee(new tlEmployee
            {
                EmpName = name,
                EmpAddress = address,
                EmpSalary = salary,
                DeptID = deptid
            });
        }

        private static void displayAllDepts()
        {
            List<tlDept> depts = com.GetAllDepts();
            foreach (var dept in depts)
            {
                Console.WriteLine(dept.DeptName);
            }
        }

        private static void displayAllEmployees()
        {
            List<tlEmployee> emplist = com.GetAllEmployees();
            foreach (var employee in emplist)
            {
                Console.WriteLine($"{employee.EmpName} works in {employee.tlDept.DeptName} department");
            }
        }
    }
}
