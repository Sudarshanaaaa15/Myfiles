using SampleData.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleData
{
    namespace Entities
    {
        class Employee
        {
            public int EmpId { get; set; }
            public string EmpName { get; set; }
            public string EmpAddress { get; set; }
            public int EmpSalary { get; set; }
            public int DeptId { get; set; }
        }

        class Dept
        {
            public int DeptId { get; set; }
            public string DeptName { get; set; }
        }
    }
    namespace DataLayer
    {
        class EmpData
        {
            static string STRCONNECTION = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            const string query = "Select * from tlEmployee;Select * from tlDept";
            static DataSet discObj = new DataSet("AllRecords");
            static SqlDataAdapter dataAdapter = null;

            static void fillRecords()
            {
                SqlConnection connection = new SqlConnection(STRCONNECTION);
                SqlCommand command = new SqlCommand(query, connection);
                dataAdapter = new SqlDataAdapter(command);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(discObj);
                discObj.Tables[0].TableName = "EmpList";
                discObj.Tables[1].TableName = "DeptList";
                Trace.WriteLine("Connection state " + connection.State);
            }
            static void Main(string[] args)
            {
                fillRecords();
                //DisplayEmpOfDept("Human Resource");
                AddEmployee(1);
                //DeleteEmployee(5016);
                //UpdateEmployee(5016, "Ramesh", "America", 40000, 3);
            }

            private static void AddEmployee(int id)
            {
                foreach (DataRow row in discObj.Tables[0].Rows)
                {
                    if (row[0].ToString() == id.ToString())
                    {
                        String name = Utility.Prompt("Enter the name");
                        String address = Utility.Prompt("Enter the address");
                        int salary = Utility.GetNumber("Enter the salary");
                        int deptId = Utility.GetNumber("Enter the depid");
                        row[1] = name;
                        row[2] = address;
                        row[3] = salary;
                        row[4] = deptId;
                        //discObj.Tables[0].Rows.Add(newrow);
                        dataAdapter.Update(discObj, "EmpList");
                        row.Delete();
                        break;
                    }
                }
            }

           
        }
    }
    class E2EEmployeeDisconnected
    {
    }
}
