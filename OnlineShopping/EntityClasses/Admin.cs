using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.EntityClasses
{
    internal class Admin : User
    {
        public DateTime dateOfEmployment;
        public Admin(DateTime dateOfEmployment, string userName, string password, string email, int userId)
            : base(userName, password, email, userId)
        {
            this.dateOfEmployment = dateOfEmployment;
        }

        public override void printUserDetails()
        {
            Console.WriteLine("User Name: " + userName);
            Console.WriteLine("Email: " + email);
            Console.WriteLine("Date Of Employment: " + dateOfEmployment.ToString());

        }

    }
}
