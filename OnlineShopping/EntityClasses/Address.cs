using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.EntityClasses
{
    internal class Address
    {
        public string streetAddress;
        public string city;
        public string zipCode;

        public Address(string streetAddress, string city, string zipCode)
        {
            this.streetAddress = streetAddress;
            this.city = city;
            this.zipCode = zipCode;
        }
        public override string ToString()
        {
            return city + " " + streetAddress + " " + zipCode;
        }
    }
}
