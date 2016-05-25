using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingCart.User
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        
        public void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Session.Remove("Sales");
                // String Grandtotal = Session["totalcost"].ToString();
               // Decimal grandtotalnew = Convert.ToDecimal(Grandtotal) - ((Convert.ToDecimal(Grandtotal) * 10 )/ 100);
               // if (Request.Cookies["NonPersistance"] != null)
                  //  lblamt.Text = Request.Cookies["NonPersistance"].Value;

                lblamt.Text = Session["totalcost"].ToString();
              Label1.Text = Request.QueryString["transid"].ToString();
            }
        }
       
    }
}



