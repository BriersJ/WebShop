using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShopForm.Business;
using MySql.Data.MySqlClient;
using System.Net;

namespace WebShopForm.Persistence
{
    /// <summary>
    /// This class is responsible for all communication to the database.
    /// </summary>
    public class PersistenceCode
    {
        string connStr = "database=dbshop;password=Test123;user id=nillo_taak;SSL Mode=none;server=";

        /// <summary>
        /// Creates a new instance of the <code>PersistenceCode</code> class.
        /// </summary>
        public PersistenceCode()
        {
            connStr += Dns.GetHostAddresses("nillo.duckdns.org")[0];
        }

        /// <summary>
        /// Gets a list of all products in the database.
        /// </summary>
        /// <returns>A list of all products</returns>
        public List<Product> GetProducts()
        {
            var productList = new List<Product>();
            var connection = new MySqlConnection(connStr);
            connection.Open();
            string querryStr = "select * from tblproducts";
            var command = new MySqlCommand(querryStr, connection);
            var querryOutput = command.ExecuteReader();
            while (querryOutput.Read())
            {
                var product = new Product()
                {
                    ID = Convert.ToInt32(querryOutput["ID"]),
                    Name = Convert.ToString(querryOutput["Name"]),
                    Picture = Convert.ToString(querryOutput["Picture"]),
                    Price = Convert.ToDouble(querryOutput["Price"]),
                    Stock = Convert.ToInt32(querryOutput["Stock"])
                };
                productList.Add(product);
            }


            connection.Close();
            return productList;
        }

        /// <summary>
        /// Adds a <code>Product</code> to a <code>User</code>'s cart.
        /// </summary>
        /// <param name="product">The <code>Product</code> you want to add</param>
        /// <param name="user">The matching <code>User</code></param>
        /// <param name="amount">The amount that should be added</param>
        public void AddToCart(Product product, User user, int amount)
        {
            var connection = new MySqlConnection(connStr);
            connection.Open();
            string querryStr = $"insert into tblcarts (ProductID, UserID, Amount) values('{ product.ID  }', '{ user.ID }', '{ amount }')";
            var command = new MySqlCommand(querryStr, connection);
            command.ExecuteNonQuery();
            SetStock(product.ID, GetStock(product.ID) - amount);
            connection.Close();
        }

        /// <summary>
        /// Gets the amount of a certain <code>Product</code> from a certain <code>User</code>'s cart.
        /// </summary>
        /// <param name="userID">The <code>User</code>'s ID</param>
        /// <param name="productID">The <code>Product</code>'s ID</param>
        /// <returns>The amount the <code>User</code> has ordered of this <code>Product</code></returns>
        public int GetItemsInCart(int userID, int productID)
        {
            var connection = new MySqlConnection(connStr);
            connection.Open();
            string querryStr = $"select * from tblcarts where userid = { userID } and productid = { productID }";
            var command = new MySqlCommand(querryStr, connection);
            var querryOutput = command.ExecuteReader();
            if (!querryOutput.Read())
                throw new Exception($"Cart with userID { userID } and productID { productID } does not exist");

            int stock = Convert.ToInt32(querryOutput["Amount"]);

            connection.Close();
            return stock;
        }

        /// <summary>
        /// Checks if a certain <code>User</code> has a certain <code>Product</code> in their cart.
        /// </summary>
        /// <param name="user">The <code>User</code> whose cart should be checked</param>
        /// <param name="product">The <code>Product</code> that should be looked for</param>
        /// <returns><code>true</code> if the <code>User</code> has this <code>Product</code> in their cart, <code>false</code> otherwise</returns>
        public bool HasItemInCart(User user, Product product)
        {
            var connection = new MySqlConnection(connStr);
            connection.Open();
            string querryStr = $"select * from tblcarts where userid = { user.ID } and productid = { product.ID }";
            var command = new MySqlCommand(querryStr, connection);
            var querryOutput = command.ExecuteReader();
            bool userExists = querryOutput.HasRows;
            connection.Close();
            return userExists;
        }

        /// <summary>
        /// Remover all items from a <code>User</code>'s cart.
        /// </summary>
        /// <param name="user">The <code>User</code> whose cart should be cleared</param>
        public void ClearCart(User user)
        {
            List<Product> products = GetCart(user);
            foreach (Product product in products)
            {
                RemoveFromCart(product, user);
            }
        }

        private void MakeOrder(User user)
        {
            var connection = new MySqlConnection(connStr);
            connection.Open();
            string querryStr = $"insert into tblorders (userid, date) values ( { user.ID } , now())";
            var command = new MySqlCommand(querryStr, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        private int GetLastOrder()
        {
            var connection = new MySqlConnection(connStr);
            connection.Open();
            string querryStr = "select max(id) as lastid from tblorders";
            var command = new MySqlCommand(querryStr, connection);
            var querryOutput = command.ExecuteReader();
            if (!querryOutput.Read())
                throw new Exception("There are no orders");
            int id = Convert.ToInt32(querryOutput["lastid"]);
            connection.Close();
            return id;
        }

        /// <summary>
        /// Place an order based on a certain <code>User</code>'s cart
        /// </summary>
        /// <param name="user">The <code>User</code> who places an order.</param>
        /// <returns>The ID of the order</returns>
        public int DoOrder(User user)
        {
            List<Product> cart = GetCart(user);
            MakeOrder(user);
            int orderId = GetLastOrder();
            foreach (Product product in cart)
            {
                AddToOrder(orderId, product);
                RemoveFromCart_NoReturnItems(product, user);
            }
            return orderId;
        }

        private void AddToOrder(int orderId, Product product)
        {
            var connection = new MySqlConnection(connStr);
            connection.Open();
            string priceStr = product.Price.ToString().Replace(',', '.');
            string querryStr = $"insert into tblproductsorder (productid, orderid, price, amount) values ({ product.ID },{ orderId },{ priceStr },{ product.AmountOrdered })";
            var command = new MySqlCommand(querryStr, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void RemoveFromCart_NoReturnItems(Product product, User user)
        {
            var connection = new MySqlConnection(connStr);
            connection.Open();
            string querryStr = $"delete from tblcarts where productid = { product.ID } and userid = { user.ID }";
            var command = new MySqlCommand(querryStr, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Sets the stock of a certain <code>Product</code>
        /// </summary>
        /// <param name="id">The matching ID</param>
        /// <param name="amount">The new stock</param>
        public void SetStock(int id, int amount)
        {
            var connection = new MySqlConnection(connStr);
            connection.Open();
            string querryStr = $"update tblproducts set Stock = { amount } where id = { id }";
            var command = new MySqlCommand(querryStr, connection);
            var querryOutput = command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Gets the stock of a certain <code>Product</code>.
        /// </summary>
        /// <param name="id">The <code>Product</code>'s ID</param>
        /// <returns>The stock of the product <code>Product</code></returns>
        public int GetStock(int id)
        {
            var connection = new MySqlConnection(connStr);
            connection.Open();
            string querryStr = $"select * from tblproducts where id = { id }";
            var command = new MySqlCommand(querryStr, connection);
            var querryOutput = command.ExecuteReader();
            if (!querryOutput.Read())
                throw new Exception($"Product with id { id } does not exist");

            int stock = Convert.ToInt32(querryOutput["Stock"]);

            connection.Close();
            return stock;
        }

        /// <summary>
        /// Removes a certain <code>Product</code> from a <code>User</code>'s cart
        /// </summary>
        /// <param name="product">The <code>Product</code> you want to remove</param>
        /// <param name="user">The matching <code>User</code> that</param>
        public void RemoveFromCart(Product product, User user)
        {
            int amount = GetItemsInCart(user.ID, product.ID);
            var connection = new MySqlConnection(connStr);
            connection.Open();
            string querryStr = $"delete from tblcarts where productid = { product.ID } and userid = { user.ID }";
            var command = new MySqlCommand(querryStr, connection);
            command.ExecuteNonQuery();
            SetStock(product.ID, GetStock(product.ID) + amount);
            connection.Close();
        }

        /// <summary>
        /// Gets a User's cart.
        /// </summary>
        /// <param name="user">The matching <code>User</code> object</param>
        /// <returns>A list of products that are in the User's cart</returns>
        public List<Product> GetCart(User user)
        {
            var productList = new List<Product>();
            var connection = new MySqlConnection(connStr);
            connection.Open();
            string querryStr = $"select * from tblproducts inner join tblcarts on tblcarts.productid = tblproducts.id where userid = { user.ID }";
            var command = new MySqlCommand(querryStr, connection);
            var querryOutput = command.ExecuteReader();
            while (querryOutput.Read())
            {
                var product = new Product()
                {
                    ID = Convert.ToInt32(querryOutput["ID"]),
                    Name = Convert.ToString(querryOutput["Name"]),
                    Picture = Convert.ToString(querryOutput["Picture"]),
                    Price = Convert.ToDouble(querryOutput["Price"]),
                    Stock = Convert.ToInt32(querryOutput["Stock"]),
                    AmountOrdered = Convert.ToInt32(querryOutput["amount"])
                };
                productList.Add(product);
            }


            connection.Close();
            return productList;
        }

        /// <summary>
        /// Gets a product based on it's ID.
        /// </summary>
        /// <param name="id">The product's ID</param>
        /// <returns>The matching <code>Product</code> object</returns>
        public Product GetProduct(int id)
        {
            var connection = new MySqlConnection(connStr);
            connection.Open();
            string querryStr = $"select * from tblproducts where id = { id }";
            var command = new MySqlCommand(querryStr, connection);
            var querryOutput = command.ExecuteReader();
            if (!querryOutput.Read())
                throw new Exception($"Product with id { id } does not exist");

            var product = new Product()
            {
                ID = Convert.ToInt32(querryOutput["ID"]),
                Name = Convert.ToString(querryOutput["Name"]),
                Picture = Convert.ToString(querryOutput["Picture"]),
                Price = Convert.ToDouble(querryOutput["Price"]),
                Stock = Convert.ToInt32(querryOutput["Stock"])
            };



            connection.Close();
            return product;
        }

        /// <summary>
        /// Checks if certain credentials are correct.
        /// </summary>
        /// <param name="loginName">The username to check</param>
        /// <param name="password">The user's password (not the hash)</param>
        /// <returns><code>true</code> if the credentials are correct, <code>false</code> otherwise</returns>
        public bool Login(string loginName, string password)
        {
            var connection = new MySqlConnection(connStr);
            connection.Open();
            string querryStr = $"select * from tblusers where loginname = '{ loginName }' and password = '{ Hasher.HashOf(password) }'";
            var command = new MySqlCommand(querryStr, connection);
            var querryOutput = command.ExecuteReader();
            bool credentialsAreCorrect = querryOutput.HasRows;
            connection.Close();
            return credentialsAreCorrect;
        }

        /// <summary>
        /// Checks if a certain user exists in the database.
        /// </summary>
        /// <param name="loginName">The username to look for</param>
        /// <returns><code>true</code> if the user exists, <code>false</code> otherwise</returns>
        public bool UserExists(string loginName)
        {
            var connection = new MySqlConnection(connStr);
            connection.Open();
            string querryStr = $"select * from tblusers where loginname = '{ loginName }'";
            var command = new MySqlCommand(querryStr, connection);
            var querryOutput = command.ExecuteReader();
            bool userExists = querryOutput.HasRows;
            connection.Close();
            return userExists;
        }

        /// <summary>
        /// Gets a certain user based on their username.
        /// </summary>
        /// <param name="loginName">The user's username</param>
        /// <returns>The <code>User</code> object matching the username</returns>
        public User GetUser(string loginName)
        {
            var connection = new MySqlConnection(connStr);
            connection.Open();
            string querryStr = $"select * from tblusers where loginname = '{ loginName }'";
            var command = new MySqlCommand(querryStr, connection);
            var querryOutput = command.ExecuteReader();
            if (!querryOutput.Read())
                throw new Exception($"User { loginName } does not exist");

            var user = new User
            {
                Adress = Convert.ToString(querryOutput["Adress"]),
                City = Convert.ToString(querryOutput["City"]),
                Email = Convert.ToString(querryOutput["Email"]),
                FullName = Convert.ToString(querryOutput["FullName"]),
                LoginName = Convert.ToString(querryOutput["LoginName"]),
                Password = Convert.ToString(querryOutput["Password"]),
                ID = Convert.ToInt32(querryOutput["ID"]),
            };


            connection.Close();
            return user;
        }

        /// <summary>
        /// Gets a certain user based on their id.
        /// </summary>
        /// <param name="userID">The user's id</param>
        /// <returns>The <code>User</code> object matching the id</returns>
        public User GetUser(int userID)
        {
            var connection = new MySqlConnection(connStr);
            connection.Open();
            string querryStr = $"select * from tblusers where id = '{ userID }'";
            var command = new MySqlCommand(querryStr, connection);
            var querryOutput = command.ExecuteReader();
            if (!querryOutput.Read())
                throw new Exception($"User with id { userID } does not exist");

            var user = new User
            {
                Adress = Convert.ToString(querryOutput["Adress"]),
                City = Convert.ToString(querryOutput["City"]),
                Email = Convert.ToString(querryOutput["Email"]),
                FullName = Convert.ToString(querryOutput["FullName"]),
                LoginName = Convert.ToString(querryOutput["LoginName"]),
                Password = Convert.ToString(querryOutput["Password"]),
                ID = Convert.ToInt32(querryOutput["ID"]),
            };


            connection.Close();
            return user;
        }
    }
}