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
            var connection = new MySqlConnection(connStr);
            connection.Open();
            string querryStr = "select * from tblproducts";
            var command = new MySqlCommand(querryStr, connection);
            var querryOutput = command.ExecuteReader();
            while(querryOutput.Read())
            {

            }


            connection.Close();
        }
    }
}