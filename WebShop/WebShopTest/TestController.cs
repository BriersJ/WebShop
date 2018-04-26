using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebShopForm.Business;
using System.Collections.Generic;

namespace WebShopTest
{
    [TestClass]
    public class TestController
    {
        private Controller controller;

        [TestInitialize]
        public void MakeController()
        {
            controller = new Controller();
        }

        [TestMethod]
        public void GetProducts_NonEmptyDatabase_Success()
        {
            var products = controller.GetProducts();
            Product product = products[0];
            Assert.AreEqual(product.ID, 1);
            Assert.AreEqual(product.Name, "Test1");
            Assert.AreEqual(product.Picture, "Test1.jpg");
            Assert.AreEqual(product.Stock, 60);
            Assert.AreEqual(product.Price, 500.45);
        }

        [TestMethod]
        public void Login_CorrectCredentials_True()
        {
            Assert.IsTrue(controller.Login("Test", "Test123"));
        }

        [TestMethod]
        public void Login_IncorrectCredentials_False()
        {
            Assert.IsFalse(controller.Login("Test", "test123"));
        }

        [TestMethod]
        public void UserExists_ExistingUser_True()
        {
            Assert.IsTrue(controller.UserExists("Test"));
        }

        [TestMethod]
        public void UserExists_NonexistingUser_False()
        {
            Assert.IsFalse(controller.UserExists("NonExistingTest"));
        }


        [TestMethod]
        public void GetUser_LoginName_User()
        {
            User user = controller.GetUser("Test");
            Assert.AreEqual("TestAdress", user.Adress);
            Assert.AreEqual("TestCity", user.City);
            Assert.AreEqual("test@mailinator.com", user.Email);
            Assert.AreEqual("Test User", user.FullName);
            Assert.AreEqual(1, user.ID);
            Assert.AreEqual("Test", user.LoginName);
            Assert.AreEqual("Test123", user.Password);
        }

        [TestMethod]
        public void GetUser_ID_User()
        {
            User user = controller.GetUser(1);
            Assert.AreEqual("TestAdress", user.Adress);
            Assert.AreEqual("TestCity", user.City);
            Assert.AreEqual("test@mailinator.com", user.Email);
            Assert.AreEqual("Test User", user.FullName);
            Assert.AreEqual("Test", user.LoginName);
            Assert.AreEqual(1, user.ID);
            Assert.AreEqual("Test123", user.Password);
        }

        [TestMethod]
        public void GetProduct_ProductID_Product()
        {
            Product product = controller.GetProduct(1);
            Assert.AreEqual(product.ID, 1);
            Assert.AreEqual(product.Name, "Test1");
            Assert.AreEqual(product.Picture, "Test1.jpg");
            Assert.AreEqual(product.Stock, 60);
            Assert.AreEqual(product.Price, 500.45);
        }

        [TestMethod]
        public void GetCart_UserWithEmptyCart_EmptyList()
        {
            User user = controller.GetUser(1);
            List<Product> productlist = controller.GetCart(user);
            Assert.AreEqual(0, productlist.Count);
        }

        [TestMethod]
        public void GetCart_UserWithCart_List()
        {
            User user = controller.GetUser(2);
            List<Product> productlist = controller.GetCart(user);
            Product product = productlist[1];
            Assert.AreEqual(product.ID, 2);
            Assert.AreEqual(product.Name, "Test2");
            Assert.AreEqual(product.Picture, "Test2.jpg");
            Assert.AreEqual(product.Stock, 125);
            Assert.AreEqual(product.Price, 40.99);
            Assert.AreEqual(product.AmountOrdered, 60);
        }

        [TestMethod]
        public void AddToCartAndRemoveFromCArt_User_ChangedCart()
        {
            User user = controller.GetUser(1);
            Product product = controller.GetProduct(1);
            int stock = product.Stock;

            //Add and verify a product to the user's cart
            controller.AddToCart(product, user, 20);
            List<Product> productlist = controller.GetCart(user);
            Product firstProduct = productlist[0];
            Assert.AreEqual(product.ID, 1);
            Assert.AreEqual(1, productlist.Count);
            Assert.AreEqual(stock - 20, controller.GetProduct(1).Stock); // Check if there qre now 20 less avaidable of this product

            //Remove from the user's cart
            controller.RemoveFromCart(product, user);
            productlist = controller.GetCart(user);
            Assert.AreEqual(0, productlist.Count);
            Assert.AreEqual(stock, controller.GetProduct(1).Stock); // Check if the products are avaidable again
        }

        [TestMethod]
        public void SetStock_Amount_ChangedStock()
        {
            controller.SetStock(1, 80);
            int result = controller.GetStock(1);
            Assert.AreEqual(80, result);

            controller.SetStock(1, 60);
            result = controller.GetStock(1);
            Assert.AreEqual(60, result);
        }

        [TestMethod]
        public void GetStock_Test1Id_Test1Stock()
        {
            int result = controller.GetStock(1);
            Assert.AreEqual(60, result);
        }

        [TestMethod]
        public void ClearCart_User_EmptyCart()
        {
            User user = controller.GetUser(1);
            Product product = controller.GetProduct(1);
            controller.AddToCart(product, user, 30);
            List<Product> cart = controller.GetCart(user);
            Assert.AreEqual(30, cart[0].AmountOrdered);
            controller.ClearCart(user);
            cart = controller.GetCart(user);
            Assert.AreEqual(0, cart.Count);
            Assert.AreEqual(60, controller.GetProduct(1).Stock);
        }

        [TestMethod]
        public void GetItemsInCart_User2Product1_60()
        {
            int result = controller.GetItemsInCart(2, 2);
            Assert.AreEqual(60, result);
        }
    }
}
