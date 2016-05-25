using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ShoppingCart.Admin
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //orders_Selectbydate
            SqlCommand cmd = new SqlCommand("orders_Selectbydate", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@sdate", SqlDbType.NVarChar);
                cmd.Parameters["@sdate"].Value = TextBox1.Text;

                cmd.Parameters.Add("@edate", SqlDbType.NVarChar);
                cmd.Parameters["@edate"].Value = TextBox2 .Text.ToString();

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                DataTable dt = new DataTable();

                da.Fill(dt);
                if (dt != null)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null ;
                    GridView1.DataBind();
                }
        }
    }
}