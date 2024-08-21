using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShopping.EntityClasses;

namespace OnlineShopping.DataBase
{
    internal class AdminDataBaseManager : UserDataBaseManager
    {
        private static AdminDataBaseManager dataBaseManager = new AdminDataBaseManager();

        private AdminDataBaseManager() { }
        public override User getUserDetails(string userName)
        {
            try
            {
                using (SqlConnection connection = DataBaseManager.GetDataBaseConnection())
                {
                    connection.Open();
                    if (connection is null)
                        throw new Exception("Error !!\nPlease Try Again \n");

                    string query = "select * from [user] join [Admin] on [user].userId = [admin].AdminId " +
                        "and [user].userName = @userName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (connection is null)
                            throw new Exception("Error !!\n Please Try Again \n");
                        command.Parameters.AddWithValue("@userName", userName);
                        using (SqlDataReader r = command.ExecuteReader())
                        {
                            if(!r.Read())
                                throw new Exception("Error!! \nPlease Try Again \n");
                            string password = r["password"].ToString()!;
                            string email = r["email"].ToString()!;
                            int userId = Convert.ToInt32(r["userId"].ToString());
                            DateTime dateOfEmploymnet = Convert.ToDateTime(r["dateOfEmployment"]);
                      
                            return new Admin(dateOfEmploymnet, userName, password, email, userId);
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
        public override void AddToDataBase(User admin)
        {
            try
            {
                Admin adm = (admin as Admin)!;
                addUserToDataBase(admin.userName, admin.password, admin.email, "A");
                int userId = getUserId(admin.userName);
                // need to add validations for connection and command
                using (SqlConnection connection = DataBaseManager.GetDataBaseConnection())
                {
                    connection.Open();

                    string addAdmin = "insert into admin values(@adminId, @dateOfEmployment)";
                    using (SqlCommand command = new SqlCommand(addAdmin, connection))
                    {
                        command.Parameters.AddWithValue("@adminId", userId);
                        command.Parameters.AddWithValue("@dateOfEmployment", adm.dateOfEmployment);
                        command.ExecuteNonQuery();

                    }

                }

            }
            catch
            {
                RemoveUserFromDataBase(admin.userName);
                throw;
            }

        }

        public static AdminDataBaseManager getDataBaseManager()
        {
            return dataBaseManager;
        }

    }
}
