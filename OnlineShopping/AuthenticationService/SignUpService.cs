using Microsoft.Data.SqlClient;
using OnlineShopping.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.AuthenticationService
{

    internal abstract class SignUpService
    {
        // may add strong password recommenedation
        // add email validation
        protected virtual bool IsValidInput(string? userName, string? password, string? email)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password)
                || string.IsNullOrEmpty(email))
                return false;
            if (!IsValidUserName(userName))
                return false;

            return true;
        }
        private bool IsValidUserName(string? userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return false;
            }
            SqlConnection connection = DataBaseManager.GetDataBaseConnection();
            if (connection == null)
            {
                Console.WriteLine("Error Occured While registering \n Please try Again Later \n");
                return false;
            }
            string query = "select userName from [User] where userName = @userName";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (command == null)
                {
                    Console.WriteLine("Error Occured While registering \n Please try Again Later \n");
                    return false;
                }
                command.Parameters.AddWithValue("@userName", userName);
                var result = command.ExecuteScalar();
                if (result == null)
                {
                    connection.Close();
                    return true;
                }

            }
            connection.Close();
            return false;

        }
        public abstract void SignUp();
    }
}
