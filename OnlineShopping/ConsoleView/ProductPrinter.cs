using OnlineShopping.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.ConsoleView
{
    internal class ProductPrinter
    {
        public static void printProducts(List<Product> products)
        {
            for(int i = 0;i < products.Count; i ++ )
            {
                Console.WriteLine($"------------------------  Product  { i + 1 } ------------------------");
                products[i].printProductInfo();
                Console.WriteLine();
            }
        }
    }
}
