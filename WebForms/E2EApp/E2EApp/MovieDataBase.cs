using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2EApp
{

    class Entry
    {
        public int EntryId { get; set; }
        public int ActorId { get; set; }
        public int MovieId { get; set; }
    }
    class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public float MovieDuration { get; set; }
        public float MovieRating { get; set; }
    }
    class Director
    {
        public int DirectorId { get; set; }
        public string DirectorName { get; set; }
        public int DirectorAge { get; set; }
    }
    class Actor
    {
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public int ActorAge { get; set; }
        public string Description { get; set; }
    }
    
    class MovieDataBase
    {
        const String STRCONNECTION = "Data Source=192.168.171.36;Initial Catalog=3334;Integrated Security=True";
        const string query = "select * from TblMovie";

        public static DataTable GetAllRecords()
        {
            SqlConnection connection = new SqlConnection(STRCONNECTION);
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                var reader = sqlCommand.ExecuteReader();
                DataTable table = new DataTable("GetRecords");
                table.Load(reader);
                return table;
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                if(connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
           

        }
    }
    class IMDBRepo
    {
        const String STRCONNECTION = "Data Source=192.168.171.36;Initial Catalog=3334;Integrated Security=True";
        const string STRINSERT = "insert into TblMovie values (@Name,@Duration,@Rating)";

        static void Main(string[] args)
        {
            AddNewMovie("Park", 2.5, 5.0);
        }

        private static void AddNewMovie(string name,double duration,double rating)
        {
            SqlConnection connection = new SqlConnection(STRCONNECTION);
            SqlCommand command = new SqlCommand(STRINSERT, connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@duration", duration);
            command.Parameters.AddWithValue("@rating", rating);
            try
            {
                connection.Open();
                var Affected = command.ExecuteNonQuery();
                if (Affected != 1)
                    throw new Exception ("adding failed");
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
