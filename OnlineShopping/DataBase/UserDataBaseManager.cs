using Microsoft.Data.SqlClient;
using OnlineShopping.DataBase;
using OnlineShopping.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingSystem.OnlineShopping
{
    abstract class UserDataBaseManager
	{
		public static void addUserToDataBase(string userName, string password, string email, string userType)
		{
			using (SqlConnection connection = DataBaseManager.GetDataBaseConnection())
			{
                connection.Open();
                if (connection is null)
					throw new Exception("Error While Registering\n");
				
				
				string query = "insert into [user](userName, [password], email, userType) values(@userName, @password, @email, @userType)";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					if(command is null)
						throw new Exception("Error While Registering\n");

					command.Parameters.AddWithValue("@userName", userName);
					command.Parameters.AddWithValue("@password", password);
					command.Parameters.AddWithValue("@email", email);
					command.Parameters.AddWithValue("@userType", userType);
					command.ExecuteNonQuery();
				}
			}
		}
		public static int getUserId(string userName)
		{
			using (SqlConnection connection = DataBaseManager.GetDataBaseConnection())
			{
                connection.Open();
                if (connection is null)
				    throw new Exception("Error While Registering\n");
				
				string getUserId = "select userId from [user] where userName = @userName";
				int userId = -1;
				using (SqlCommand command = new SqlCommand(getUserId, connection))
				{
					if (command is null)
						throw new Exception("Error While Registering\n");
					command.Parameters.AddWithValue("@userName", userName);
					var result = command.ExecuteScalar()!;
					int.TryParse(result.ToString(), out userId);
				}
				if(userId == -1)
					throw new Exception("User Is not valid \n Please Enter A valid Name");
				return userId;
			}
		}

		public static void RemoveUserFromDataBase(string userName)
		{
			int userId = getUserId(userName);
			using (SqlConnection connection = DataBaseManager.GetDataBaseConnection())
			{
				connection.Open();
				if (connection is null) 
					throw new Exception("Error Ocuured! \n Please Try Later\n");
				string query = "delete from [user] where userId = @userId";
				using(SqlCommand command = new SqlCommand(query, connection))
				{
                    if (command is null)
                        throw new Exception("Error Ocuured! \n Please Try Later\n");
					command.Parameters.AddWithValue("@userId", userId);
                }
			}
		}

		public static bool AreCredentialsValid(string userName, string password)
		{
			try
			{
				using (SqlConnection connection = DataBaseManager.GetDataBaseConnection())
				{
					connection.Open();
					if (connection is null)
						throw new Exception("Error While Login \n Please Try Later \n");
					string query = "select count(*) from [user] where userName =" +
						" @userName and [password] = @password";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						if (command is null)
							throw new Exception("Error While Loging \n Please Try Later \n");
						command.Parameters.AddWithValue("@userName", userName);
						command.Parameters.AddWithValue("@password", password);
					
                        bool isFound = command.ExecuteScalar() is null ? false : (int)command.ExecuteScalar() > 0;
		
						return isFound;

					}
				}

			}
			catch
			{
				throw;
			}
			
		}
		public static string getUserType(string userName, string password)
		{
            using (SqlConnection connection = DataBaseManager.GetDataBaseConnection())
            {
				connection.Open();
                if (connection is null)
                    throw new Exception("Error While Login \n Please Try Later \n");
                string query = "SELECT userType FROM [user] WHERE userName = @userName " +
					"AND [password] = @password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (command is null)
                        throw new Exception("Error While Loging \n Please Try Later \n");
					command.Parameters.AddWithValue("@userName", userName);
					command.Parameters.AddWithValue("@password", password);

                    using(SqlDataReader reader = command.ExecuteReader())
					{
						if (reader is not null && reader.Read())
                            return reader["userType"]?.ToString() ?? "U";
                        else 
							return "U";
					}

                }
            }
        }

		public abstract User getUserDetails(string userName);

		public abstract  void AddToDataBase(User u);
	}
}
