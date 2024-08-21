using Microsoft.Data.SqlClient;
using OnlineShopping;
using OnlineShopping.DataBase;
using OnlineShopping.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.AuthenticationService
{
    internal class CustomerAuthentication : SignUpService
    {
       
        private bool IsValidInput(Address customerAddress, string userName, string password, string email)
        {
            if (!base.IsValidInput(userName, password, email))
                return false;
            if (string.IsNullOrEmpty(customerAddress.streetAddress) || string.IsNullOrEmpty(customerAddress.city)
                || string.IsNullOrEmpty(customerAddress.zipCode))
                return false;
            return true;

        }
        public override void SignUp()
        {
            string streetAddress, city, zipCode, email, userName, password;

            Console.Write("Enter your userName: ");
            userName = Console.ReadLine()!;

            Console.Write("Enter your email: ");
            email = Console.ReadLine()!;

            Console.Write("Enter your password: ");
            password = Console.ReadLine()!;

            Console.Write("Enter City: ");
            city = Console.ReadLine()!;
            Console.Write("Enter Street Address: ");
            streetAddress = Console.ReadLine()!;
            Console.Write("Enter Zip Code: ");
            zipCode = Console.ReadLine()!;
            Address customerAddress = new Address(streetAddress!, city!, zipCode!);

            if (IsValidInput(customerAddress, userName!, email!, password!))
            {
                CustomerDataBaseManager dbManager = CustomerDataBaseManager.getDataBaseManager();
                User cust = (User)new Customer(customerAddress, userName, password, email, -1);
                dbManager.AddToDataBase(cust);
            }
            else
            {
                throw new Exception("Invalid Input Data Please Try Again \n");
            }

        }
      
    }
}
