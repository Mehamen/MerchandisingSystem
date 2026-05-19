using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace MerchandisingSystem
{
    internal class Database
    {
        private static string connectionString =
           "Host=localhost;Port=5432;Database=merchandising;Username=postgres;Password=S1t2e3.!;Client Encoding=UTF8";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка подключения: " + ex.Message);
                return false;
            }
        }
    }
}
