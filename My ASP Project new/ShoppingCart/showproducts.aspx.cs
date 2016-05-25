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
    public partial class WebForm1 : System.Web.UI.Page
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
                SqlCommand cmd = new SqlCommand("Home_Product_List", con);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();

                cmd.Parameters.Add("@catid", SqlDbType.NVarChar);
                cmd.Parameters["@catid"].Value = Convert.ToInt32(Request.QueryString["id"].ToString());

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