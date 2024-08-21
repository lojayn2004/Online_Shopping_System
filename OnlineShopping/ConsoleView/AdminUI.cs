using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.ConsoleView
{
    internal class AdminUI: IUserUI
    {
        public int DisplayUI()
        {
            int userChoice = 0;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("ADMIN MENU: ");
           
            Console.WriteLine("          [1] Add Product          ");
            Console.WriteLine("          [2] Delete Product        ");
            Console.WriteLine("          [3] Browse Products        ");
            Console.WriteLine("          [4] Search Products       ");
            Console.WriteLine("          [5] Print Account Info     ");
            Console.WriteLine("          [6] Logout     ");
            Console.Write("Please Enter A valid Choice: ");
            Console.ForegroundColor = ConsoleColor.White;
            userChoice = Convert.ToInt32(Console.ReadLine());

            return userChoice;

        }
    }
}
