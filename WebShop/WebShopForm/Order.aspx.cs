using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShopForm.Business;

namespace WebShopForm
{
    /// <summary>
    /// The code behind the webpage responsible for showing a user details of a placed order.
    /// </summary>
    public partial class Order : System.Web.UI.Page
    {
        Controller controller = new Controller();

        /// <summary>
        /// Gets executed every time the page loads.
        /// </summary>
        /// <param name="sender">The object executing this method.</param>
        /// <param name="e">Extra arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;


            User user = controller.GetUser(int.Parse(HttpContext.Current.User.Identity.Name));
            List<Product> productList = controller.GetCart(user);
            double price = controller.GetTotalPriceWithBTW(productList);
            LBLPrice.Text = price.ToString();
            int orderId = controller.DoOrder(user);
            LBLId.Text = orderId.ToString();
            controller.SendConfirmationMail(user, orderId, price);
        }
    }
}