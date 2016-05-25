using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ShoppingCart
{
    public partial class _Default : Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //FillCategories();
                FillProducts();
            }
        }
        private void FillProducts()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Home_category_List", con);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();

                da.SelectCommand = cmd;
                da.Fill(dt);

                DL_Products.DataSource = dt;
                DL_Products.DataBind();

            }
            catch (Exception ee)
            {
                throw ee;
            }
        }
    }
}