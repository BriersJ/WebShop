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
        private bool hasItemsInCart = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateGridView();
        }

        protected void GVCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(Context.User.Identity.Name);
            int index = e.RowIndex;
            int productID = Convert.ToInt32(GVCart.Rows[index].Cells[0].Text);
            Product product = controller.GetProduct(productID);
            User user = controller.GetUser(id);
            controller.RemoveFromCart(product, user);
            Response.Redirect("Cart.aspx");
        }

        private void UpdateGridView()
        {
            int id = Convert.ToInt32(Context.User.Identity.Name);
            User user = controller.GetUser(id);
            var productList = controller.GetCart(user);

            hasItemsInCart = productList.Count != 0;
            if (!hasItemsInCart)
                ClearUnusedLabels();
            else
                FillGridView(productList);
        }

        private void FillGridView(List<Product> productList)
        {
            GVCart.DataSource = productList;
            GVCart.DataBind();
            LBLPriceNoBTW.Text = controller.GetTotalPrice(productList).ToString();
            LBLBTW.Text = controller.GetBTW(productList).ToString();
            LBLPriceWithBTW.Text = controller.GetTotalPriceWithBTW(productList).ToString();
        }

        private void ClearUnusedLabels()
        {
            Order.Enabled = false;
            LBL1.Text = "";
            LBL2.Text = "";
            LBL3.Text = "";
            LBLError.Text = "There are no items in your cart.";
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Products.aspx");
        }

        protected void Order_Click(object sender, EventArgs e)
        {
            Response.Redirect("Order.aspx");
        }
    }
}