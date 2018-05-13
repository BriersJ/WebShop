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
    /// The code behind the webpage responsible for showing all <code>Product</code>s.
    /// </summary>
    public partial class Products : System.Web.UI.Page
    {
        Controller controller = new Controller();

        /// <summary>
        /// Gets executed every time the page loads.
        /// </summary>
        /// <param name="sender">The object executing this method.</param>
        /// <param name="e">Extra arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GVMain.DataSource = controller.GetProducts();
                GVMain.DataBind();
                LockOutOfStockProducts();
            }
        }

        private void LockOutOfStockProducts()
        {
            foreach(GridViewRow row in GVMain.Rows)
            {
                int stock = Convert.ToInt32(row.Cells[4].Text);
                if(stock <=0)
                {
                    row.Cells[5].Enabled = false;
                    row.Cells[5].Text = "Out of stock";
                }
            }
        }

        /// <summary>
        /// Gets executed if a <code>User</code> selects a certain <code>Product</code>.
        /// </summary>
        /// <param name="sender">The object executing this method.</param>
        /// <param name="e">Extra arguments</param>
        protected void GVMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = GVMain.SelectedRow.Cells[0].Text;
            Session["ProductID"] = id;
            Response.Redirect("AddItem.aspx");
        }
    }
}