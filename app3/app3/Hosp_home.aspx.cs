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

                Literal listed = new Literal();

                listed.Text = "<div class='col-lg-4 col-md-6 mt-4 mt-md-0'>" +
                                "<div class='icon-box' " +
                                            "style='" +
                                            "padding: 30px;" +
                                            //"margin: 3px;"+
                                            "position: relative;" +
                                            "overflow: hidden;" +
                                            "background: #fff;" +
                                            "box-shadow: 0 16px 29px 0 rgba(68, 88, 144, 0.2);" +
                                            "transition: all 0.3s ease-in-out;" +
                                            "height: 90%;' >" +
                                "<h4 class='prodName' style='" +
                                                    "margin-left: 40px;" +
                                                    "font-weight: 700;" +
                                                    "font-size: 18px; '>" +
                                "<a href='' style='color:#111'> Order No. " + orderno + "</a></h4>" +
                                "<div class='prodDes' style='font-size: 14px;" +
                                                              "margin-left: 40px;" +
                                                              "line-height: 24px;" +
                                                              "margin-bottom: 0;" +
                                                              "padding-bottom: 1px'> " +
                                "Status: " + status +
                                "<p> Total Price: EGP" + price + "</p>" +
                                "<p> Order Plcaement Date: " + date + " </p>" +
                                "<p> Product No.: " + prodno + " </p>" +
                                "</div>" +
                                "<div style='overflow: auto;" +
                                "width:100%;" +
                                "height:30%" +
                                "margin:0px;" +
                                "'>" +
                                "<button class='btn-primary' id='cancelProduct' runat='server' OnClientClick='return false;' onServerClick='cancelOrder()' style='display:flex;align-items: center;justify-content:center;" +
                                "font-size: 24px;width: 40px;height: 40px;margin-top:0px;float:right;'/>" +
                                "<i class='fa fa-window-close ' ></i> </button>" +
                                "</div>" +
                                "</div>" +
                                "</div>";

                Button MyButton = new Button();
                MyButton.CssClass = "btn-primary";
                //  = "display:flex;align-items: center;justify-content:center; font-size: 24px;width: 40px;height: 40px;margin-top:0px;float:right;'/>";
                MyButton.CommandName = "Click";
                MyButton.CommandArgument = orderno.ToString();
                MyButton.Command += cancelOrder;
                prodsList.Controls.Add(listed);
                prodsList.Controls.Add(MyButton);
            }


            }

            public void viewOrders(object sender, EventArgs e)
        {


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



                Literal listed = new Literal();

                listed.Text = "<div class='col-lg-4 col-md-6 mt-4 mt-md-0'>" +
                                "<div class='icon-box' " +
                                            "style='" +
                                            "padding: 30px;" +
                                            //"margin: 3px;"+
                                            "position: relative;" +
                                            "overflow: hidden;" +
                                            "background: #fff;" +
                                            "box-shadow: 0 16px 29px 0 rgba(68, 88, 144, 0.2);" +
                                            "transition: all 0.3s ease-in-out;" +
                                            "height: 90%;' >" +
                                "<h4 class='prodName' style='" +
                                                    "margin-left: 40px;" +
                                                    "font-weight: 700;" +
                                                    //"margin - bottom: 15px;"+
                                                    "font-size: 18px; '>" +
                                "<a href='' style='color:#111'>" + ProdName + "</a></h4>" +
                                "<div class='prodDes' style='font-size: 14px;" +
                                                              "margin-left: 40px;" +
                                                              "line-height: 24px;" +
                                                              "margin-bottom: 0;" +
                                                              "padding-bottom: 1px'> " +
                                availability +
                                "<p> Unit Price: EGP" + Prodprice + "</p>" +
                                "<p>" + descrip + "</p>" +
                                "</div>" +
                                "<div style='overflow: auto;" +
                                "width:100%;" +
                                "height:30%" +
                                "margin:0px;" +
                                "'>" +
                                //"<input type='text' id='quantity'  placeholder='Count' style='width:70px;height:75%;marin-top:6px'>" +
                                "<button class='btn-primary' id='orderProduct' runat='server' onserverclick='viewProdInfo'  style='display:flex;align-items: center;justify-content:center;" +
                                "font-size: 24px;width: 40px;height: 40px;margin-top:0px;float:right;'><i class='fa fa-cart-plus' ></i> </button>" +
                                "</div>" +
                                "</div>" +
                                "</div>";

                Button MyButton = new Button();
                MyButton.CssClass = "btn-primary";
                //  = "display:flex;align-items: center;justify-content:center; font-size: 24px;width: 40px;height: 40px;margin-top:0px;float:right;'/>";
                MyButton.UseSubmitBehavior = false;
                MyButton.PostBackUrl = "Hosp_product_info.aspx?pid=" + Prodserialno.ToString();

                prodsList.Controls.Add(listed);
                prodsList.Controls.Add(MyButton);
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
                Literal listed = new Literal();

                listed.Text = "<div class='col-lg-4 col-md-6 mt-4 mt-md-0'>" +
                                "<div class='icon-box' " +
                                            "style='" +
                                            "padding: 30px;" +
                                            //"margin: 3px;"+
                                            "position: relative;" +
                                            "overflow: hidden;" +
                                            "background: #fff;" +
                                            "box-shadow: 0 16px 29px 0 rgba(68, 88, 144, 0.2);" +
                                            "transition: all 0.3s ease-in-out;" +
                                            "height: 90%;' >" +
                                "<h4 class='prodName' style='" +
                                                    "margin-left: 40px;" +
                                                    "font-weight: 700;" +
                                                    //"margin - bottom: 15px;"+
                                                    "font-size: 18px; '>" +
                                "<a href='' style='color:#111'>" + ProdName + "</a></h4>" +
                                "<div class='prodDes' style='font-size: 14px;" +
                                                              "margin-left: 40px;" +
                                                              "line-height: 24px;" +
                                                              "margin-bottom: 0;" +
                                                              "padding-bottom: 1px'> " +
                                availability +
                                "<p> Unit Price: EGP" + Prodprice + "</p>" +
                                "<p>" + descrip + "</p>" +
                                "</div>" +
                                "<div style='overflow: auto;" +
                                "width:100%;" +
                                "height:30%" +
                                "margin:0px;" +
                                "'>" +
                                //"<input type='text' id='quantity'  placeholder='Count' style='width:70px;height:75%;marin-top:6px'>" +
                                "<button class='btn-primary' id='orderProduct' runat='server'  onserverclick='viewProdInfo'  style='display:flex;align-items: center;justify-content:center;" +
                                "font-size: 24px;width: 40px;height: 40px;margin-top:0px;float:right;'><i class='fa fa-cart-plus' ></i> </button>" + "</div>" +
                                "</div>" +
                                "</div>";

                Button MyButton = new Button();
                MyButton.CssClass = "btn-primary";
                //  = "display:flex;align-items: center;justify-content:center; font-size: 24px;width: 40px;height: 40px;margin-top:0px;float:right;'/>";
                MyButton.UseSubmitBehavior = false;
                MyButton.PostBackUrl = "Hosp_product_info.aspx?pid=" + Prodserialno.ToString();

                prodsList.Controls.Add(listed);
                prodsList.Controls.Add(MyButton);



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

                Literal listed = new Literal();

                listed.Text = "<div class='col-lg-4 col-md-6 mt-4 mt-md-0'>" +
                                "<div class='icon-box' " +
                                            "style='" +
                                            "padding: 30px;" +
                                            //"margin: 3px;"+
                                            "position: relative;" +
                                            "overflow: hidden;" +
                                            "background: #fff;" +
                                            "box-shadow: 0 16px 29px 0 rgba(68, 88, 144, 0.2);" +
                                            "transition: all 0.3s ease-in-out;" +
                                            "height: 90%;' >" +
                                "<h4 class='prodName' style='" +
                                                    "margin-left: 40px;" +
                                                    "font-weight: 700;" +
                                                    //"margin - bottom: 15px;"+
                                                    "font-size: 18px; '>" +
                                "<a href='' style='color:#111'>" + ProdName + "</a></h4>" +
                                "<div class='prodDes' style='font-size: 14px;" +
                                                              "margin-left: 40px;" +
                                                              "line-height: 24px;" +
                                                              "margin-bottom: 0;" +
                                                              "padding-bottom: 1px'> " +
                                availability +
                                "<p> Unit Price: EGP" + Prodprice + "</p>" +
                                "<p>" + descrip + "</p>" +
                                "</div>" +
                                "<div style='overflow: auto;" +
                                "width:100%;" +
                                "height:30%" +
                                "margin:0px;" +
                                "'>" +
                                // "<input type='text' id='quantity'  placeholder='Count' style='width:70px;height:75%;marin-top:6px'>" +
                                "<asp:Button class='btn-primary' id='orderProduct' runat='server'  onClick='viewProdInfo'  style='display:flex;align-items: center;justify-content:center;" +
                                "font-size: 24px;width: 40px;height: 40px;margin-top:0px;float:right;'/>" +
                                //"<i class='fa fa-cart-plus' >" + "</i> </button>" + 
                                "</div>" +
                                "</div>" +
                                "</div>";

                    Button MyButton = new Button();
                MyButton.CssClass = "btn-primary";
                  //  = "display:flex;align-items: center;justify-content:center; font-size: 24px;width: 40px;height: 40px;margin-top:0px;float:right;'/>";
                MyButton.UseSubmitBehavior = false;
                MyButton.PostBackUrl = "Hosp_product_info.aspx?pid=" + Prodserialno.ToString();

                prodsList.Controls.Add(listed);
                prodsList.Controls.Add(MyButton);

                
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
                
                Label1.Text = ex.Message;
            }
            
        }



    }
}