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
    }
}
