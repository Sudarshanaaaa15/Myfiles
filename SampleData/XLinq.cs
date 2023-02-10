using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SampleData
{
    class XLinq
    {
        const string filename = "../../ SampleMovie.xml";
        static void Main(string[] args)
        {
            //SampleXml();
             var Data = DataComponent.AllRecords;
            //ConvertToXml(Data);
            //DisplayNamesAndAddress();
            //DisplayNames();
            //InsertEmployeeInLast("Adarsh","Hubli",28000,2);
            //InsertRecAt(Utility.GetNumber("id"),Utility.GetNumber("empId"),Utility.Prompt("name"),Utility.Prompt("city"),Utility.GetNumber("salary"),Utility.GetNumber("deptId"));
            //deleteRecordAt(Utility.GetNumber("Enter the Empid"));
            //updateRecordAt(Utility.GetNumber("empId"), Utility.Prompt("name"), Utility.Prompt("city"), Utility.GetNumber("salary"), Utility.GetNumber("deptId"));
            //updateRecordAt(8, "rama", "rajesh", 40000, 4);
        }

        public static void updateRecordAt(int empId, string name, string city, int salary, int deptId)
        {
            string Id = empId.ToString();
            var doc = XDocument.Load(filename);
            var found = (from el in doc.Descendants("Employee")
                         where el.Element("EmpId").Value == Id
                         select el).FirstOrDefault();
            if (found == null)
                Console.WriteLine("element not found to update");
            else
            {
                //var insertingElement = new XElement("Employee",

                found.ReplaceAll(new XElement("EmpId", empId),
               new XElement("EmpName", name),
               new XElement("EmpCity", city),
               new XElement("EmpSalary", salary),
               new XElement("DeptId", deptId));
            }
            doc.Save(filename);
        }

        private static void deleteRecordAt(int id)
        {
            string idValue = id.ToString();
            var doc = XDocument.Load(filename);
            var foundRec = (from element in doc.Descendants("Employee")
                            where element.Element("EmpId").Value == idValue
                            select element).FirstOrDefault();
            if (foundRec == null)
            {
                Console.WriteLine("Data not found to delete");
            }
            else
            {
                foundRec.Remove();
                doc.Save(filename);
            }
        }

        private static void InsertRecAt(int id,int empId,string name,string city,int salary,int deptId)
        {
            string idValue = id.ToString();
            var doc = XDocument.Load(filename);
            var foundRec = (from element in doc.Descendants("Employee")
                            where element.Element("EmpId").Value == idValue
                            select element).First();
            var insertingEle = new XElement("Employee",
                                                new XElement("EmpId", empId),
                                                new XElement("EmpName", name),
                                                new XElement("EmpCity", city),
                                                new XElement("EmpSalary", salary),
                                                new XElement("DeptId", deptId)
                                                );
            foundRec.AddAfterSelf(insertingEle);
            doc.Save(filename);
        }

        
        private static void InsertEmployeeInLast(string name,string city, int salary,int deptId)
        {
            //Insert the record to the last
            var doc = XDocument.Load(filename);
            var lastEmp = (from element in doc.Descendants("Employee")
                           select element).Last();
            var lastId = int.Parse(lastEmp.Element("EmpId").Value);
            lastId++;
            var root = new XElement("Employee",
                                                 new XElement("EmpId", lastId),
                                                 new XElement("EmpName", name),
                                                 new XElement("EmpCity", city),
                                                 new XElement("EmpSalary", salary),
                                                 new XElement("DeptId", deptId)
                                                 );
            lastEmp.AddAfterSelf(root);
            doc.Save(filename);
               

        }

        private static void DisplayNamesAndAddress()
        {
            XDocument doc = XDocument.Load(filename);
            var allData = from element in doc.Descendants("Employee")
                          select new
                          {
                              Name = element.Element("EmpName").Value,
                              Address = element.Element("EmpCity").Value
                          };
            foreach (var data in allData)
            {
                Console.WriteLine(data);
            }
        }
        private static void DisplayNames()
        {
            XDocument doc = XDocument.Load(filename);
            var allData = from element in doc.Descendants("Employee")
                          select element.Element("EmpName");
            foreach (var data in allData)
            {
                Console.WriteLine(data);
            }
        }
        private static void ConvertToXml(List<Employee> data)
        {
            var root = new XElement("Employees", from emp in data

                                                 select new XElement("Employee",
                                                 new XElement("EmpId", emp.EmpId),
                                                 new XElement("EmpName", emp.EmpName),
                                                 new XElement("EmpCity", emp.EmpCity),
                                                 new XElement("EmpSalary", emp.EmpSalary),
                                                 new XElement("DeptId", emp.DeptId)
                                                 )
                );
            root.Save(filename);
        }
        private static void SampleXml()
        {
            //var MovieData = DataComponent.AllRecords;
            XElement element = new XElement("Movies",
                new XElement("Movie",
                new XAttribute("Duration", "2hours"),
                new XElement("MovId", 1),
                new XElement("MovieName", "Arasu"),
                new XElement("MovieDirector", "Manju"),
                new XElement("Actors",
                new XElement("Actor", "Punith"),
                new XElement("Actor", "Darshan")
                ))
                );
            Console.WriteLine(element);
            element.Save("../../ SampleMovie.xml");
        }
    }
}
