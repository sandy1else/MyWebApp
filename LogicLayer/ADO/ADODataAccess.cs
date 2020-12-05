using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.ADO
{
    public static class ADODataAccess
    {
        public static string GetALL()
        {
            string executionTime = "";
            string connectionStrings = "Data Source= DESKTOP-B6S5Q9K; Integrated Security=false; Initial Catalog= WEBFORMDB; uid=sa; Password=some1se;";

            using (SqlConnection connection = new SqlConnection(connectionStrings))
            {
                connection.Open();
                // Do work here.  

                Stopwatch sw = new Stopwatch();
                sw.Start();
                 
                for (int i = 0; i < 10000; i++)
                {
                    using(SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "";
                        command.Parameters.Add(new SqlParameter("SplitID", 4));

                        using(SqlDataReader reader =  command.ExecuteReader())
                        {

                        }
                    }
                }

                sw.Stop();
                executionTime = sw.ElapsedMilliseconds.ToString();

            }
            return executionTime;
        }

    }
}
