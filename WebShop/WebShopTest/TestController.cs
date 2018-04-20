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
            Assert.IsTrue(products.Capacity >= 1);
        }
    }
}
