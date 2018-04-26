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
    public partial class Login : System.Web.UI.Page
    {
        Controller controller = new Controller();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

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