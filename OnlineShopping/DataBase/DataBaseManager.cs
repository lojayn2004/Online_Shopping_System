using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace OnlineShoppingSystem.OnlineShopping
{
	

	internal class DataBaseManager
    {
		
		private static readonly string _connectionString = "Server=localhost;Database=OnlineShoppingSystem;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;\r\n";
		public static SqlConnection GetDataBaseConnection()
        {
            return new SqlConnection(_connectionString);
        }
	}
}
