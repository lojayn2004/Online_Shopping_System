

using OnlineShopping.DataBase;

namespace OnlineShopping.AuthenticationService
{
    internal class AdminAuthentication : SignUpService
	{ 
		public  override void SignUp()
		{
			string? userName= "", password = "", email = "";
	
			Console.Write("Enter a userName: ");
			userName = Console.ReadLine();

			Console.Write("Enter an email: ");
			email = Console.ReadLine();

			Console.Write("Enter a password: ");
			password = Console.ReadLine();

			DateTime dateOfEmployment = DateTime.Now;

			if (base.IsValidInput(userName, password, email))
			{
				User u = (User)new Admin(dateOfEmployment, userName!, password!, email!, -1);
                AdminDataBaseManager dbManager = AdminDataBaseManager.getDataBaseManager();
               dbManager.AddToDataBase(u);

			}
			else
			{
				Console.WriteLine("Please Enter A valid Info \n");
			}
		}

    }
}
