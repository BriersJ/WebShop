using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShopForm.Business;

namespace WebShopForm
{
    public partial class ItemToevoegen : System.Web.UI.Page
    {
        Controller controller = new Controller();

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["ProductID"]);
            var product = controller.GetProduct(id);
            Picture.ImageUrl = @"~\Images\" + product.Picture;
            Price.Text = product.Price.ToString();
            Stock.Text = product.Stock.ToString();
            ProductID.Text = product.ID.ToString();
            Name.Text = product.Name;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Context.User.Identity.Name);
            User user = controller.GetUser(userId);
            int productId = Convert.ToInt32(Session["ProductID"]);
            Product product = controller.GetProduct(productId);
            if (controller.HasItemInCart(user, product))
            {
                LBLError.Text = "You already have this item in your cart, to add a different amount please remove this product from your cart first";
            }
            else
            {
                int amount;
                if (int.TryParse(TXTAmount.Text, out amount))
                {
                    int currentStock = controller.GetStock(productId);
                    if (amount <= currentStock)
                    {
                        controller.AddToCart(product, user, amount);
                        Response.Redirect("Products.aspx");
                    }
                    else
                    {
                        LBLError.Text = "Amount is too large.";
                    }
                }
                else
                {
                    LBLError.Text = "Please enter a number.";
                }
            }
        }
    }
}