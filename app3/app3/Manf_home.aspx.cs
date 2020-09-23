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
        bool add_success = true;
        protected void Page_Load(object sender, EventArgs e)
        {


            string[] categories = { "Ventilator", "Mask", "Gloves" };
            DropDown_category.DataSource = categories;
            DropDown_category.DataBind();
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


        protected void gtin_Validate(object sender, ServerValidateEventArgs e)
        {
            if (e.Value.Length == 8 || e.Value.Length == 12 || e.Value.Length == 13 || e.Value.Length == 14)
            {
                e.IsValid = true;
            }
            else
            {
                e.IsValid = false;
                add_success = false;
            }
        }
        protected void addProduct(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand cmd = new SqlCommand("PostProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@username", Session["field1"]));
            cmd.Parameters.Add(new SqlParameter("@pname", txt_prod_name.Text));
            cmd.Parameters.Add(new SqlParameter("@info", txt_desc.Text));
            cmd.Parameters.Add(new SqlParameter("@unit_price", txt_price.Text));
            cmd.Parameters.Add(new SqlParameter("@amount", txt_amount.Text));
            cmd.Parameters.Add(new SqlParameter("@gtin", txt_GTIN.Text));

            if (DropDown_category.SelectedValue == "Gloves")
            {
                cmd.Parameters.Add(new SqlParameter("@categ", "GLOV"));

            }
            if (DropDown_category.SelectedValue == "Mask")
            {
                cmd.Parameters.Add(new SqlParameter("@categ", "MASK"));

            }
            if (DropDown_category.SelectedValue == "Ventilator")
            {
                cmd.Parameters.Add(new SqlParameter("@categ", "VENT"));

            }

            if (txt_amount.Text.Length<1)
            {
                add_success = false;
                error_amount.Text = "Enter fffered amount of 0 or more";
            }

            if (txt_price.Text.Length < 1)
            {
                add_success = false;
                error_price.Text = "Enter Price";
            }
            if (txt_GTIN.Text.Length == 8 || txt_GTIN.Text.Length == 12 || txt_GTIN.Text.Length == 13 || txt_GTIN.Text.Length == 14)
            {
                
            }
            else
            {
                
                add_success = false;
                error_GTIN.Text = "Please enter a valid GTIN of length 8, 12, 13 or 14.";
            }

            conn.Open();
            try
            {
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                add_success = false;
            }

            if (add_success)
            {
                Response.Write("<script>alert('Product Posted Successfully.');</script>");
                CleartextBoxes(form1);
            }


        }

        public void CleartextBoxes(Control parent)

        {

            foreach (Control c in parent.Controls)

            {
                if ((c.GetType() == typeof(TextBox)))
                {

                    ((TextBox)(c)).Text = "";
                }
                
                if (c.HasControls())
                {
                    CleartextBoxes(c);
                }
            }
        }





    }
}