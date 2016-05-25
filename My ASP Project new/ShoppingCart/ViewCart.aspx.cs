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

namespace ShoppingCart
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        System.Collections.ArrayList myArrayList = new ArrayList();

        // DataSet ds = new DataSet();
        DataTable dtrec = new DataTable();
        string aa;
        string DeleteID, UpdateID;
        int bb = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Sales"] != null)
                {

                    ItemsBind();
                }
                else
                {
                    Response.Redirect("default.aspx");
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
            lblgrandtotal.Text = "Items in Cart :" + pcount + ",$ " + grosstotal;

            Session["totalcost"] = grosstotal;


        }


        protected void btn_pay_Click(object sender, EventArgs e)
        {
            //insert Data to database
            if (Session["userid"] != null)
            {
                Response.Redirect("~/Account/Login.aspx");
                

            }
            else {

                Response.Redirect("~/Account/Login.aspx"); 
            }


            //remove Session Data


        }
        protected void btn_shop_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}