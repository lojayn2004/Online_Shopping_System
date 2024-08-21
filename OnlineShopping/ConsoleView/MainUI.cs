using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.ConsoleView
{
    internal class MainUI : IUserUI
    {
        public int DisplayUI()
        {
            int userChoice = 0;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("MAIN MENU:");

            Console.WriteLine("           [1] Login          ");
            Console.WriteLine("           [2] Sign Up        ");
            Console.WriteLine("           [3] Exit        ");
            Console.Write("Please Enter A valid Choice: ");
            Console.ForegroundColor = ConsoleColor.White;

            userChoice = Convert.ToInt32(Console.ReadLine());

            return userChoice;

        }
    }
}
