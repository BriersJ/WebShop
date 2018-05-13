using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShopForm.Business;
using MySql.Data.MySqlClient;
using System.Net;

namespace WebShopForm.Persistence
{
    public class PersistenceCode
    {
        string connStr = "database=dbshop;password=Test123;user id=nillo_taak;SSL Mode=none;server=";

        public PersistenceCode()
        {
            connStr += Dns.GetHostAddresses("nillo.duckdns.org")[0];
        }

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

        public void ClearCart(User user)
        {
            List<Product> products = GetCart(user);
            foreach (Product product in products)
            {
                RemoveFromCart(product, user);
            }
        }

        public void MakeOrder(User user)
        {
            var connection = new MySqlConnection(connStr);
            connection.Open();
            string querryStr = $"insert into tblorders (userid, date) values ( { user.ID } , now())";
            var command = new MySqlCommand(querryStr, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public int GetLastOrder()
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

        public void AddToOrder(int orderId, Product product)
        {
            var connection = new MySqlConnection(connStr);
            connection.Open();
            string priceStr = product.Price.ToString().Replace(',', '.');
            string querryStr = $"insert into tblproductsorder (productid, orderid, price, amount) values ({ product.ID },{ orderId },{ priceStr },{ product.AmountOrdered })";
            var command = new MySqlCommand(querryStr, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void RemoveFromCart_NoReturnItems(Product product, User user)
        {
            var connection = new MySqlConnection(connStr);
            connection.Open();
            string querryStr = $"delete from tblcarts where productid = { product.ID } and userid = { user.ID }";
            var command = new MySqlCommand(querryStr, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void SetStock(int id, int amount)
        {
            var connection = new MySqlConnection(connStr);
            connection.Open();
            string querryStr = $"update tblproducts set Stock = { amount } where id = { id }";
            var command = new MySqlCommand(querryStr, connection);
            var querryOutput = command.ExecuteNonQuery();
            connection.Close();
        }

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