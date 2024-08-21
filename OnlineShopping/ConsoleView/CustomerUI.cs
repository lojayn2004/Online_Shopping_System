using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.ConsoleView
{
    internal class CustomerUI: IUserUI
    {
        public int DisplayUI()
        {
            int userChoice = 0;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("CUSTOMER MENU:");

            Console.WriteLine("               [1] Add Product to shopping cart         ");
            Console.WriteLine("               [2] Remove Product from shopping cart       ");
            Console.WriteLine("               [3] Display Shopping Cart Content        ");
            Console.WriteLine("               [4] Browse Products        ");
            Console.WriteLine("               [5] Search Products       ");
            Console.WriteLine("               [6] Print Account Info     ");
            Console.WriteLine("               [7] Logout     ");
            Console.Write("Please Enter A valid Choice: ");
            Console.ForegroundColor = ConsoleColor.White;
            userChoice = Convert.ToInt32(Console.ReadLine());

            return userChoice;

        }
    }
}
