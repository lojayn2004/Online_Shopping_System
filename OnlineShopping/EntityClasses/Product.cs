using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.EntityClasses
{


    internal class Product
    {
        public int productId { get; set; }
        public string productName { get; set; } = "N/A";

        public string productDescription { get; set; } = "N/A";
        public Category productCategory { get; set; }
        public decimal productPrice { get; set; }
        public int productQuantity { get; set; }

        

        public void printProductInfo()
        {
            Console.WriteLine("Product Id: " + productId);
            Console.WriteLine("Product Name: " + productName);
            Console.WriteLine("Product Category: " + productCategory.ToString());
            // need to format it as a money
            Console.WriteLine("Product Price: " + productPrice);
            Console.WriteLine("Product Avaliable Quantity " + productQuantity);
            Console.WriteLine("Product Description: " + productDescription);

        }

    }
}
