using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace OnlineShopping.ConsoleView
{
    internal class CategoryUI
    {
        public static string DisplayUI()
        {
            int userChoice;
            Console.WriteLine("[1]: Electronics");
            Console.WriteLine("[2]: Books");
            Console.WriteLine("[3]: Home");
            Console.WriteLine("[4]: Health");
            Console.WriteLine("[5]: Jewelry");
            Console.WriteLine("[6]: Appliances");
            Console.WriteLine("[7]: Food");
            Console.WriteLine("[8]: Clothes");
            Console.WriteLine("[9]: Shoes");
            Console.Write("Enter Your Choice: ");
            userChoice = Convert.ToInt32(Console.ReadLine());
            if (!(userChoice >= 1 && userChoice <= 8))
                DisplayUI();
            Category cat = (Category)userChoice;
            return cat.ToString();
        }

    }
}
