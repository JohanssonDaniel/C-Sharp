using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Common;
using System.Configuration;

namespace CSharpDB
{
    class Program
    {
        static void Main(string[] args)
        {
            string provider = ConfigurationManager.AppSettings["provider"];

            string connectionString = ConfigurationManager.AppSettings["connectionString"];

            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("Connection error...");
                    Console.ReadLine();
                    return;
                } else
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    DbCommand command = factory.CreateCommand();

                    if (command == null)
                    {
                        Console.WriteLine("Command error...");
                        Console.ReadLine();
                        return;
                    }

                    command.Connection = connection;

                    command.CommandText = "Select * From Products";

                    using (DbDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Console.WriteLine($"{dataReader["ProdId"]} {dataReader["Product"]}");
                        }
                    }

                    Console.ReadLine();
                }
            }
        }
    }
}
