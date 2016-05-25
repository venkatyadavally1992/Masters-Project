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
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Session.Abandon();
                FillProductName();
                Caluculate();
            }
        }
        public void CreateTable()
        {
            DataTable ItemTable = new DataTable();
            ItemTable.Columns.Add("ProductId", typeof(long));
            ItemTable.Columns.Add("ProductTitle", typeof(string));
            ItemTable.Columns.Add("Quantity", typeof(int));
            ItemTable.Columns.Add("MRP", typeof(Double));
            ItemTable.Columns.Add("imgurl", typeof(string));
            ItemTable.Columns.Add("UnitPrice", typeof(Double));
            Session["Sales"] = ItemTable;
            ItemTable.Dispose();
        }
        public void Caluculate()
        {

            int i;
            Double pcount, grosstotal;
            pcount = 0;
            grosstotal = 0;

            if ((Session["Sales"]) != null)
            {
                DataTable cTable = new DataTable();
                cTable = (DataTable)Session["Sales"];

                for (i = 0; i < cTable.Rows.Count; i++)
                {
                    pcount = Convert.ToInt32(cTable.Rows[i]["Quantity"]) + pcount;
                    grosstotal = Convert.ToDouble(cTable.Rows[i]["UnitPrice"]) + grosstotal;
                }
            }
            lblICart.Text = "Items Count:" + pcount + ",$ " + grosstotal;


        }
        private void FillProductName()
        {
            try
            {
                string Product_id = Request.QueryString["ID"].ToString();

                SqlCommand cmd = new SqlCommand("Get_Product_Name", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.NVarChar);
                cmd.Parameters["@id"].Value = Convert.ToInt32(Product_id);


                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();

                da.SelectCommand = cmd;
                da.Fill(dt);
               

                if (dt.Rows.Count > 0)
                {
                    int Stock = (Convert.ToInt32(dt.Rows[0]["Stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["salestock"].ToString()));
                    lblPrice.Text = Stock.ToString();
                    HfStock.Value = Stock.ToString();
                    DataList1.DataSource = dt;
                    DataList1.DataBind();
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (Convert.ToInt32(txtQty.Text) > 0)
            {
                double Price = double.Parse(((Label)DataList1.Controls[0].FindControl("PriceLabel")).Text);
                string ProductName = ((Label)DataList1.Controls[0].FindControl("NameLabel")).Text;
                string ProductImageUrl = ((Image)DataList1.Controls[0].FindControl("Image1")).ImageUrl;
                long ProductID = long.Parse(Request.QueryString["ID"]);

                AddItems(ProductID, ProductName, Convert.ToInt32(txtQty.Text), Price, ProductImageUrl, Convert.ToDouble(txtQty.Text) * Price);
                Caluculate();
                lblMessage.ForeColor = System.Drawing.Color.DarkGreen;
                lblMessage.Text = "Product Added to Cart! Please do not click on ADD button again. click on View Cart to proceed !!! ";
            }
            else
            {
                lblMessage.Text = "Enter Quantity!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void AddItems(long productid, string productname, int qunty, double cost, string imgurl, double unitprice)
        {



            if ((Session["Sales"]) == null)
            {
                CreateTable();
            }
            DataTable ATable = new DataTable();

            ATable = (DataTable)Session["Sales"];

            DataRow[] RItem = ATable.Select("ProductId=" + productid);

            if (RItem.Count() == 0)
            {
                //new item
                DataRow dr1 = ATable.NewRow();
                dr1[0] = productid;
                dr1[1] = productname;
                dr1[2] = qunty;
                dr1[3] = cost;
                dr1[4] = imgurl;
                dr1[5] = unitprice;

                ATable.Rows.Add(dr1);


            }
            else
            {
                //already in the cart

                RItem[0]["Quantity"] = Convert.ToInt32(RItem[0]["Quantity"]) + qunty;
                RItem[0]["UnitPrice"] = Convert.ToInt32(RItem[0]["UnitPrice"]) + unitprice;

            }

            Session["Sales"] = ATable;
            ATable.Dispose();

        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //  lblICart.Text = "Item Count: " & pcount & ", Rs. " & grosstotal
    }
}