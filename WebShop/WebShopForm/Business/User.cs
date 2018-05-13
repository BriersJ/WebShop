using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShopForm.Business
{
    /// <summary>
    /// This class represents a <code>User</code> in the database.
    /// </summary>
    public class User
    {
        private int id;
        private string fullName, loginName, password, email, adress, city;

        /// <summary>
        /// This is used to give every <code>User</code> an individual tracking number.
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// The user's full name.
        /// </summary>
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        /// <summary>
        /// The name this <code>User</code> uses to log in.
        /// </summary>
        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }

        /// <summary>
        /// The hash of this <code>User</code>'s password.
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// The <code>User</code>'s E-mail adress
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// The <code>User</code>'s adress.
        /// </summary>
        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        /// <summary>
        /// The <code>User</code>'s city
        /// </summary>
        public string City
        {
            get { return city; }
            set { city = value; }
        }
    }
}