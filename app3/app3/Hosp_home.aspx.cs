using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;




namespace Reachout1
{ 
    public partial class ViewProd : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {


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

                string date = (rdr.GetSqlDateTime(rdr.GetOrdinal("date"))).ToString();


                liTi.Text = " ";

                Button MyButton = new Button();
                MyButton.CssClass = "btn-primary";
                //  = "display:flex;align-items: center;justify-content:center; font-size: 24px;width: 40px;height: 40px;margin-top:0px;float:right;'/>";
                MyButton.CommandName = "Click";
                MyButton.CommandArgument = orderno.ToString();
                MyButton.Command += cancelOrder;
                prodsList.Controls.Add(MyButton);
            }

            //Create a new label and add it to the HTML form
            /*
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
            */


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
                liTi.Text = "<h3> Gloves </h3>";

                Panel card = new Panel();
                card.CssClass = "icon-box";
                Button MyButton = new Button();
                MyButton.CssClass = "btn-primary btn-info";
                MyButton.UseSubmitBehavior = false;
                MyButton.PostBackUrl = "Hosp_product_info.aspx?pid=" + Prodserialno.ToString();
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


                liTi.Text = "<h3> Ventilators </h3>";
                Panel card = new Panel();
                card.CssClass = "icon-box";
                Button MyButton = new Button();
                MyButton.CssClass = "btn-primary btn-info";
                MyButton.UseSubmitBehavior = false;
                MyButton.PostBackUrl = "Hosp_product_info.aspx?pid=" + Prodserialno.ToString();
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
                liTi.Text = "<h3> Masks </h3>";
                Panel card = new Panel();
                card.CssClass = "icon-box";
                Button MyButton = new Button();
                MyButton.CssClass = "btn-primary btn-info";
                MyButton.UseSubmitBehavior = false;
                MyButton.PostBackUrl = "Hosp_product_info.aspx?pid=" + Prodserialno.ToString();
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
        protected void viewProdInfo(object sender, EventArgs e)
        {
            Response.Write("here!");
           LinkButton lnk = sender as LinkButton;
           String Value1 = lnk.Attributes["pid"].ToString();

            Response.Redirect("Hosp_product_info.aspx?pid="+ Value1, true);
        }

        protected void cancelOrder(object sender, CommandEventArgs e)
        {

            Button btn = (Button)sender;
            string order_id = Convert.ToString( e.CommandArgument);

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("cancelOrder", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@orderId", order_id));
            cmd.Parameters.Add(new SqlParameter("@username",Session["field1"]));
            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                Response.Redirect(Request.RawUrl);
            }
            catch(Exception ex)
            {
                
                txtWarning.Text = ex.Message;
            }
            
        }



    }
}