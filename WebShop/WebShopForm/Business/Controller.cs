using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShopForm.Persistence;

namespace WebShopForm.Business
{
    /// <summary>
    /// Controlls all other Business classes
    /// </summary>
    public class Controller
    {
        PersistenceCode persistenceCode = new PersistenceCode();

        /// <summary>
        /// Gets a list of all products in the database.
        /// </summary>
        /// <returns>A list of all products</returns>
        public List<Product> GetProducts()
        {
            return persistenceCode.GetProducts();
        }

        /// <summary>
        /// Checks if certain credentials are correct.
        /// </summary>
        /// <param name="loginName">The username to check</param>
        /// <param name="password">The user's password (not the hash)</param>
        /// <returns><code>true</code> if the credentials are correct, <code>false</code> otherwise</returns>
        public bool Login(string loginName, string password)
        {
            return persistenceCode.Login(loginName,password);
        }

        /// <summary>
        /// Checks if a certain user exists in the database.
        /// </summary>
        /// <param name="loginName">The username to look for</param>
        /// <returns><code>true</code> if the user exists, <code>false</code> otherwise</returns>
        public bool UserExists(string loginName)
        {
            return persistenceCode.UserExists(loginName);
        }

        /// <summary>
        /// Gets a certain user based on their username.
        /// </summary>
        /// <param name="loginName">The user's username</param>
        /// <returns>The <code>User</code> object matching the username</returns>
        public User GetUser(string loginName)
        {
            return persistenceCode.GetUser(loginName);
        }

        /// <summary>
        /// Gets a certain user based on their id.
        /// </summary>
        /// <param name="id">The user's id</param>
        /// <returns>The <code>User</code> object matching the id</returns>
        public User GetUser(int id)
        {
            return persistenceCode.GetUser(id);
        }

        /// <summary>
        /// Gets a product based on it's ID.
        /// </summary>
        /// <param name="id">The product's ID</param>
        /// <returns>The matching <code>Product</code> object</returns>
        public Product GetProduct(int id)
        {
            return persistenceCode.GetProduct(id);
        }

        /// <summary>
        /// Gets a User's cart.
        /// </summary>
        /// <param name="user">The matching <code>User</code> object</param>
        /// <returns>A list of products that are in the User's cart</returns>
        public List<Product> GetCart(User user)
        {
            return persistenceCode.GetCart(user);
        }


        /// <summary>
        /// Adds a <code>Product</code> to a <code>User</code>'s cart.
        /// </summary>
        /// <param name="product">The <code>Product</code> you want to add</param>
        /// <param name="user">The matching <code>User</code></param>
        /// <param name="amount">The amount that should be added</param>
        public void AddToCart(Product product, User user, int amount)
        {
            persistenceCode.AddToCart(product, user, amount);
        }

        /// <summary>
        /// Removes a certain <code>Product</code> from a <code>User</code>'s cart
        /// </summary>
        /// <param name="product">The <code>Product</code> you want to remove</param>
        /// <param name="user">The matching <code>User</code> that</param>
        public void RemoveFromCart(Product product, User user)
        {
            persistenceCode.RemoveFromCart(product, user);
        }

        /// <summary>
        /// Gets the stock of a certain <code>Product</code>.
        /// </summary>
        /// <param name="id">The <code>Product</code>'s ID</param>
        /// <returns>The stock of the product <code>Product</code></returns>
        public int GetStock(int id)
        {
            return persistenceCode.GetStock(id);
        }

        /// <summary>
        /// Sets the stock of a certain <code>Product</code>
        /// </summary>
        /// <param name="id">The matching ID</param>
        /// <param name="amount">The new stock</param>
        public void SetStock(int id, int amount)
        {
            persistenceCode.SetStock(id, amount);
        }

        /// <summary>
        /// Gets the amount of a certain <code>Product</code> from a certain <code>User</code>'s cart.
        /// </summary>
        /// <param name="userID">The <code>User</code>'s ID</param>
        /// <param name="productID">The <code>Product</code>'s ID</param>
        /// <returns>The amount the <code>User</code> has ordered of this <code>Product</code></returns>
        public int GetItemsInCart(int userID, int productID)
        {
            return persistenceCode.GetItemsInCart(userID, productID);
        }

        /// <summary>
        /// Remover all items from a <code>User</code>'s cart.
        /// </summary>
        /// <param name="user">The <code>User</code> whose cart should be cleared</param>
        public void ClearCart(User user)
        {
            persistenceCode.ClearCart(user);
        }

        /// <summary>
        /// Checks if a certain <code>User</code> has a certain <code>Product</code> in their cart.
        /// </summary>
        /// <param name="user">The <code>User</code> whose cart should be checked</param>
        /// <param name="product">The <code>Product</code> that should be looked for</param>
        /// <returns><code>true</code> if the <code>User</code> has this <code>Product</code> in their cart, <code>false</code> otherwise</returns>
        public bool HasItemInCart(User user, Product product)
        {
            return persistenceCode.HasItemInCart(user, product);
        }

        /// <summary>
        /// Gets the total price (amount * price)
        /// </summary>
        /// <param name="productList">A list of <code>Product</code>s</param>
        /// <returns>The total price of every <code>Product</code> int the list combined</returns>
        public double GetTotalPrice(List<Product> productList)
        {
            double price = 0;
            foreach (Product p in productList)
            {
                price += p.TotalPrice;
            }
            return Math.Round(price, 2);
        }

        /// <summary>
        /// Gets the total price including BTW (amount * price * 1.21)
        /// </summary>
        /// <param name="productList">A list of <code>Product</code>s</param>
        /// <returns>The total price of every <code>Product</code> int the list combined</returns>
        public double GetTotalPriceWithBTW(List<Product> productList)
        {
            double price = 0;
            foreach (Product p in productList)
            {
                price += p.TotalPrice;
            }
            return Math.Round(price * 1.21, 2);
        }

        /// <summary>
        /// Gets the total BTW (amount * price * 0.21)
        /// </summary>
        /// <param name="productList">A list of <code>Product</code>s</param>
        /// <returns>The total BTW of every <code>Product</code> int the list combined</returns>
        public double GetBTW(List<Product> productList)
        {
            double price = 0;
            foreach (Product p in productList)
            {
                price += p.TotalPrice;
            }
            return Math.Round(price * 0.21, 2);
        }

        /// <summary>
        /// Place an order based on a certain <code>User</code>'s cart
        /// </summary>
        /// <param name="user">The <code>User</code> who places an order.</param>
        /// <returns>The ID of the order</returns>
        public int DoOrder(User user)
        {
            return persistenceCode.DoOrder(user);
        }

        /// <summary>
        /// Send a confirmation E-mail to a certain <code>User</code>.
        /// </summary>
        /// <param name="user">The <code>User</code> who should receive a mail</param>
        /// <param name="orderId">The order ID</param>
        /// <param name="totalPrice">The total price that should be payed</param>
        public void SendConfirmationMail(User user, int orderId, double totalPrice)
        {
            MailSender mailSender = new MailSender();
            mailSender.SendMail(user, orderId, totalPrice);
        }
    }
}