using System;
using System.Data;
using System.Data.SqlClient;

internal class Program
{
    private static void Main(string[] args)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Server=tcp:s-bear42.database.windows.net,1433;Initial Catalog=db-helloWorld;Persist Security Info=False;User ID={insert your id};Password={insert your [password]};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        
        try
        {
            HasRows(con);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    static void HasRows(SqlConnection connection)
    {
        using (connection)
        {
            SqlCommand command = new SqlCommand(
            "SELECT TOP (1000) * FROM [classicmodels].[customers]",
            connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0}\t{1}", reader.GetString(1), reader.GetString(10));
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
        }
    }
}
