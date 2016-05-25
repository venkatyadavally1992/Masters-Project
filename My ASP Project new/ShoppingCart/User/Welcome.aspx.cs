using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ShoppingCart.User
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        System.Collections.ArrayList myArrayList = new ArrayList();

        // DataSet ds = new DataSet();
        DataTable dtrec = new DataTable();
        string DeleteID, UpdateID;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Sales"] != null)
                {
                    ItemsBind();
                    tblviewcart.Visible = true;
                }
                else
                {
                    tblviewcart.Visible = false;
                    // Response.Redirect("Product.aspx");
                    //lblCartNotselected.Text = "No Items In Cart";
                }
            }
        }
        protected void rptProductList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                //Delete LinkButton CommandName and CommandArgument Passing

                if (e.CommandName == "DeleteColumn")
                {
                    Label lblQuantity = (Label)e.Item.FindControl("lblQuantity");
                    string aa = lblQuantity.Text;

                    DeleteID = e.CommandArgument.ToString();

                    dtrec = (DataTable)Session["Sales"];

                    foreach (DataRow dr in dtrec.Rows)
                    {
                        if (dr["ProductId"].ToString() == DeleteID)
                        {
                            dr.Delete();
                            dtrec.AcceptChanges();
                            break;
                        }
                    }

                    ItemsBind();
                    // Response.Redirect("Cart.aspx");
                }

                //Update LinkButton CommandName and CommandArgument Passing


                if (e.CommandName == "UpdateColumn")
                {
                    UpdateID = e.CommandArgument.ToString();
                    TextBox txtQuantity =
                           (TextBox)e.Item.FindControl("txtQuantity");


                    Label lbltotlPrice = (Label)e.Item.FindControl("lbltotlPrice");
                    Label lblPrice = (Label)e.Item.FindControl("lblPrice");


                    dtrec = (DataTable)Session["Sales"];

                    for (int i = 0; i < dtrec.Rows.Count; i++)
                    {

                        if (dtrec.Rows[i]["ProductId"].ToString() == UpdateID)
                        {
                            //Update
                            dtrec.Rows[i]["Quantity"] = txtQuantity.Text;
                            dtrec.Rows[i]["UnitPrice"] = Convert.ToDouble(lblPrice.Text) * Convert.ToDouble(txtQuantity.Text);


                            dtrec.AcceptChanges();

                            break;
                        }
                    }
                    ItemsBind();
                }
            }

        }
        protected void rptProductList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
        private void ItemsBind()
        {
            if ((Session["Sales"]) != null)
            {
                DataTable cTable = new DataTable();
                cTable = (DataTable)Session["Sales"];

                if (cTable.Rows.Count > 0)
                {
                    rptProductList.DataSource = cTable;
                    rptProductList.DataBind();

                    //

                    foreach (RepeaterItem rpt in rptProductList.Items)
                    {
                        Label lbl = (Label)rpt.FindControl("lblQuantity");

                        TextBox txtQuantity =
                              (TextBox)rpt.FindControl("txtQuantity");

                        txtQuantity.Text = lbl.Text;


                    }
                    Caluculate();
                }
                else
                {
                    Response.Redirect("Product.aspx");

                }

            }
        }
        public void Caluculate()
        {

            int i;
            Double pcount, grosstotal;
            //Dim i As Integer
            //  Dim pcount, grosstotal As Double
            pcount = 0;
            grosstotal = 0;

            if ((Session["Sales"]) != null)
            {
                DataTable cTable = new DataTable();
                cTable = (DataTable)Session["Sales"];
                //gross= (Double) cTable.Compute("sum(["+cTable.Columns["MRP"].ColumnName.ToString()+"])","");
                // Dim sum As Decimal = dt.Compute("sum([" + dt.Columns(j).ColumnName.ToString() + "])", "")

                for (i = 0; i < cTable.Rows.Count; i++)
                {
                    pcount = Convert.ToInt32(cTable.Rows[i]["Quantity"]) + pcount;
                    // grosstotal = (Convert.ToDouble(cTable.Rows[i]["MRP"]) * Convert.ToInt32(cTable.Rows[i]["Quantity"])) + grosstotal;
                    grosstotal = Convert.ToDouble(cTable.Rows[i]["UnitPrice"]) + grosstotal;

                }
            }
            lblgrandtotal.Text = "Items in Cart :" + pcount + ", $ " + grosstotal;
            hftotal.Value = grosstotal.ToString();
            hfcount.Value = pcount.ToString();
            Session["totalcost"] = grosstotal;


        }
        public void btn_pay_Click1(object sender, EventArgs e)
        {
            if (txtvoucher.Text != "UCMVOCHER")
            { lblerroe.Text = "InValid Promo Code...!!!"; }
            else {
                decimal tot = Convert.ToDecimal(hftotal.Value)-((Convert.ToDecimal(hftotal.Value) * 10) / 100);

                //Response.Cookies["nameWithNPCookies"].Value = tot.ToString();
                lblgrandtotal.Text = "Items in Cart :" + hfcount.Value + ",$ " + tot.ToString();
                Session["totalcost"] = Convert.ToDouble(tot);
                     lblerroe.Text = "Valid PromoCode...!!!";
            }
                   
               
        }

        public void btn_pay_Click(object sender, EventArgs e)
        {
            
                Pay();
            
        }

        public void Pay()
        {
            //insert Data to database
            if (Session["userid"] != null)
            {
                if ((Session["Sales"]) != null)
                {
                    DataTable cTable = new DataTable();
                    cTable = (DataTable)Session["Sales"];

                    if (cTable.Rows.Count > 0)
                    {
                        Random rnd = new Random();
                        int dice = rnd.Next(10000, 99999);

                        con.Open();
                        SqlCommand cmd = new SqlCommand("Orders_insert", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@transid", dice);
                        cmd.Parameters.Add("@userid", Session["Userid"].ToString());
                        cmd.Parameters.Add("@voucherCode", txtvoucher.Text);
                        cmd.Parameters.Add("@orderlist", cTable);

                        // cmd.Parameters.Add("@tblorders", SqlDbType.Structured);

                        //  cmd.Parameters.Add("@tblorders", cTable);

                        int i = Convert.ToInt32(cmd.ExecuteNonQuery());

                        if (i > 0)
                        {
                            Response.Redirect("orderlist.aspx?transid=" + dice.ToString());
                        }
                        else
                        {

                        }
                        con.Close();
                    }
                }


            }
            else { Response.Redirect("../Account/login.aspx"); }


            //remove Session Data


        }

    }
}