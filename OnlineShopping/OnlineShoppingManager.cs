using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShopping.AuthenticationService;
using OnlineShopping.ConsoleView;

namespace OnlineShoppingSystem.OnlineShopping
{
    internal class OnlineShoppingManager
	{
		private static void signUpHelper()
		{
			Console.WriteLine("[1] Admin Account");
			Console.WriteLine("[2] Customer Account");
			Console.WriteLine("Please Enter A valid Choice: ");
			int userChoice = Convert.ToInt32(Console.ReadLine());
			SignUpService signUp;
			if (userChoice == 1)
			{
				signUp = new AdminAuthentication();
			}
			else if (userChoice == 2)
			{
				signUp = new CustomerAuthentication();
			}
			else
			{
				ErrorConsole.View("Please Enter A valid Choice\n");
				return;
			}
			signUp.SignUp();
		}
		public static void RunShoppingSystem()
		{
			IUserUI userUI = new MainUI();
			int userChoice = userUI.DisplayUI();
			try
			{
                while (userChoice != 3)
                {
                    if (userChoice == 1)
                    {
                        LoginService.Login();
                    }
                    else if (userChoice == 2)
                    {
                        signUpHelper();
                    }
                    else
                    {
                        ErrorConsole.View("Please Enter A valid Choice !\n");
                    }
                    userChoice = userUI.DisplayUI();
                }
            }
			catch( Exception ex )
			{
				ErrorConsole.View(ex.Message);
			}


		}
	}
}
