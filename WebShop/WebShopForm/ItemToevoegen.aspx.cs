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
            Response.Redirect("Products.aspx");
        }
    }
}