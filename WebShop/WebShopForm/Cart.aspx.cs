using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShopForm.Business;

namespace WebShopForm
{
    public partial class Cart : System.Web.UI.Page
    {
        Controller controller = new Controller();

        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateGridView();
        }

        protected void GVCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            int productID = Convert.ToInt32(GVCart.Rows[index].Cells[0].Text);
            Product product = controller.GetProduct(productID);
            User user = controller.GetUser(3);
            controller.RemoveFromCart(product, user);
            Response.Redirect("Cart.aspx");
        }

        private void UpdateGridView()
        {
            User user = controller.GetUser(3);
            GVCart.DataSource = controller.GetCart(user);
            GVCart.DataBind();
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Products.aspx");
        }
    }
}