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
    }
}