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
    class DisconnectedProgram
    {
        static string STRCONNECTION = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        const string query = "Select * from tlEmployee";

        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(STRCONNECTION);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataSet discObj = new DataSet("AllRecords");
            dataAdapter.Fill(discObj, "FirstTable");
            Trace.WriteLine("Connection state " + connection.State);
            foreach (DataRow row in discObj.Tables["FirstTable"].Rows)
            {
                Console.WriteLine(row["EmpAddress"]);
                Console.WriteLine(row["EmpName"]);
            }
        }
    }
}
