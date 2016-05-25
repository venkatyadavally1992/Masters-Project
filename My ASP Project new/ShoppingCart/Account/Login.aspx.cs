using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ShoppingCart.Account
{
    public partial class Login : Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterHyperLink.NavigateUrl = "Register";
           // OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                //RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from login where userid =@username and Password=@password and type=1", con);

                cmd.Parameters.Add("@username", SqlDbType.NVarChar);
                cmd.Parameters["@username"].Value = UserName.Text;

                cmd.Parameters.Add("@password", SqlDbType.NVarChar);
                cmd.Parameters["@password"].Value = Password.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Session["Userid"] = UserName.Text.Trim();

                    //Response.Redirect(Request .UrlReferrer.ToString () );
                    Response.Redirect("../user/welcome.aspx");
                }
                else
                {
                    FailureText .Text = "Invalid Details..";
                }
            }
            catch (Exception ex) { }
        }
    }
}