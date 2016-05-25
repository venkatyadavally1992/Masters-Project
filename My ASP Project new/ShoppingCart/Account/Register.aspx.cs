using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ShoppingCart.Account
{
    public partial class Register : Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
           // RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        //protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        //{
        //    FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

        //    string continueUrl = RegisterUser.ContinueDestinationPageUrl;
        //    if (!OpenAuth.IsLocalUrl(continueUrl))
        //    {
        //        continueUrl = "~/";
        //    }
        //    Response.Redirect(continueUrl);
        //}

        protected void btnregister_Click(object sender, EventArgs e)
        {
            try
            {
                //con.Open();
                SqlCommand cmd = new SqlCommand("login_insert", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@username", SqlDbType.NVarChar);
                cmd.Parameters["@username"].Value = UserName.Text;

                cmd.Parameters.Add("@password", SqlDbType.NVarChar);
                cmd.Parameters["@password"].Value = Password.Text;

                cmd.Parameters.Add("@type", SqlDbType.Int);
                cmd.Parameters["@type"].Value = 1;
                con.Open();

                int userid = cmd.ExecuteNonQuery();


                if (userid != null)
                {
                    ErrorMessage.Text = "User Registration Successfull.   ";
                    ErrorMessage.Visible = true;
                }
                else
                {
                    ErrorMessage.Text = "Invalid username or password Details.";
                    ErrorMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message.ToString();
                ErrorMessage.Visible = true;
                con.Close();
            }
        }
    }
}