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
    public partial class Hosp_order_details : System.Web.UI.Page
    {
        string orderId;
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(true)
            //if(!string.IsNullOrEmpty(Request.QueryString["oid"]))
            {
                //If order id can be obtained from the request

                //take order id from the request and store it
                string v = Request.QueryString["oid"];
                orderId = v;
                orderId = "1";

                //obtain connection info and create sql connection to database
                string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
                conn = new SqlConnection(connStr);

                //create a new SQL command which takes as parameters the name of the stored procedure and the SQLconnection name
                SqlCommand cmd = new SqlCommand("viewHospitalOrders", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if(false)
                //if (Session["field1"] == null)
                {
                    //if user is not logged in, then he cannot access a user's order detail page
                    //redirect him to the login page
                    Response.Redirect("Start.aspx");
                }
                else
                {
                    //if username exists in the session, then store it
                    String username = (String)Session["field1"];
                    username = "ahmed_H1";
                    //Add input of procedure
                    cmd.Parameters.Add(new SqlParameter("@username", username));


                    //Executing the SQLCommand
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    //loop over the rows returned by reader to find the row that matches the desired order
                    bool found = false;
                    while (rdr.Read())
                    {
                        //Get the value of the attribute order_id from the output of the procedure
                        int orderno = rdr.GetInt32(rdr.GetOrdinal("order_id"));
                        //Get the value of the attribute status from the output of the procedure
                        string status = rdr.GetString(rdr.GetOrdinal("status"));
                        //Get the value of the attribute date from the output of the procedure
                        string date = (rdr.GetSqlDateTime(rdr.GetOrdinal("date"))).ToString();
                        //Get the value of the attribute total_price from the output of the procedure
                        string totalPrice = (rdr.GetSqlDecimal(rdr.GetOrdinal("total_price"))).ToString();
                        //Get the value of the attribute product_id from the output of the procedure
                        int prodno = rdr.GetInt32(rdr.GetOrdinal("product_id"));
                        //Get the value of the attribute quantity from the output of the procedure
                        int quantity = rdr.GetInt32(rdr.GetOrdinal("quantity"));
                        //Get the value of the attribute name from the output of the procedure
                        string manfName = rdr.GetString(rdr.GetOrdinal("name"));

                        //if this is the order we are looking for
                        if (orderno == Int32.Parse(orderId))
                        {
                            //before we output the order details to the form, we need the product name by using a SQL query
                            cmd = new SqlCommand("select * from Products where id=" + prodno, conn);
                            cmd.CommandType = CommandType.Text;
                            conn.Close();
                            conn.Open();
                            rdr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                            rdr.Read();
                            String productName = rdr.GetString(rdr.GetOrdinal("name"));
                            conn.Close();


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
                               "Order ID: #" + orderno + "</h4>" +
                               "<div class='prodDes' style='font-size: 14px;" +

                                                             "line-height: 24px;" +
                                                             "margin-bottom: 0;" +
                                                             "padding-bottom: 1px'> " +
                               "<p> Product Number: " + prodno + "</p>" +
                               "<p> Ordered On: " + date + "</p>" +
                               "<p> To be provided by: " + manfName + " </p>" +
                               "<p> Quantity:" + quantity  + "</p>" +
                               "<p> Total Price: EGP" + totalPrice + "</p>" +
                               "<p> Current Status: " + status + "</p>"+
                               "</div>" +

                               "</div>" +
                               "</div>";

                            orderCard.Controls.Add(listed);


                            //add cancel order button
                            Button myButton = new Button();
                            //add text to button
                            myButton.Text = "Cancel Order";
                            //Add a Button Click Event handler  
                            myButton.Click += new EventHandler(cancelOrder); //ONclick
                            //add order id to the button so the cancel order procedure can know which order will be canceled when we click on button
                            myButton.CommandArgument = orderno.ToString();
                            //add button to form
                            con.Controls.Add(myButton);


                            //we found the order so we can stop looping on the rows
                            found = true; break;
                        }
                    }
                    if (!found)
                    {
                        //if the row has not been found then no order details can be found matching this order id and this user name
                        Response.Write("Page not found.");
                    }
                }
            }
            else
            {
                //If no order id obtained from request
                Response.Write("NO DATA PROVIDED OR COULD NOT BE READ");
            }
        }
        private void cancelOrder(object sender, EventArgs e)
        {
            try
            {
                /*create a new SQL command which takes as parameters the name of the stored procedure and the SQLconnection name*/
                SqlCommand cmd = new SqlCommand("cancelOrder", conn);

                //To read the input from the user
                string username = (String)Session["field1"];
                username = "ahmed_H1";
                Button b = (Button)sender;
                int orderNo = Int32.Parse(b.CommandArgument);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@orderId", orderNo));
                cmd.Parameters.Add(new SqlParameter("@username", username));

                //Executing the SQLCommand
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                //To navigate to another webpage
                Response.Write("<script>alert('Thank you, your order has been canceled.');</script>");
                Response.Write("<script>location.href='Hosp_home.aspx'</script>");
            }
            catch (Exception e1)
            {
                //we will output No order id found matching the users hospital id.
                Response.Write(e1.Message);
            }
        }

    }
}