using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShopForm.Persistence;

namespace WebShopForm.Business
{
    public class Controller
    {
        PersistenceCode persistenceCode = new PersistenceCode();

        public List<Product> GetProducts()
        {
            return persistenceCode.GetProducts();
        }

        public bool Login(string loginName, string password)
        {
            return persistenceCode.Login(loginName, password);
        }

        public bool UserExists(string loginName)
        {
            return persistenceCode.UserExists(loginName);
        }

        public User GetUser(string loginName)
        {
            return persistenceCode.GetUser(loginName);
        }

        public User GetUser(int id)
        {
            return persistenceCode.GetUser(id);
        }

        public Product GetProduct(int id)
        {
            return persistenceCode.GetProduct(id);
        }

        public List<Product> GetCart(User user)
        {
            return persistenceCode.GetCart(user);
        }

        public void AddToCart(Product product, User user, int amount)
        {
            persistenceCode.AddToCart(product, user, amount);
        }

        public void RemoveFromCart(Product product, User user)
        {
            persistenceCode.RemoveFromCart(product, user);
        }

        public int GetStock(int id)
        {
            return persistenceCode.GetStock(id);
        }

        public void SetStock(int id, int amount)
        {
            persistenceCode.SetStock(id, amount);
        }

        public int GetItemsInCart(int userID, int productID)
        {
            return persistenceCode.GetItemsInCart(userID, productID);
        }

        public void ClearCart(User user)
        {
            persistenceCode.ClearCart(user);
        }

        public bool HasItemInCart(User user, Product product)
        {
            return persistenceCode.HasItemInCart(user, product);
        }

        public double GetTotalPrice(List<Product> productList)
        {
            double price = 0;
            foreach (Product p in productList)
            {
                price += p.TotalPrice;
            }
            return Math.Round(price, 2);
        }

        public double GetTotalPriceWithBTW(List<Product> productList)
        {
            double price = 0;
            foreach (Product p in productList)
            {
                price += p.TotalPrice;
            }
            return Math.Round(price * 1.21, 2);
        }

        public double GetBTW(List<Product> productList)
        {
            double price = 0;
            foreach (Product p in productList)
            {
                price += p.TotalPrice;
            }
            return Math.Round(price * 0.21, 2);
        }

        public int DoOrder(User user)
        {
            return persistenceCode.DoOrder(user);
        }

        public void SendConfirmationMail(User user, int orderId, double totalPrice)
        {
            MailSender mailSender = new MailSender();
            mailSender.SendMail(user, orderId, totalPrice);
        }
    }
}