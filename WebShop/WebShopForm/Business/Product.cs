using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShopForm.Business
{
    /// <summary>
    /// This class represents a <code>Product</code> entry in the database
    /// </summary>
    public class Product
    {
        private int id, stock, amountOrdered;
        private string name, picture;
        private double price;

        /// <summary>
        /// This is used to give all <code>Product</code>s an individual tracking number.
        /// </summary>
        public int ID
        {
            set { id = value; }
            get { return id; }
        }

        /// <summary>
        /// The total price (amountordered * price)
        /// </summary>
        public double TotalPrice
        {
            get { return amountOrdered * price; }
        }

        /// <summary>
        /// The amount ot times this <code>Product</code> is ordered.
        /// This is only used in a cart or an order (will not be set otherwise).
        /// </summary>
        public int AmountOrdered
        {
            set { amountOrdered = value; }
            get { return amountOrdered; }
        }

        /// <summary>
        /// The avaidable amount of this product.
        /// </summary>
        public int Stock
        {
            set { stock = value; }
            get { return stock; }
        }

        /// <summary>
        /// The name of the product
        /// </summary>
        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        /// <summary>
        /// The <code>Product</code>'s image file to look for.
        /// </summary>
        public string Picture
        {
            set { picture = value; }
            get { return picture; }
        }

        /// <summary>
        /// The price of a single instance of this product.
        /// </summary>
        public double Price
        {
            set { price = value; }
            get { return price; }
        }
    }
}