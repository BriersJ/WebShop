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
            Assert.AreEqual(0, productlist.Capacity);
        }

        [TestMethod]
        public void GetCart_UserWithCart_List()
        {
            User user = controller.GetUser(2);
            List<Product> productlist = controller.GetCart(user);
            Product product = productlist[0];
            Assert.AreEqual(product.ID, 2);
            Assert.AreEqual(product.Name, "Test2");
            Assert.AreEqual(product.Picture, "Test2.jpg");
            Assert.AreEqual(product.Stock, 125);
            Assert.AreEqual(product.Price, 40.99);
        }

        [TestMethod]
        public void AddToCartAndRemoveFromCArt_User_ChangedCart()
        {
            User user = controller.GetUser(2);
            Product product = controller.GetProduct(1);
            int stock = product.Stock;

            //Add and verify a product to the user's cart
            controller.AddToCart(product, user, 20);
            List<Product> productlist = controller.GetCart(user);
            Product firstProduct = productlist[0];
            Assert.AreEqual(product.ID, 1);
            Assert.AreEqual(2, productlist.Capacity);
            Assert.AreEqual(stock - 20, controller.GetProduct(1).Stock); // Check if there qre now 20 less avaidable of this product

            //Remove the user's cart
            controller.RemoveFromCart(product, user);
            productlist = controller.GetCart(user);
            firstProduct = productlist[0];
            Assert.AreEqual(product.ID, 2);
            Assert.AreEqual(1, productlist.Capacity);
            Assert.AreEqual(stock, controller.GetProduct(1).Stock); // Check if the products are avaidable again
        }

        [TestMethod]
        public void ClearCart_User_EmptyCart()
        {
            throw new NotImplementedException();
        }
    }
}
