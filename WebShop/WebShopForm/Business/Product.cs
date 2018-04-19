using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShopForm.Business
{
    public class Product
    {
        private int id, stock;
        private string name, picture;
        private double price;

        public int ID
        {
            set { id = value; }
            get { return id; }
        }

        public int Stock
        {
            set { stock = value; }
            get { return stock; }
        }
        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public string Picture
        {
            set { picture = value; }
            get { return picture; }
        }

        public double Price
        {
            set { price = value; }
            get { return price; }
        }
    }
}