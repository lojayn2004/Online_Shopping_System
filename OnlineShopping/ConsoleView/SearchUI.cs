using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.ConsoleView
{
    internal class SearchUI
    {
      public static int DisplayUI()
      {
            int userChoice;
            Console.WriteLine("[1] Search By Name ");
            Console.WriteLine("[2] Search By Category ");
            Console.Write("Enter Your Choice: ");
            userChoice = Convert.ToInt32(Console.ReadLine());
            if(userChoice < 1 || userChoice > 2)
            {
                ErrorConsole.View("Please Enter A valid Choice\n");
                DisplayUI();
            }
            return userChoice;
      }
    }
}
