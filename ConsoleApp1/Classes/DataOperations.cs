using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationLibrary.Classes;
using ConsoleApp1.Models;
using Microsoft.Data.SqlClient;

namespace ConsoleApp1.Classes
{
    internal class DataOperations
    {
        public static async Task<List<Customers>> CustomersList()
        {
            List<Customers> list = new List<Customers>();

            var statement = "SELECT Id,FirstName,LastName FROM dbo.Customers;";
            await using var cn = new SqlConnection(ConfigurationHelper.ConnectionString());
            await using var cmd = new SqlCommand { Connection = cn, CommandText = statement };

            await cn.OpenAsync();
            await using var reader = await cmd.ExecuteReaderAsync();
            while (reader.Read())
            {
                list.Add(new Customers() {Id = reader.GetInt32(0), FirstName = reader.GetString(1), LastName = reader.GetString(2)});
            }
            return list;
        }
    }
}
