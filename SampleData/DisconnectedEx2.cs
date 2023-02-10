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
    class DisconnectedEx2
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
            //InsertEmployee("Raju", "Raichur", 40000, 3);
            //DeleteEmployee(5016);
            UpdateEmployee(5016,"Ramesh","America",40000,3);
        }
        private static void UpdateEmployee(int id,string name, string address,int salary,int deptId)
        {
            foreach (DataRow row in discObj.Tables[0].Rows)
            {
                if (row[0].ToString() == id.ToString())
                {
                    row[1] = name;
                    row[2] = address;
                    row[3] = salary;
                    row[4] = deptId;
                    dataAdapter.Update(discObj, "EmpList");

                }
            }
        }
        //private static void UpdateEmployee(int id)
        //{
        //    foreach (DataRow row in discObj.Tables[0].Rows)
        //    {
        //        if (row[0].ToString() == id.ToString())
        //        {
        //            String name = Utility.Prompt("Enter the name");
        //            String address = Utility.Prompt("Enter the address");
        //            int salary = Utility.GetNumber("Enter the salary");
        //            int deptId = Utility.GetNumber("Enter the depid");
        //            row[1] = name;
        //            row[2] = address;
        //            row[3] = salary;
        //            row[4] = deptId;
        //            //discObj.Tables[0].Rows.Add(newrow);
        //            dataAdapter.Update(discObj, "EmpList");
        //            row.Delete();
        //            break;
        //        }
        //    }
        //}

        private static void DeleteEmployee(int recId)
        {
            foreach (DataRow row in discObj.Tables[0].Rows)
            {
                if (row[0].ToString() == recId.ToString())
                {
                    row.Delete();
                    break;
                }
            }
        }

        private static void InsertEmployee(string name,string address,int salary,int deptId)
        {
            DataRow newrow = discObj.Tables[0].NewRow();
            newrow[1] = name;
            newrow[2] = address;
            newrow[3] = salary;
            newrow[4] = deptId;
            discObj.Tables[0].Rows.Add(newrow);
            dataAdapter.Update(discObj, "EmpList");
            
        }
        static void DisplayEmpOfDept(string deptname)
        {
            int deptId = 0;
            foreach (DataRow row in discObj.Tables["DeptList"].Rows)
            {
                if (row["DeptName"].ToString() == deptname)
                {
                    deptId = (int)row["DeptId"];
                    break;
                }
            }
            foreach (DataRow row in discObj.Tables["EmpList"].Rows)
            {
                if (row[4].ToString() == deptId.ToString())
                {
                    Console.WriteLine(row["EmpName"]);
                    
                }
            }

        }
    }
}
