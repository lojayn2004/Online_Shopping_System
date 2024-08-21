

namespace OnlineShopping.DataBase
{
    internal class productDataBaseManager
    {
        private static List<Product> getProductsWithSpecificCriteria(SqlCommand command)
        {
            List<Product> products = new List<Product>();
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
                        p.productQuantity = Convert.ToInt32(reader["productQuantity"]);
                        products.Add(p);
                    }
                }

            return products;
        }

        public static bool isValidProductId(int productId)
        {

            using (SqlConnection connection = DataBaseManager.GetDataBaseConnection())
            {
                connection.Open();
                if (connection == null)
                    throw new Exception("Error Occured While Adding A product Please Try Again \n");
                string query = "select * from products where productId = @productId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@productId", productId);

                    var result = command.ExecuteScalar();

                    bool isFound = result is null ? false : (int)result > 0;
                    return isFound;
                }
            }

        }

        public static int getProductQuantity(int productId)
        {
            using (SqlConnection connection = DataBaseManager.GetDataBaseConnection())
            {
                connection.Open();
                if (connection == null)
                    throw new Exception("Error Occured \n Please Try Later");
                string query = "select productQuantity from products where productId = @productId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   
                    command.Parameters.AddWithValue("@productId", productId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            return reader.GetInt32(0);
                        throw new Exception("Error Occured \n Please Try Later");
                    }
                   
                }
            }

        }

        public static void AddNewProduct(Product p)
        {
            using (SqlConnection connection = DataBaseManager.GetDataBaseConnection())
            {
                connection.Open();
                if (connection == null)
                    throw new Exception("Error Occured While Adding A product Please Try Again \n");
                string query = "insert into products values(@productName,@productDescription," +
                    "@productCategory,@productPrice, @productQuantity);";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (command == null)
                        throw new Exception("Error Occured While Adding A product Please Try Again \n");
                    command.Parameters.AddWithValue("@productName", p.productName);
                    command.Parameters.AddWithValue("@productDescription", p.productDescription);
                    command.Parameters.AddWithValue("@productCategory", p.productCategory.ToString());
                    command.Parameters.AddWithValue("@productPrice", p.productPrice);
                    command.Parameters.AddWithValue("@productQuantity", p.productQuantity);

                    command.ExecuteNonQuery();

                }

            }

        }

        public static void RemoveProduct(int productId)
        {

            using (SqlConnection connection = DataBaseManager.GetDataBaseConnection())
            {
                connection.Open();
                if (connection == null)
                    throw new Exception("Error Occured While Adding A product Please Try Again \n");
                if (!isValidProductId(productId))
                    throw new Exception("Invalid Product Id\n");
                string query = "delete from products where productId = @productId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@productId", productId);
                    command.ExecuteNonQuery();
                }

            }

        }

        public static List<Product> getAllProducts()
        {
            string query = "select * from products";
            using (SqlConnection connection = DataBaseManager.GetDataBaseConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                return getProductsWithSpecificCriteria(command);

            }
              
        }

        public static List<Product> getProductWithSpecificName(string name)
        {
            string query = "select * from products where productName = @name";
            using (SqlConnection connection = DataBaseManager.GetDataBaseConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", name);
                return getProductsWithSpecificCriteria(command);
            }
              

        }

        public static List<Product> getProductWithSpecificCategory(string category)
        {
            string query = "select * from products where productCategory = @category";
            using (SqlConnection connection = DataBaseManager.GetDataBaseConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@category", category);
                return getProductsWithSpecificCriteria(command);

            }

        }
       
        public static void ChangeProductQuantity(int productId, int quantity)
        {
            using(SqlConnection connection = DataBaseManager.GetDataBaseConnection())
            {
                connection.Open();
                if (connection is null)
                    throw new Exception("Error Occured \n");
                string query = "update products set productQuantity = productQuantity + @quantity " +
                    "where productId = @productId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@quantity", quantity);
                    command.Parameters.AddWithValue("@productId", productId);
                    command.ExecuteNonQuery();
                }
            }

        }
        
    }
}
