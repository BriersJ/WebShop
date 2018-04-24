using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShopForm.Business;

namespace WebShopForm
{
    public partial class Products : System.Web.UI.Page
    {
        Controller controller = new Controller();

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
                    row.Cells[5].Text = "Niet op voorraad";
                }
            }
        }

        protected void GVMain_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}