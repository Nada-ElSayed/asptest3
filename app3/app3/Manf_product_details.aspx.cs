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
    public partial class Manf_product_details : System.Web.UI.Page
    {
        string Prodserialno;

        int amount = 0;


        string ProdName;
        string Prodprice;
        string GTIN;
        string availability;
        string descrip;
        string category;


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
            string [] categories = { "Ventilator", "Mask", "Gloves" };
            Dropcateg.DataSource = categories;
            Dropcateg.DataBind();

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);



            SqlCommand cmd = new SqlCommand("select * from Products where id=" + Prodserialno, conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SingleRow);


            if (rdr.Read() != null)
            {
                //Get the value of the attribute name in the Company table
                ProdName = rdr.GetString(rdr.GetOrdinal("name"));
                //Get the value of the attribute field in the Company table
                Prodprice = (rdr.GetSqlDecimal(rdr.GetOrdinal("unit_price"))).ToString();
                amount = rdr.GetInt32(rdr.GetOrdinal("amount"));
                GTIN = rdr.GetString(rdr.GetOrdinal("GTIN"));

                if (rdr.GetSqlBoolean(rdr.GetOrdinal("available")))
                {
                    availability = "Available";
                }
                else availability = "Not Available";


                
                if (!rdr.IsDBNull(rdr.GetOrdinal("description")))
                {
                    descrip = (rdr.GetString(rdr.GetOrdinal("description")));
                }
                else descrip = "";


                int ProdVendorID = rdr.GetInt32(rdr.GetOrdinal("manufacturer_id"));

                category = rdr.GetString(rdr.GetOrdinal("category"));

                liTi.Text = "";
                if (category == "GLOV") { liTi.Text = " " + "<h2> Glove </h2>"; }
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
                Literal listed = new Literal();

                listed.Text = "<div class='col-lg-4 col-md-6 mt-4 mt-md-0' style='margin: 0 auto;' > " +
                                "<div class='icon-box' " +
                                            "style='" +
                                            "padding: 30px;" +
                                            "position: relative;" +
                                            "overflow: hidden;" +
                                            "background: #fff;" +
                                            "box-shadow: 0 16px 29px 0 rgba(68, 88, 144, 0.2);" +
                                            "transition: all 0.3s ease-in-out;" +
                                            "height: 90%;" +
                                            "text-align:center;' >" +
                                "<h4 class='prodName' style='" +

                                                    "font-weight: 700;" +
                                                    "font-size: 18px; '>" +
                                "" + ProdName + "</h4>" +
                                "<div class='prodDes' style='font-size: 14px;" +

                                                              "line-height: 24px;" +
                                                              "margin-bottom: 0;" +
                                                              "padding-bottom: 1px'> " +
                                "<p> Global Trade Number: " + GTIN + "</p>" +
                                "<p> Manufacturer: " + vendorName + "</p>" +
                                "<p> Unit Price: EGP" + Prodprice + "</p>" +
                                "<p> Details: </br>" + descrip + "</p>" +
                                "<p> Available Amount in  Stock: " + amount + "</p>" +
                                "Status: " + availability +
                                "</div>" +

                                "</div>" +
                                "</div>";

                prodsList.Controls.Add(listed);
                Button myButton = new Button();
                myButton.CssClass = "btn-primary";
                myButton.Text = "Delete product";
                myButton.Click +=  new EventHandler(deleteProduct);
                myButton.CommandArgument = Prodserialno.ToString();
                con.Controls.Add(myButton);
            }
            else
            {
                Response.Write("<script>alert('Product Does exist.');</script>");
            }

        }

        private void deleteProduct(object sender, EventArgs e)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                //create a new SQL command which takes as parameters the name of the stored procedure and the SQLconnection name
                SqlCommand cmd = new SqlCommand("deleteManufacturerProducts", conn);

                //Preparing input for the procedure
                string username = (String)Session["field1"];
                Button b = (Button)sender;
                int productNo = Int32.Parse(b.CommandArgument);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@username", username));
                cmd.Parameters.Add(new SqlParameter("@product_id", productNo));

                //Executing the SQLCommand
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                //To navigate to another webpage
                Response.Write("<script>alert('Your product has been deleted.');</script>");
                Response.Write("<script>location.href='Manf_home.aspx'</script>");
            }
            catch (Exception e1)
            {
                Response.Write(e1.Message);               
            }
        }

        protected void editProduct(object sender, EventArgs e)
        {
            bool edit_success = true;

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand cmd = new SqlCommand("EditProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@username", Session["field1"]));
            cmd.Parameters.Add(new SqlParameter("@pid", Prodserialno));
            if (Textpname.Text.Length > 0)
            {
                cmd.Parameters.Add(new SqlParameter("@pname", Textpname.Text));
            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@pname", ProdName));

            }
            cmd.Parameters.Add(new SqlParameter("@info", Textinfo.Text));

            if (Textunit_price.Text.Length > 0)
            {
                cmd.Parameters.Add(new SqlParameter("@unit_price", Textunit_price.Text));

            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@unit_price", Prodprice));

            }
            if (Textamount.Text.Length>0)
            {
                try
                {
                    if (Int64.Parse(Textamount.Text) < 0)
                    {
                        edit_success = false;
                        Label1.Text = "invalid amount. Must be greater than 0.";
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@amount", Textamount.Text));
                    }
                }
                catch(Exception ex)
                {
                    Response.Write("<script>alert('Please enter a valid amount');</script>");

                }
            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@amount", amount));

            }
            if (Textgtin.Text.Length > 0)
            {
                if (Textgtin.Text.Length == 8 || Textgtin.Text.Length > 12 || Textgtin.Text.Length > 13 || Textgtin.Text.Length > 14)
                {
                    try{
                        Int64.Parse(Textgtin.Text);
                        cmd.Parameters.Add(new SqlParameter("@gtin", Textgtin.Text));
                    }
                    catch(Exception ex)
                    {
                        edit_success = false;
                        Label1.Text = "invalid GTIN. Must only consist of numbers.";
                    }
                    
                }
                else
                {
                    edit_success = false;
                    Label1.Text = "invalid GTIN. Must be of length 8, 12, 13 or 14";
                }
            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@gtin", GTIN));

            }
            if (Dropcateg.SelectedValue == "Gloves")
            {
                cmd.Parameters.Add(new SqlParameter("@categ", "GLOV"));

            }
            if (Dropcateg.SelectedValue == "Mask")
            {
                cmd.Parameters.Add(new SqlParameter("@categ", "MASK"));

            }
            if (Dropcateg.SelectedValue == "Ventilator")
            {
                cmd.Parameters.Add(new SqlParameter("@categ", "VENT"));

            }
            

            conn.Open();
            try
            {
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                Response.Write("<script>alert('Product Edited Successfully.');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");

            }

           /* if (edit_success)
            {
                Response.Write("<script>alert('Product Edited Successfully.');</script>");
            }*/


        }

        protected void cancelChanges(object sender, EventArgs e)
        {
            Textpname.Text = "";
            Textinfo.Text = "";
            Textunit_price.Text = "";
            Textamount.Text = "";
            Textgtin.Text = "";
        }

      

    }
    }
