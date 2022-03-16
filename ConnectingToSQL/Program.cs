using ConnectingToSQL.query;
using System;
using System.Data.SqlClient;
using System.Text;

namespace ConnectingToSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting Connection ...");

            var datasource = @"CMDB-134740";//server name
            var database = "AdventureWorks2017"; // database name
            var username = "username"; // username of server to connect
            var password = "password"; //   password

            // connection string 
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                Console.WriteLine("Openning Connection ...");
                //open connection
                conn.Open();
                Console.WriteLine("Connection successful!");

                //retrieve the SQL Server instance version
                string query = QueryLibrary.InnerJoin();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));

                            Console.WriteLine("{0}", reader.GetInt32(0));

                        }
                    }
                }
             
                // EXECUTE NON QUERY (i.e. inserts) EXAMPLE
                ////create a new SQL Query using StringBuilder
                //StringBuilder strBuilder = new StringBuilder();
                //strBuilder.Append("INSERT INTO users_tbl (first_name, last_name, age) VALUES ");
                //strBuilder.Append("(N'Homer', N'Simpson', N'40'), ");
                //strBuilder.Append("(N'Ned', N'Flanders', N'42')");

                //string sqlQuery = strBuilder.ToString();

                //using (SqlCommand command = new SqlCommand(sqlQuery, conn)) //pass SQL query created above and connection
                //{
                //    command.ExecuteNonQuery(); //execute the Query
                //    Console.WriteLine("Query Executed.");
                //}
            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            Console.Read();
        }
    }
}
