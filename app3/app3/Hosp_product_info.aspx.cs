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

namespace app3
{
    public partial class Hosp_product_info : System.Web.UI.Page
    {
        string Prodserialno;
        
        int amount = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["pid"]))
            {
                string v = Request.QueryString["pid"];
                Prodserialno = v;
            }
            else
            {
                Response.Write("NO DATA PROVIDED OR COULD NOT BE READ");
            }

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            


            SqlCommand cmd = new SqlCommand("select * from Products where id=" + Prodserialno, conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SingleRow);


            if (rdr.Read() != null)
            {
                //Get the value of the attribute name in the Company table
                string ProdName = rdr.GetString(rdr.GetOrdinal("name"));
                //Get the value of the attribute field in the Company table
                string Prodprice = (rdr.GetSqlDecimal(rdr.GetOrdinal("unit_price"))).ToString();
                amount = rdr.GetInt32(rdr.GetOrdinal("amount"));
                string GTIN = rdr.GetString(rdr.GetOrdinal("GTIN"));

                string availability = (rdr.GetSqlBoolean(rdr.GetOrdinal("available"))).ToString();
                if (rdr.GetSqlBoolean(rdr.GetOrdinal("available")))
                {
                    availability = "available";
                }
                else availability = "not available";


                string descrip;
                if (!rdr.IsDBNull(rdr.GetOrdinal("description")))
                {
                    descrip = (rdr.GetString(rdr.GetOrdinal("description")));
                }
                else descrip = "__";


                int ProdVendorID= rdr.GetInt32(rdr.GetOrdinal("manufacturer_id"));

                string category = rdr.GetString(rdr.GetOrdinal("category"));

                 liTi.Text = ""; 
                if (category == "GLOV") { liTi.Text = " "+"<h2> Glove </h2>"; }
                if (category == "MASK") { liTi.Text = " " + "<h2> Mask </h2>"; }
                if (category == "VENT") { liTi.Text = " " + "<h2> Ventilator </h2>"; }

                conn.Close();
                SqlCommand cmd2 = new SqlCommand("select * from Manufacturers where id=" + ProdVendorID, conn);
                cmd2.CommandType = CommandType.Text;
                conn.Open();
                string vendorName = "Name not Available";
                SqlDataReader rdr2 = cmd2.ExecuteReader(CommandBehavior.SingleRow);
                if (rdr2.Read() != null)
                {
                    vendorName = rdr2["name"].ToString();
                }

                conn.Close();
                RangeValidator1.MaximumValue = amount + "";
                RangeValidator1.Text = "The value must be from 1 to " + amount;
                Literal listed = new Literal();

                listed.Text = "<div class='col-lg-4 col-md-6 mt-4 mt-md-0'>" +
                                "<div class='icon-box' " +
                                            "style='" +
                                            "padding: 30px;" +
                                            "position: relative;" +
                                            "overflow: hidden;" +
                                            "background: #fff;" +
                                            "box-shadow: 0 16px 29px 0 rgba(68, 88, 144, 0.2);" +
                                            "transition: all 0.3s ease-in-out;" +
                                            "height: 90%;' >" +
                                "<h4 class='prodName' style='" +
                  
                                                    "font-weight: 700;" +
                                                    "font-size: 18px; '>" +
                                "" + ProdName +"</h4>" +
                                "<div class='prodDes' style='font-size: 14px;" +
                                                             
                                                              "line-height: 24px;" +
                                                              "margin-bottom: 0;" +
                                                              "padding-bottom: 1px'> " +
                                "<p> Global Trade Number: " + GTIN + "</p>" +
                                "<p> Manufacturer: " + vendorName + "</p>" +
                                "<p> Unit Price: EGP" + Prodprice + "</p>" +
                                "<p> Details: </br>"+ descrip + "</p>" +
                                "<p> Available Amount in  Stock: " + amount + "</p>" +
                                "Status: "+availability +
                                "</div>" +
                                
                                "</div>" +
                                "</div>";

                prodsList.Controls.Add(listed);

               


            }
            else
            {
                Response.Write("Product does not exist.");
            }

        }
        protected void placeOrder(object sender, EventArgs e)
        {


            RangeValidator1.MaximumValue = amount+"";

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand cmd = new SqlCommand("placeOrder", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@username", Session["field1"]));
            cmd.Parameters.Add(new SqlParameter("@quantity", orderamountTXT.Text));
            cmd.Parameters.Add(new SqlParameter("@product", Prodserialno));

            conn.Open();
            Label1.Text = "Order Placed Successfully!";
            try
            {
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
          //  Response.Redirect(Request.RawUrl);
            


        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Hosp_home.aspx");
        }


    }
}