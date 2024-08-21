using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using OnlineShopping.DataBase;
using OnlineShopping.EntityClasses;
using OnlineShopping.HomePages;

namespace OnlineShopping.AuthenticationService
{
    internal  class LoginService
    {
        private static User LoginHelper(string userName, string password)
        {
            try
            {
                
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                    throw new Exception("Invalid Username or Password \nPlease Try Again\n");
                if (!UserDataBaseManager.AreCredentialsValid(userName, password))
                    throw new Exception("Invalid Username or Password \nPlease Try Again\n");
                UserDataBaseManager user;
                string userType = UserDataBaseManager.getUserType(userName, password);
                
                if (userType == "A")
                    user = AdminDataBaseManager.getDataBaseManager();
                else if (userType == "C")
                    user = CustomerDataBaseManager.getDataBaseManager();
                else
                    throw new Exception("Invalid Username or Password \nPlease Try Again\n");
                SuccessConsole.View("Welcome " + userName);
                return user.getUserDetails(userName);
            }
            catch
            {
                throw;
            }
        }
        public  static void Login()
        {
            string userName, password;
            Console.Write("Username: ");
            userName = Console.ReadLine()!;
            Console.Write("Password: ");
            password = Console.ReadLine()!;
            User u = LoginHelper(userName, password);
            HomePage home = null;
            if (u is Admin)
                home = new AdminHomePage(u);
            else if (u is Customer)
                home = new CustomerHomePage(u);
            else
                throw new Exception("Error Occurred While Logging Please try again\n");
            home.viewHomePage();
        }


    }
}
