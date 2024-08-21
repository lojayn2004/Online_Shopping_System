using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.DataBase
{
    internal class ShoppingCartManager
    {

        private static int getCustomerProductQuantity(int customerId, int productId)
        {
            using (SqlConnection connection = DataBaseManager.GetDataBaseConnection())
            {
                connection.Open();
                if (connection is null)
                    throw new Exception("Error Occured! \n");
                string query = "select qunatity from shoppingcart " +
                    "where customerId = @customerId and productId = @productId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@customerId", customerId);
                    command.Parameters.AddWithValue("@productId", productId);
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        if (read.Read())
                            return read.GetInt32(0);
                        throw new Exception("Error Ocuured \n");
                    }
                }

            }
        }

        public static List<Product> getCustomerProducts(int customerId)
        {
            List<Product> products = new List<Product>();


            using (SqlConnection connection = DataBaseManager.GetDataBaseConnection())
            {
                connection.Open();
                if (connection == null)
                    throw new Exception("Error Occured While Browsing Products\n");
                string query = "select * from products, customer, shoppingCart where customer.customerId = @customerId " +
                    "and shoppingCart.productId = products.productId and customer.customerId = shoppingCart.customerId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@customerId", customerId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product p = new Product();
                            p.productId = Convert.ToInt32(reader["productId"]);
                            p.productName = reader["productName"].ToString()!;
                            p.productDescription = reader["productDescription"].ToString()!;

                            p.productCategory = (Category)Enum.Parse(typeof(Category), reader["productCategory"].ToString()!);
                            p.productPrice = Convert.ToDecimal(reader["productPrice"]);
                            p.productQuantity = Convert.ToInt32(reader["qunatity"]);
                            products.Add(p);
                        }
                    }

                }

            }
            return products;
        }
        
        public static void RemoveProductFromCustomerCart(int customerId, int productId)
        {
            if (!productDataBaseManager.isValidProductId(productId))
                throw new Exception("Invalid Product Id\n");
            int productQunatity = getCustomerProductQuantity(customerId, productId);
            productDataBaseManager.ChangeProductQuantity(productId, productQunatity);
            using (SqlConnection connection = DataBaseManager.GetDataBaseConnection())
            {
                connection.Open();
                if (connection is null)
                    throw new Exception("Error Ocuured While Removing Product from cart \nPlease Try Later\n");
                string query = "delete from shoppingcart where customerId = @customerId and productId = @productId";

                using (SqlCommand command = new SqlCommand(query, connection))
                { 
                    command.Parameters.AddWithValue("@customerId", customerId);
                    command.Parameters.AddWithValue("@productId", productId);
                    command.ExecuteNonQuery();
                }

            }
        }

        public static void AddProductToCustomerCart(int customerId, int productId, int quantity)
        {
            if (!productDataBaseManager.isValidProductId(productId))
                throw new Exception("Invalid Product Id!!");
            if (quantity > productDataBaseManager.getProductQuantity(productId))
                throw new Exception("Insuffecint Qunatity Please Enter A valid quantit");
            if (quantity <= 0)
                throw new Exception("Invalid Product Quantity \n Quantity must be Greater than zero \n");
            productDataBaseManager.ChangeProductQuantity(productId, -quantity);
            using (SqlConnection connection = DataBaseManager.GetDataBaseConnection())
            {
                connection.Open();
                if (connection is null)
                    throw new Exception("Error While Adding Product To Customer Cart\n");
                string query = "insert into shoppingcart values(@customerId, @productId, @quantity)";

                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@customerId", customerId);
                    command.Parameters.AddWithValue("@productId", productId);
                    command.Parameters.AddWithValue("@quantity", quantity);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
