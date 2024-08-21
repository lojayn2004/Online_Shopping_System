using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShopping.EntityClasses;

namespace OnlineShopping.HomePages
{
    internal class CustomerHomePage : HomePage
    {
        private Customer customer;
        public CustomerHomePage(User customer)
        {
            this.customer = (customer as Customer)!;
        }
        public void viewHomePage()
        {
            IUserUI customerUI = new CustomerUI();
            int customerChoice = customerUI.DisplayUI();
            while (true)
            {
                try
                {
                    if (customerChoice == 1)
                    {
                        Console.Write("Product Id: ");
                        int productId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("ProductQuantity: ");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        ShoppingCartManager.AddProductToCustomerCart(customer.userId, productId, quantity);
                        SuccessConsole.View("Product Added Successfully \n");
                    }
                    else if (customerChoice == 2)
                    {
                        Console.Write("Product Id: ");
                        int productId = Convert.ToInt32(Console.ReadLine());
                        ShoppingCartManager.RemoveProductFromCustomerCart(customer.userId, productId);
                        SuccessConsole.View("Product Removed from Cart Successfully\n");

                    }
                    else if (customerChoice == 3)
                    {
                        List<Product> products =
                            ShoppingCartManager.getCustomerProducts(customer.userId);
                        ProductPrinter.printProducts(products);
                    }
                    else if (customerChoice == 4)
                    {
                        List<Product> products =
                           productDataBaseManager.getAllProducts();
                        ProductPrinter.printProducts(products);
                    }
                    else if (customerChoice == 5)
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

                    else if (customerChoice == 6)
                    {
                        customer.printUserDetails();
                    }
                    else if(customerChoice == 7)
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
                customerChoice = customerUI.DisplayUI();
            }
        }
    }
}
