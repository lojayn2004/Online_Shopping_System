using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.EntityClasses
{
    internal class Customer : User
    {
        public Address customerAddress;

        public Customer(Address customerAddress, string userName, string password, string email, int userId) :
            base(userName, password, email, userId)
        {

            this.customerAddress = customerAddress;
        }

        public override void printUserDetails()
        {
            Console.WriteLine($"User Name: { userName } ");
            Console.WriteLine($"Email: { email } ");
            Console.WriteLine("Address: " + customerAddress.ToString());

        }
    }
}
