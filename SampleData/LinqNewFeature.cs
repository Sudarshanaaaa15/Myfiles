using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleData
{
    //class Employee
    //{
    //    public int EmpId { get; set; }
    //    public string EmpName { get; set; }
    //    public string EmpCity { get; set; }
    //    public string EmpContact { get; set; }
    //    public int EmpSalary { get; set; }
    //}
    //static class Data
    //{
    //    const string FileName = "EmployeeData.csv";

    //    private static List<Employee> getAll()
    //    {
    //        var list = new List<Employee>();
    //        var lines = File.ReadAllLines(FileName);
    //        int no = 2000;
    //        foreach (var line in lines)
    //        {
    //            no++;
    //            var words = line.Split(',');
    //            var newEmp = new Employee
    //            {
    //                EmpId = no,
    //                EmpCity = words[1],
    //                EmpContact = words[2],
    //                EmpName = words[0],
    //                EmpSalary = int.Parse(words[3])
    //            };
    //            list.Add(newEmp);
    //        }
    //        return list;
    //    }
    //    public static List<Employee> AllRecords => getAll();

    //}
    //class Linq
    //{
    //    static void Main()
    //    {
    //        //displayAllNames();
    //        //displayNamesandAddress();
    //        //displayNamesFromCity("Banglore");
    //        // displayNameswithSalaryGreaterThan(30000);
    //        //displayNamesOrderByName();
    //        displayUniqueCity();
    //    }

    //    private static void displayUniqueCity()
    //    {
    //        var allData = Data.AllRecords;
    //        var query = from rec in allData select rec.EmpCity.Distinct();
    //        foreach (var city in query)
    //        {
    //            Console.WriteLine(city);
    //        }
    //    }

    //    private static void displayNamesOrderByName()
    //    {
    //        var allData = Data.AllRecords;
    //        var query = from rec in allData orderby rec.EmpName descending select new { NAME = rec.EmpName };
    //        foreach (var records in query)
    //        {
    //            Console.WriteLine($"{records.NAME}");
    //        }

    //    }

    //    private static void displayNameswithSalaryGreaterThan(int salary)
    //    {
    //        var Alldata = Data.AllRecords;
    //        var query = from rec in Alldata where rec.EmpSalary >= salary && rec.EmpName.StartsWith("A") select new { NAME = rec.EmpName, SALARY= rec.EmpSalary };
    //        foreach (var records in query)
    //        {
    //            Console.WriteLine($"{records.NAME} from {records.SALARY}");
    //        }
    //    }

    //    private static void displayNamesFromCity(string city)
    //    {
    //        var data = Data.AllRecords;
    //        var Query = from rec in data
    //                    where rec.EmpCity == city
    //                    select rec.EmpName;
    //        foreach (var name in Query)
    //        {
    //            Console.WriteLine(name);
    //        }
    //    }

    //    private static void displayNamesandAddress()
    //    {
    //        var data = Data.AllRecords;
    //        var Query = from rec in data
    //                        select new { Name = rec.EmpName, City = rec.EmpCity };
    //        foreach (var item in Query)
    //        {
    //            Console.WriteLine($"{item.Name} from {item.City}");
    //        }
    //    }

    //    private static void displayAllNames()
    //    {
    //        var data = Data.AllRecords;
    //        var linqQuery = from emp in data
    //                    select emp.EmpName;
    //        foreach (var name in linqQuery)
    //            Console.WriteLine(name);
    //    }
    //}
  
    /*
     * LINQ stands for Language Integrated Queries. 
     * LINQ allows to perform SQL like Queries on Collection objects of .NET.
     * System.Linq is the namespace for working with Collections. 
     * With this namespace, u get new keywords of query like from, in, where orderby group by, join, select for performing queries. 
     * The Query executes when the iteration happens. 
     */

        class Employee
        {
            public int EmpId { get; set; }
            public string EmpName { get; set; }
            public string EmpCity { get; set; }
            public int EmpSalary { get; set; }
            public int DeptId { get; set; }
        }
        class Dept
        {
            public int DeptId { get; set; }
            public string Deptname { get; set; }
        }

        static class DataComponent
        {
            const string fileName = "../../EmployeeData.csv";
            private static List<Employee> getAll()
            {
                var list = new List<Employee>();
                var lines = File.ReadAllLines(fileName);
                foreach (var line in lines)
                {
                    var words = line.Split(',');
                    var newEmp = new Employee
                    {
                        EmpId = int.Parse(words[0]),
                        EmpName = words[1],
                        EmpCity = words[2],
                        EmpSalary = int.Parse(words[3]),
                        DeptId = int.Parse(words[4])
                    };
                    list.Add(newEmp);
                }
                return list;
            }
            public static List<Employee> AllRecords => getAll();

            public static List<Dept> AllDepts => new List<Dept>
            {
                new Dept{DeptId=1,Deptname="HR"},
                new Dept{DeptId=2,Deptname="Admin"},
                new Dept{DeptId=3,Deptname="Developer"},
                new Dept{DeptId=4,Deptname="Testing"},
                new Dept{DeptId=5,Deptname="RCM"},
                new Dept{DeptId=6,Deptname="Technical"}
            };


        //public static List<Dept> AllDepts => getAllDept();
        }

        class Linq
        {
            static List<Dept> AllDepts => DataComponent.AllDepts;
            static List<Employee> data = DataComponent.AllRecords;
            static void Main()
            {
            //displayAllNames();
            //displayNamesAndAddresses();
            //displayNamesFromCity("Springdale");'
            //displayNamesWithSalariesGreaterThan(300000);
            //displayNamesOrderbyName();
            //displayUniqueCities();
            //displayNamesByGroupedByCityNames();
            //displayNamesByGroupedBySingleChar();
            // displayDeptByGrp();
            displayDeptandEmpName();

            //displayNamesByGroupedBySingleChar();


            }

        private static void displayDeptandEmpName()
        {
            var deptGroups = from dept in AllDepts
                             join emp in data on dept.DeptId equals emp.EmpId
                             select new { name = emp.EmpName, dept = dept.Deptname };
            foreach (var item in deptGroups)
            {
                Console.WriteLine(item);
            }
        }
        private static void displayDeptByGrp()
        {
            var deptGroups = from dept in AllDepts
                             join emp in data on dept.DeptId equals emp.DeptId
                             group new {name = emp.EmpName, dept = dept.Deptname} by dept.Deptname into g
                             select g;
            foreach (var group in deptGroups)
            {
                Console.WriteLine("Employees under " +group.Key);
                foreach (var name in group)
                {
                    Console.WriteLine($"{name} {deptGroups}");
                    //Console.WriteLine($"{group}");

                }
                Console.WriteLine();
            }
        }

        private static void displayNamesByGroupedBySingleChar()
        {
            var groups = from emp in data group emp.EmpName by emp.EmpName[0] into grp orderby grp.Key ascending select grp;
            //var a= from emp in data.FindAll(e=> e.EmpName.Contains("Ra") ) select emp.EmpName;
            foreach (var group in groups)
            {
                Console.WriteLine("People from " + group.Key);
                foreach (var name in group)
                {
                    Console.WriteLine(name);
                }
                Console.WriteLine();
            }
            //foreach (var group in a)
            //{
            //    Console.WriteLine("People from " + group);

            //}


        }

        private static void displayNamesByGroupedByCityNames()
        {
            var groups = from emp in data group emp.EmpName by emp.EmpCity into grp orderby grp.Key ascending select grp;
            foreach (var group in groups)
            {
                Console.WriteLine("People from " + group.Key);
                foreach (var name in group)
                {
                    Console.WriteLine(name);
                }
                Console.WriteLine();
            }
        }

        private static void displayUniqueCities()
            {
                var query = (from rec in data
                             select rec.EmpCity).Distinct();
                foreach (var cityName in query)
                    Console.WriteLine(cityName);
            }

            private static void displayNamesOrderbyName()
            {
                var query = from rec in data
                            orderby rec.EmpName descending
                            select rec.EmpName;
                foreach (var name in query)
                    Console.WriteLine(name);
            }

            private static void displayNamesWithSalariesGreaterThan(int salary)
            {
                var query = from rec in data
                            where rec.EmpSalary >= salary && rec.EmpName.StartsWith("S")
                            select new { rec.EmpName, rec.EmpSalary };
                foreach (var name in query)
                    Console.WriteLine(name);
            }

            //Display names of employees whose salary is more than 50000....
            private static void displayNamesFromCity(string city)
            {
                var query = from rec in data
                            where rec.EmpCity == city
                            select rec.EmpName;
                foreach (var name in query)
                    Console.WriteLine(name);
            }

            private static void displayNamesAndAddresses()
            {
                var query = from rec in data
                            select new { Name = rec.EmpName, Address = rec.EmpCity };
                foreach (var res in query)
                    Console.WriteLine($"{res.Name} from {res.Address}");
            }

            private static void displayAllNames()
            {
                var query = from emp in data
                            select emp.EmpName;
                foreach (var name in query)
                    Console.WriteLine(name.ToUpper());
            }
        }
}
