using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShopForm.Business;
using MySql.Data.MySqlClient;

namespace WebShopForm.Persistence
{
    public class PersistenceCode
    {
        string connStr = "server=localhost;database=dbshop;password=Test123;user id=root";

        public List<Product> GetProducts()
        {
            var productList = new List<Product>();
            var connection = new MySqlConnection(connStr);
            connection.Open();
            string querryStr = "select * from tblproducts";
            var command = new MySqlCommand(querryStr, connection);
            var querryOutput = command.ExecuteReader();
            while (querryOutput.Read())
            {
                var product = new Product()
                {
                    ID = Convert.ToInt32(querryOutput["ID"]),
                    Name = Convert.ToString(querryOutput["Name"]),
                    Picture = Convert.ToString(querryOutput["Picture"]),
                    Price = Convert.ToDouble(querryOutput["Price"]),
                    Stock = Convert.ToInt32(querryOutput["Stock"])
                };
                productList.Add(product);
            }


            connection.Close();
            return productList;
        }
    }
}