using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace ShoppingCart.User
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (rb_id.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("Order_SelectByTransidandUserid", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@transid", SqlDbType.NVarChar);
                cmd.Parameters["@transid"].Value = txtstudentid.Text;

                cmd.Parameters.Add("@userid", SqlDbType.NVarChar);
                cmd.Parameters["@userid"].Value = Session["userid"].ToString();


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
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
            else if (rb_name.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("Order_SeletByDateandUserid", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@userid", SqlDbType.NVarChar);
                cmd.Parameters["@userid"].Value = Session["userid"].ToString();

                cmd.Parameters.Add("@sdate", SqlDbType.DateTime);
                cmd.Parameters["@sdate"].Value = Convert.ToDateTime(txtfname.Text);

                cmd.Parameters.Add("@edate", SqlDbType.DateTime);
                cmd.Parameters["@edate"].Value = Convert.ToDateTime(txtmname.Text);

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
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            rb_id.Checked = false;
            rb_name.Checked = false;
            txtfname.Text = "";
            txtmname.Text = "";
            txtstudentid.Text = "";

        }
    }
}