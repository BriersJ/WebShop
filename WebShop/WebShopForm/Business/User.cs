using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShopForm.Business
{
    public class User
    {
        private int id;
        private string fullName, loginName, password, email, adress, city;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }
    }
}