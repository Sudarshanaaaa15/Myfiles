using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using SampleFrameWork;

namespace SimpleLibrary
{
    public static class Database
    {
        const string STRCONNECTION = "Data Source=192.168.171.36;Initial Catalog=3334;Integrated Security=True";

        const string STRQUERY = "SELECT * FROM tlEmployee";
        public static DataTable GetAllRecords()
        {
            SqlConnection connection = new SqlConnection(STRCONNECTION);
            //connection.ConnectionString = STRCONNECTION;

            SqlCommand command = new SqlCommand(STRQUERY, connection);
            //command.CommandText = STRQUERY;

            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                DataTable dataTable = new DataTable("EmpRecords");
                dataTable.Load(reader);
                return dataTable;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
    class Connected
    {
        const string STRCONNECTION = "Data Source=192.168.171.36;Initial Catalog=3334;Integrated Security=True";

        const string STRQUERY = "SELECT * FROM tlEmployee";
        const string STRFIND = "SELECT * FROM tlEmployee where empname = @name";
        const string STRINSERT = "INSERT INTO tlEmployee values(@name,@address,@salary,@deptId)";
        const string STRINSERTPROC = "InsertEmployee";

        private static void AddNewDeatilsUsingStoredProc(string name,string address, int salary,int deptId, int managerid)
        {
            int EmpId = 0;
          //  int managerid = 0;
            SqlConnection connection = new SqlConnection(STRCONNECTION);
            SqlCommand command = new SqlCommand(STRINSERTPROC, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EmpName", name);
            command.Parameters.AddWithValue("@EmpAddress", address);
            command.Parameters.AddWithValue("@EmpSalary", salary);
            command.Parameters.AddWithValue("@DeptID", deptId);
            command.Parameters.AddWithValue("@EmpId", EmpId);
            command.Parameters.AddWithValue("@managerid", managerid);
            command.Parameters[4].Direction = ParameterDirection.Output;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                EmpId = Convert.ToInt32(command.Parameters[4].Value);
                Console.WriteLine("Enter the newly added employee is "+EmpId);
                //managerid = Convert.ToInt32(command.Parameters[5].Value);
                //Console.WriteLine("Enter the newly added manager is " + managerid);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private static void readingdata()
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = STRCONNECTION;

            SqlCommand sqlCommand = sqlCon.CreateCommand();
            sqlCommand.CommandText = STRQUERY;

            try
            {
                sqlCon.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["empname"]} from {reader[2]}");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sqlCon.State == System.Data.ConnectionState.Open)
                    sqlCon.Close();
            }
        }

        private static void displayAsTable()
        {
            try
            {
                var table = Database.GetAllRecords();
                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine($"empname: {row[1]}\nempaddress: {row[2]}\nempsalary:{row[3]}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        private static void displayDetails(string name)
        {
            string query = $"select * from tlEmployee where empname like '%{name}%'";
            SqlConnection connection = new SqlConnection(STRCONNECTION);
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                var read = command.ExecuteReader();
                while (read.Read())
                {
                    Console.WriteLine($"empname: {read[1]}\nempaddress: {read[2]}\nempsalary{read[3]}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private static void displayUsingParameters(string name)
        {
            SqlCommand command = new SqlCommand(STRFIND, new SqlConnection(STRCONNECTION));
            try
            {
                command.Parameters.AddWithValue("@name", name);
                command.Connection.Open();
                var read = command.ExecuteReader();
                while (read.Read())
                {
                    Console.WriteLine($"empname: {read[1]}\nempaddress:{read[2]}\nempsalary:{read[3]}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                command.Connection.Close();
            }
        }
        private static void addDeatails(string name,string address, int salary, int deptId)
        {
            SqlConnection connection = new SqlConnection(STRCONNECTION);
            SqlCommand command = new SqlCommand(STRINSERT, connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@salary", salary);
            command.Parameters.AddWithValue("@deptId", deptId);
            
            try
            {
                connection.Open();
                var AffectedRows = command.ExecuteNonQuery();
                if (AffectedRows != 1)
                {
                    throw new Exception("Fails to add the record to the database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                command.Connection.Close();
            }

        }
        public static void displayDept()
        {
            try
            {
                var table = Database.GetAllRecords();
                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine($"DeptName: {row[1]}\nDeptId: {row[0]}\n");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        public static void addDetailsWithInputs()
        {
            string name = Utilities.Prompt("Enter the Employee name");
            string address = Utilities.Prompt("Enter the Employee address");
            int salary = Utilities.GetNumber("Enter the Employee salary");
            //Database.GetAllRecords();
            displayDept();
            int deptid = Utilities.GetNumber("Enter the DeptId");
            addDeatails(name, address, salary, deptid);
            //int managerid = Utilities.GetNumber("Enter the managerId");

        }


        static void Main(string[] args)
        {
            //displayAsTable();
            //Database.GetAllRecords();
            //readingdata();
            //displayDetails("Peri");
            //displayUsingParameters("Rajesh");
            //addDeatails("Rajesh", "MANVI", 5000, 2);
            //addDetailsWithInputs();
            AddNewDeatilsUsingStoredProc("Mohan","Manvi",45000,2,1);
        }

        
    }
}

