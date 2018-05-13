using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShopForm.Business;

namespace WebShopForm
{
    /// <summary>
    /// The wabsite's login page.
    /// </summary>
    public partial class Login : System.Web.UI.Page
    {
        Controller controller = new Controller();
        
        /// <summary>
        /// Gets executed every time the page loads.
        /// </summary>
        /// <param name="sender">The object executing this method.</param>
        /// <param name="e">Extra arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Tries to log in a user.
        /// </summary>
        /// <param name="sender">The object executing this method.</param>
        /// <param name="e">Extra arguments</param>
        protected void BNTLogin_Click(object sender, EventArgs e)
        {
            if (controller.Login(TXTUser.Text, TXTPassword.Text))
            {
                User user = controller.GetUser(TXTUser.Text);
                FormsAuthentication.RedirectFromLoginPage(user.ID.ToString(), false);
            }
            else
            {
                LBLError.Text = "Invalid username or password, try again...";
            }
        }
    }
}