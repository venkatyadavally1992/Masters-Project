using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Drawing;
//using System.Drawing.Drawing2D;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ShoppingCart.Admin
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private static int Srowindex;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack != true)
            { getdata(); }
        }
        private void getdata()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Get_Category", con);
                cmd.CommandType = CommandType.StoredProcedure;

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
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_Submit.Text == "Submit")
                {string Path=string.Empty ;
                    if (FileUpload1.HasFile && FileUpload1.PostedFile.ContentType.ToLower().StartsWith("image"))
                    {

                        HttpFileCollection hfc = Request.Files;
                        HttpPostedFile HPF;
                        HPF = hfc[0];
                        if (HPF.ContentLength > 0)
                        {
                            string fileExtention = System.IO.Path.GetExtension(FileUpload1.FileName);
                            string fileName = Guid.NewGuid().ToString();
                            string savelocation = Server.MapPath("../Category/");
                            string savePath = savelocation + fileName + fileExtention;
                            Path = "../Category/" + fileName + fileExtention;
                            FileUpload1.SaveAs(Server.MapPath (Path));
                        }
                    }

                            SqlCommand cmd = new SqlCommand("Add_Category", con);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                            cmd.Parameters["@Name"].Value = txtTitle.Text;

                            cmd.Parameters.Add("@Main_Img", SqlDbType.NVarChar);
                            cmd.Parameters["@Main_Img"].Value = Path;

                            //Add_Category
                            con.Open();

                            int userid = cmd.ExecuteNonQuery();

                            if (userid != null)
                            {
                                txtTitle.Text = string.Empty;
                                Label1.Text = "Category Added Sucessfully....";
                                getdata();
                            }
                        
                }
                if (btn_Submit.Text == "Update")
                {
                    string Path=string .Empty ;
                    if (FileUpload1.HasFile && FileUpload1.PostedFile.ContentType.ToLower().StartsWith("image"))
                    {

                        HttpFileCollection hfc = Request.Files;
                        HttpPostedFile HPF;
                        HPF = hfc[0];
                        if (HPF.ContentLength > 0)
                        {
                            string fileExtention = System.IO.Path.GetExtension(FileUpload1.FileName);
                            string fileName = Guid.NewGuid().ToString();
                            string savelocation = Server.MapPath("../Category/");
                            string savePath = savelocation + fileName + fileExtention;
                            Path = "../Category/" + fileName + fileExtention;
                            FileUpload1.SaveAs(Server.MapPath(Path));
                        }
                    }
                            SqlCommand cmd = new SqlCommand("update_Category", con);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@id", SqlDbType.Int);
                            cmd.Parameters["@id"].Value = Srowindex;

                            cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                            cmd.Parameters["@Name"].Value = txtTitle.Text;

                            cmd.Parameters.Add("@Main_Img", SqlDbType.NVarChar);
                            cmd.Parameters["@Main_Img"].Value = Path;

                            //Add_Category
                            con.Open();

                            int userid = cmd.ExecuteNonQuery();

                            if (userid != null)
                            {
                                txtTitle.Text = string.Empty;
                                btn_Submit.Text = "Submit";
                                Label1.Text = "Category Updated Sucessfully....";
                                getdata();
                            }
                        
                    
                }
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
                con.Close();
            }
            
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                GridViewRow Row = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                int rowindex = Row.RowIndex;
                if (e.CommandName == "Select")
                {
                    Literal srno = (Literal)Row.FindControl("litSrno");
                    Literal cname = (Literal)Row.FindControl("litCname");
                    Image imgcode = (Image)Row.FindControl("img");

                    txtTitle.Text = cname.Text;
                    Image1 .ImageUrl = imgcode.ImageUrl;
                    Srowindex = Convert.ToInt32(srno.Text);
                    btn_Submit .Text = "Update";

                }
                else if (e.CommandName == "Delete")
                {
                    Literal srno = (Literal)Row.FindControl("litSrno");

                    SqlCommand cmd = new SqlCommand("Delete_Category", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    cmd.Parameters["@id"].Value = srno.Text;

                    con.Open();
                    int i = cmd.ExecuteNonQuery();


                    if (i != null)
                    {
                        Label1.Text = "Category is Deleted";
                        txtTitle.Text = "";
                        Image1.ImageUrl = "";
                        getdata();
                    }
                    else
                    {
                        Label1.Text = "ERROR";
                    }

                }


            }
            catch (Exception ex)
            {
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";

            Label1.Text = "";
        }
       
    }
}