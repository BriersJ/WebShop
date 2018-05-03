using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShopForm.Business;

namespace WebShopForm
{
    public partial class Order : System.Web.UI.Page
    {
        Controller controller = new Controller();

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
        

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Products.aspx");
        }
    }
}