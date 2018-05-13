using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebShopForm
{
    /// <summary>
    /// Logs a user out
    /// </summary>
    public partial class Logout : System.Web.UI.Page
    {
        /// <summary>
        /// Logs a user out.
        /// </summary>
        /// <param name="sender">The object executing this method.</param>
        /// <param name="e">Extra arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("products.aspx");
        }
    }
}