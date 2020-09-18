using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Reachout1
{
    public partial class Manf_home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }

        protected void viewMyProducts(object sender, EventArgs e)
        {
            string usr = (string)Session["field1"];
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("viewManufacturerProducts", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@username", usr));
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (rdr.Read())
            {
                //Get the value of the attribute name in the Company table
                int Prodserialno = rdr.GetInt32(rdr.GetOrdinal("id"));
                string ProdName = rdr.GetString(rdr.GetOrdinal("name"));
                //Get the value of the attribute field in the Company table
                string Prodfinalprice = (rdr.GetSqlDecimal(rdr.GetOrdinal("unit_price"))).ToString();
                string Prodprice = (rdr.GetSqlDecimal(rdr.GetOrdinal("unit_price"))).ToString();

                string availability = (rdr.GetSqlBoolean(rdr.GetOrdinal("available"))).ToString();
                if (rdr.GetSqlBoolean(rdr.GetOrdinal("available")))
                {
                    availability = "available";
                }
                else availability = "not available";


                string color = "__";
                string descrip;
                if (!rdr.IsDBNull(rdr.GetOrdinal("description")))
                {
                    descrip = (rdr.GetString(rdr.GetOrdinal("description")));
                }
                else descrip = "__";


                liTi.Text = "<h3> Ventilators </h3>";
                Panel card = new Panel();
                card.CssClass = "icon-box";
                Button MyButton = new Button();
                MyButton.CssClass = "btn-primary btn-info";
                MyButton.UseSubmitBehavior = false;
                MyButton.PostBackUrl = "Manf_product_details.aspx?pid=" + Prodserialno.ToString();
                MyButton.Text = "Info";
                Label lbl_ProdName = new Label();
                lbl_ProdName.Text = "<h4 class='prodName' style='" +
                                                    "margin-left: 40px;" +
                                                    "font-weight: 700;" +
                                                    "font-size: 18px;'>" + ProdName + "</h4>";
                card.Controls.Add(lbl_ProdName);
                Label lbl_avail = new Label();
                lbl_avail.Text = "<div class='des'>" + availability + "</div>";
                card.Controls.Add(lbl_avail);
                Label lbl_price = new Label();
                lbl_price.Text = "<div class='des'>" + "Unit Price: EGP" + Prodprice + "</div>";
                card.Controls.Add(lbl_price);
                Label lbl_descrip = new Label();
                lbl_descrip.Text = "<div class='des'>" + "description: " + descrip + "</div> </br>";
                card.Controls.Add(lbl_descrip);
                card.Controls.Add(MyButton);

                prodsList.Controls.Add(card);


            }


        }

        protected void viewMyOrders(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("viewManufacturerOrders", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            var usr = Session["field1"];
            cmd.Parameters.Add(new SqlParameter("@username", usr));
            conn.Open();

            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (rdr.Read())
            {
                //Get the value of the attribute name in the Company table
                int orderno = rdr.GetInt32(rdr.GetOrdinal("order_id"));
                string status = rdr.GetString(rdr.GetOrdinal("status"));
                string price = (rdr.GetSqlDecimal(rdr.GetOrdinal("total_price"))).ToString();
                int prodno = rdr.GetInt32(rdr.GetOrdinal("product_id"));

                string date = (rdr.GetSqlDateTime(rdr.GetOrdinal("date"))).ToString();


                liTi.Text = "Placed Orders";
                Button MyButton = new Button();
                MyButton.CssClass = "btn-primary";
                MyButton.CommandName = "Click";
                //MyButton.CommandArgument = orderno.ToString();
                //MyButton.Command += cancelOrder;
                MyButton.UseSubmitBehavior = false;
                MyButton.PostBackUrl = "Manf_order_details.aspx?oid=" + orderno.ToString();
                MyButton.Text = "Order Details";
                Panel card = new Panel();
                card.CssClass = "icon-box";

                Label lbl_orderno = new Label();
                lbl_orderno.Text = "<h4 class='prodName' style='" +
                                                    "margin-left: 40px;" +
                                                    "font-weight: 700;" +
                                                    "font-size: 18px;'>" + orderno + "</h4>";
                card.Controls.Add(lbl_orderno);
                Label lbl_status = new Label();
                lbl_status.Text = "<div class='des'>Status: " + status + "</div>";
                card.Controls.Add(lbl_status);
                Label lbl_price = new Label();
                lbl_price.Text = "<div class='des'>" + "Unit Price: EGP" + price + "</div>";
                card.Controls.Add(lbl_price);
                Label lbl_prodno = new Label();
                lbl_prodno.Text = "<div class='des'>" + "Product No.: " + prodno + "</div> </br>";
                card.Controls.Add(lbl_prodno);
                Label lbl_date = new Label();
                lbl_date.Text = "<div class='des'>" + "Placement Date: " + date + "</div> </br>";
                card.Controls.Add(lbl_date);
                card.Controls.Add(MyButton);

                prodsList.Controls.Add(card);
            }

        }

        protected void addProduct(object sender, EventArgs e)
        {
            Response.Redirect("Manf_post_product.aspx");
            //string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            //SqlConnection conn = new SqlConnection(connStr);
            //
            //SqlCommand cmd = new SqlCommand("INSERT INTO Products ", conn);
            //cmd.CommandType = CommandType.Text;
            //String prod_name=txt_prod_name.Text;
            //String description = txt_desc.Text;
            //String price = txt_price.Text;
            //string category = radiolist_category.SelectedValue;
            //String amount = txt_amount.Text;
            //String gtin = txt_GTIN.Text;
            //
            //
            //cmd.Parameters.Add(new SqlParameter("@name", prod_name));
            //cmd.Parameters.Add(new SqlParameter("@description", description));
            //cmd.Parameters.Add(new SqlParameter("@unit_price", price));
            //cmd.Parameters.Add(new SqlParameter("@available", 1));
            //cmd.Parameters.Add(new SqlParameter("@category", category));
            //cmd.Parameters.Add(new SqlParameter("@amount", amount));
            //cmd.Parameters.Add(new SqlParameter("@manufacturer_id", 1));
            //cmd.Parameters.Add(new SqlParameter("@GTIN", gtin));
            //
            //conn.Open();

        }


    }
}