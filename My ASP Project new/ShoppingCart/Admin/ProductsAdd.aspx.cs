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
    public partial class WebForm3 : System.Web.UI.Page
    { private static int Srowindex;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack != true)
            { getdata();
            getcategorydata();
            }
        }
        private void getcategorydata()
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
                    DropDownList1.DataSource = dt;
                    DropDownList1.DataTextField = dt.Columns["name"].ToString();
                    DropDownList1.DataValueField = dt.Columns["id"].ToString();
                    DropDownList1.DataBind();

                    DropDownList1.Items.Insert(0, "Select..");
                }
            }
            catch (Exception ex) { }
        }
        private void getdata()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Get_Products", con);
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Button1.Text == "Submit")
                { string Path=string.Empty ;
                    if(FileUpload1 .HasFile !=false)
                    {
                        string fileExtention = System.IO.Path.GetExtension(FileUpload1.FileName);
                        string fileName = Guid.NewGuid().ToString();
                        string savelocation = Server.MapPath("../Products/");
                       string  savePath = savelocation + fileName + fileExtention;
                       Path = "../Products/" + fileName + fileExtention;
                       FileUpload1.SaveAs(Server.MapPath(Path));
                    }

                    SqlCommand cmd = new SqlCommand("Add_Products", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Cat_id", SqlDbType.Int);
                    cmd.Parameters["@Cat_id"].Value = DropDownList1.SelectedValue;

                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                    cmd.Parameters["@Name"].Value = TextBox4 .Text;

                    cmd.Parameters.Add("@Details", SqlDbType.NVarChar);
                    cmd.Parameters["@Details"].Value = TextBox3.Text;

                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                    cmd.Parameters["@Description"].Value = TextBox2.Text;

                    cmd.Parameters.Add("@Cost", SqlDbType.NVarChar);
                    cmd.Parameters["@Cost"].Value = TextBox1.Text;

                    cmd.Parameters.Add("@Main_Img", SqlDbType.NVarChar);
                    cmd.Parameters["@Main_Img"].Value = Path;

                    cmd.Parameters.Add("@Stock", SqlDbType.Int );
                    cmd.Parameters["@Stock"].Value = txtStock.Text;
                    

                    //Add_Category
                    con.Open();

                    int userid = cmd.ExecuteNonQuery();

                    if (userid != null)
                    {
                        txtStock.Text = string.Empty;
                        TextBox1 .Text = string.Empty;
                        TextBox2.Text = string.Empty;
                        TextBox3.Text = string.Empty;
                        TextBox4.Text = string.Empty;
                        DropDownList1.SelectedIndex = 0;
                        Label1.Text = "Product Added Sucessfully....";
                        //Button1.Text = "Submit";
                        getdata();
                    }
                }
                else if (Button1.Text == "Update")
                {
                    string Path = string.Empty;
                    if (FileUpload1.HasFile != false)
                    {
                        string fileExtention = System.IO.Path.GetExtension(FileUpload1.FileName);
                        string fileName = Guid.NewGuid().ToString();
                        string savelocation = Server.MapPath("../Products/");
                        string savePath = savelocation + fileName + fileExtention;
                        Path = "../Products/" + fileName + fileExtention;
                        FileUpload1.SaveAs(Server.MapPath(Path));
                    }
                    SqlCommand cmd = new SqlCommand("Update_Products", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    cmd.Parameters["@id"].Value = Srowindex;

                    cmd.Parameters.Add("@Cat_id", SqlDbType.Int);
                    cmd.Parameters["@Cat_id"].Value = DropDownList1.SelectedValue;

                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                    cmd.Parameters["@Name"].Value = TextBox4.Text;

                    cmd.Parameters.Add("@Details", SqlDbType.NVarChar);
                    cmd.Parameters["@Details"].Value = TextBox3.Text;

                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                    cmd.Parameters["@Description"].Value = TextBox2.Text;

                    cmd.Parameters.Add("@Cost", SqlDbType.NVarChar);
                    cmd.Parameters["@Cost"].Value = TextBox1.Text;

                    cmd.Parameters.Add("@Main_Img", SqlDbType.NVarChar);
                    cmd.Parameters["@Main_Img"].Value = Path;

                    cmd.Parameters.Add("@Stock", SqlDbType.Int);
                    cmd.Parameters["@Stock"].Value = txtStock.Text;

                    //Add_Category
                    con.Open();

                    int userid = cmd.ExecuteNonQuery();

                    if (userid != null)
                    {
                        TextBox1.Text = string.Empty;
                        TextBox2.Text = string.Empty;
                        TextBox3.Text = string.Empty;
                        TextBox4.Text = string.Empty;
                        txtStock.Text = string.Empty;
                        DropDownList1.SelectedIndex = 0;
                        Label1.Text = "Product Updated Sucessfully....";
                        Button1.Text = "Submit";
                        getdata();
                    }
                }
            }
            catch (Exception ex) { }
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
                    Literal litname = (Literal)Row.FindControl("litname");
                    Literal litdetails = (Literal)Row.FindControl("litdetails");
                    Literal litdescription = (Literal)Row.FindControl("litdescription");
                    Literal litcost = (Literal)Row.FindControl("litcost");
                    Literal litStock = (Literal)Row.FindControl("litStock");
                    
                    Image img = (Image)Row.FindControl("img");

                    TextBox1.Text =litname .Text ;
                    TextBox2.Text = litdetails.Text ;
                    TextBox3.Text = litdescription.Text ;
                    TextBox4.Text = litcost.Text ;
                    txtStock.Text = litStock.Text;
                    DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText(cname.Text));
                    Image1 .ImageUrl = img.ImageUrl;
                    Srowindex = Convert.ToInt32(srno.Text);
                    Button1 .Text = "Update";

                }
                else if (e.CommandName == "Delete")
                {
                    Literal srno = (Literal)Row.FindControl("litSrno");

                    SqlCommand cmd = new SqlCommand("Delete_Product", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    cmd.Parameters["@id"].Value = srno.Text;

                    con.Open();
                    int i = cmd.ExecuteNonQuery();


                    if (i != null)
                    {
                        Label1.Text = "Product is Deleted";
                        TextBox1.Text = string.Empty;
                        TextBox2.Text = string.Empty;
                        TextBox3.Text = string.Empty;
                        TextBox4.Text = string.Empty;
                        txtStock.Text = string.Empty;
                        DropDownList1.SelectedIndex = 0;
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label1.Text = "";
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox4.Text = string.Empty;
            txtStock.Text = string.Empty;
            DropDownList1.SelectedIndex = 0;
            Image1.ImageUrl = "";

        }
    }
}