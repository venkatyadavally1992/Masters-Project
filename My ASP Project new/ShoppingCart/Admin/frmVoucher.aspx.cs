using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingCart.Admin
{
    public partial class frmVoucher : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack != true)
            {
                getdata();
            }
        }
        
        private void getdata()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from Voucher", con);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();

                da.SelectCommand = cmd;
                da.Fill(dt);

                if (dt != null)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex) { }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("Add_Voucher", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Value", SqlDbType.Int);
                    cmd.Parameters["@Value"].Value = txtvalue.Text;
                    cmd.Parameters.Add("@Code", SqlDbType.VarChar);
                    cmd.Parameters["@Code"].Value = txtCode.Text;
                    con.Open();
                    int userid = cmd.ExecuteNonQuery();
                    con.Close();
                    if (userid != null)
                    {
                        txtCode.Text=string.Empty;
                        txtvalue.Text=string.Empty;
                        getdata();
                    }
            }
            catch (Exception ex) { }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Del")
                {
                    int Id = Convert.ToInt32(e.CommandArgument);
                    SqlCommand cmd = new SqlCommand("Delete_Voucher", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.Parameters["@Id"].Value = Id;

                    con.Open();
                    int userid = cmd.ExecuteNonQuery();
                    con.Close();
                    getdata();
                }
            
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            txtCode.Text = string.Empty;
            txtvalue.Text = string.Empty;

        }

    }
}