using OnlineShopping.ConsoleView;
using OnlineShopping.EntityClasses;

namespace OnlineShopping.HomePages
{
    internal class AdminHomePage : HomePage
    {
        private User admin;

        private void validateProductInfo(string name, string description, decimal price)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) || price <= 0)
                throw new Exception("Invalid Product Data Info \n Please Try Again\n");

        }
        
        private Product getProductInfo()
        {
            Product product = new Product();
            Console.Write("Product Name: ");
            product.productName = Console.ReadLine()!;
            Console.Write("Product Description: ");
            product.productDescription = Console.ReadLine()!;
            Console.WriteLine("Product Category: ");
            product.productCategory = (Category)Enum.Parse(typeof(Category), CategoryUI.DisplayUI());
            Console.Write("Product Price: ");
            product.productPrice = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Product Quantity: ");
            product.productQuantity = Convert.ToInt32(Console.ReadLine());
            validateProductInfo(product.productName!, product.productDescription!, product.productPrice);
            return product;

        }

        public AdminHomePage(User admin)
        {
            this.admin = admin;
        }
        public void viewHomePage()
        {
            IUserUI adminUi = new AdminUI();
            int adminChoice = adminUi.DisplayUI();

            while (true)
            {

                try
                {
                    if (adminChoice == 1)
                    {
                        productDataBaseManager.AddNewProduct(getProductInfo());
                        SuccessConsole.View("Product Added Sucessfully\n");
                    }
                    else if (adminChoice == 2)
                    {
                        Console.Write("Enter Product Id: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        productDataBaseManager.RemoveProduct(id);
                        SuccessConsole.View("Product Deleted Successfully\n");
                    }

                    else if (adminChoice == 3)
                    {
                        ProductPrinter.printProducts(productDataBaseManager.getAllProducts());
                    }
                    else if (adminChoice == 4)
                    {
                        int choice = SearchUI.DisplayUI();
                        List<Product> resultProducts;
                        if (choice == 1)
                        {
                            Console.Write("Product Name: ");
                            string name = Console.ReadLine();
                            resultProducts = productDataBaseManager.getProductWithSpecificName(name);
                        }
                        else
                        {
                            string category = CategoryUI.DisplayUI();
                            resultProducts = productDataBaseManager.getProductWithSpecificCategory(category);

                        }
                        ProductPrinter.printProducts(resultProducts);
                    }

                    else if (adminChoice == 5)
                    {
                        admin.printUserDetails();
                    }
                    else if(adminChoice == 6)
                    {
                        break;
                    }
                    else
                    {
                        ErrorConsole.View("Invalid Choice Please Try Again\n");
                    }

                }
                catch (Exception ex)
                {
                    ErrorConsole.View(ex.Message);
                }

                adminChoice = adminUi.DisplayUI();
            }
        }
    }
}
