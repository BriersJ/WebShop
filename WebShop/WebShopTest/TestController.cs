using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebShopForm.Business;

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
            var product = controller.GetProduct(1);
            Assert.AreEqual(product.ID, 1);
            Assert.AreEqual(product.Name, "Test1");
            Assert.AreEqual(product.Picture, "Test1.jpg");
            Assert.AreEqual(product.Stock, 60);
            Assert.AreEqual(product.Price, 500.45);
        }

        [TestMethod]
        public void CartMisc()
        {
            User user = controller.GetUser(1);
            throw new NotImplementedException();
        }
    }
}
