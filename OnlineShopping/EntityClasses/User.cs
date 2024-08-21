using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.EntityClasses
{
    internal abstract class User
    {
        public string userName, password, email;
        public int userId;
        public User(string userName, string password, string email, int userId)
        {
            this.userName = userName;
            this.password = password;
            this.email = email;
            this.userId = userId;

        }

        public abstract void printUserDetails();


    }
}
