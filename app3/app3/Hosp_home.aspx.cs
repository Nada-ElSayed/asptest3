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
    public partial class ViewProd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(Session["field1"]);
            Response.Write(Session["field2"]);
            Response.Write(Session["field3"]);

        }

        public void viewOrders(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("viewHospitalOrders", conn);
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

                string date = (rdr.GetSqlBoolean(rdr.GetOrdinal("date"))).ToString();




                //Create a new label and add it to the HTML form

                Label lbl_orderno = new Label();
                lbl_orderno.Text = "<div>" + "   Order No.: " + orderno + "</div>";
                form1.Controls.Add(lbl_orderno);


                Label lbl_status = new Label();
                lbl_status.Text = "<div>" + "   Order Status:  " + status + "</div>";
                form1.Controls.Add(lbl_status);


                Label lbl_price = new Label();
                lbl_price.Text = "<div>" + "   Total Price: " + price + "</div>";
                form1.Controls.Add(lbl_price);


                Label lbl_prodno = new Label();
                lbl_prodno.Text = "<div>" + "   Produt no.: " + prodno + "</div>" + "  <br /> <br />";
                form1.Controls.Add(lbl_prodno);

                Label lbl_date = new Label();
                lbl_date.Text = "<div>" + "   Order Plcaement Date: " + date + "</div>" + "  <br /> <br />";
                form1.Controls.Add(lbl_date);

            }

        }

        public void findGloves(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("getProducts", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@type", "GLOV"));
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


                string ProdVendorName = rdr.GetString(rdr.GetOrdinal("name"));

                //Create a new label and add it to the HTML form

                Label lbl_ProdName = new Label();
                lbl_ProdName.Text = "<div>" + "   name: " + ProdName + "</div>";
                form1.Controls.Add(lbl_ProdName);


                Label lbl_avail = new Label();
                lbl_avail.Text = "<div>" + "    " + availability + "</div>";
                form1.Controls.Add(lbl_avail);


                Label lbl_price = new Label();
                lbl_price.Text = "<div>" + "   unit price: " + Prodprice + "</div>";
                form1.Controls.Add(lbl_price);


                Label lbl_descrip = new Label();
                lbl_descrip.Text = "<div>" + "   description: " + descrip + "</div>" + "  <br /> <br />";
                form1.Controls.Add(lbl_descrip);


                // Button AddToCart_btn = new Button();
                // AddToCart_btn.Text = "   Add to cart: " ; 
                // form1.Controls.Add(AddToCart_btn);

            }

        }
        public void findVents(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("getProducts", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@type", "VENT"));
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


                string ProdVendorName = rdr.GetString(rdr.GetOrdinal("name"));

                //Create a new label and add it to the HTML form

                Label lbl_ProdName = new Label();
                lbl_ProdName.Text = "<div>" + "   name: " + ProdName + "</div>";
                form1.Controls.Add(lbl_ProdName);


                Label lbl_avail = new Label();
                lbl_avail.Text = "<div>" + "    " + availability + "</div>";
                form1.Controls.Add(lbl_avail);


                Label lbl_price = new Label();
                lbl_price.Text = "<div>" + "   unit price: " + Prodprice + "</div>";
                form1.Controls.Add(lbl_price);


                Label lbl_descrip = new Label();
                lbl_descrip.Text = "<div>" + "   description: " + descrip + "</div>" + "  <br /> <br />";
                form1.Controls.Add(lbl_descrip);


                // Button AddToCart_btn = new Button();
                // AddToCart_btn.Text = "   Add to cart: " ; 
                // form1.Controls.Add(AddToCart_btn);

            }

        }

        public void findMasks(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("getProducts", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@type", "MASK"));
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


                string ProdVendorName = rdr.GetString(rdr.GetOrdinal("name"));

                //Create a new label and add it to the HTML form

                Label lbl_ProdName = new Label();
                lbl_ProdName.Text = "<div>" + "   name: " + ProdName + "</div>";
                form1.Controls.Add(lbl_ProdName);


                Label lbl_avail = new Label();
                lbl_avail.Text = "<div>" + "    " + availability + "</div>";
                form1.Controls.Add(lbl_avail);


                Label lbl_price = new Label();
                lbl_price.Text = "<div>" + "   unit price: " + Prodprice + "</div>";
                form1.Controls.Add(lbl_price);


                Label lbl_descrip = new Label();
                lbl_descrip.Text = "<div>" + "   description: " + descrip + "</div>" + "  <br /> <br />";
                form1.Controls.Add(lbl_descrip);


                // Button AddToCart_btn = new Button();
                // AddToCart_btn.Text = "   Add to cart: " ; 
                // form1.Controls.Add(AddToCart_btn);

            }

        }

    }
}