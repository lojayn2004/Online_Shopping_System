using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShopping.EntityClasses;

namespace OnlineShopping.DataBase
{
    internal class CustomerDataBaseManager: UserDataBaseManager
    {
        private static CustomerDataBaseManager customerManager = new CustomerDataBaseManager();
        private CustomerDataBaseManager() { }
        public override User getUserDetails(string userName)
        {
            try
            {
                using (SqlConnection connection = DataBaseManager.GetDataBaseConnection())
                {
                    connection.Open();
                    if (connection is null)
                        throw new Exception("Error !!\nPlease Try Again \n");

                    string query = "select * from [user] join  Customer on [user].userId = Customer.CustomerId " +
                        "and [user].userName = @userName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        
                        command.Parameters.AddWithValue("@userName", userName);
                        using (SqlDataReader r = command.ExecuteReader())
                        {
                            if(r.Read())
                            {
                                string password = r["password"].ToString()!;
                                string email = r["email"].ToString()!;
                                int userId = Convert.ToInt32(r["userId"].ToString());
                                string street = r["streetCode"].ToString()!;
                                string city = r["city"].ToString()!;
                                string zipCode = r["zipCode"].ToString()!;
                                return new Customer(new Address(street, city, zipCode), userName, password, email, userId);

                            }
                     
                        }

                    }
                }
                // if we came here means their is an error that occured 
                throw new Exception("Error !! \nPlease Try Again \n");

            }
            catch
            {
                throw;
            }

        }

        public override void AddToDataBase(User customer)
        {
            try
            {
                Customer cust = (customer as Customer)!;
                addUserToDataBase(customer.userName, customer.password, customer.email, "C");
                int userId = getUserId(customer.userName);
                string query = "insert into customer values(@userId, @streetCode, @zipCode, @city)";
                using (SqlConnection connection = DataBaseManager.GetDataBaseConnection())
                {
                    connection.Open();
                    if (connection is null)
                        throw new Exception("Error While Registering Please Try Again \n");
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (command is null)
                            throw new Exception("Error While Registering Please Try Again \n");

                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@streetCode", cust.customerAddress.streetAddress);
                        command.Parameters.AddWithValue("@zipCode", cust.customerAddress.zipCode);
                        command.Parameters.AddWithValue("@city", cust.customerAddress.city);
                        command.ExecuteNonQuery();
                    }

                }
            }
            catch
            {
                RemoveUserFromDataBase(customer.userName);
                throw;
            }
        }

        public static CustomerDataBaseManager getDataBaseManager()
        {
            return customerManager;
        }

    }
}
