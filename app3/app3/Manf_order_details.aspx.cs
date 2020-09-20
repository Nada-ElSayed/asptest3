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
    public partial class Manf_order_details : System.Web.UI.Page
    {
        string orderId ;
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["oid"]))
            {
                //If order id can be obtained from the request

                //take order id from the request and store it
                string v = Request.QueryString["oid"];
                orderId = v;
                //obtain connection info and create sql connection to database
                string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
                conn = new SqlConnection(connStr);

                //create a new SQL command which takes as parameters the name of the stored procedure and the SQLconnection name
                SqlCommand cmd = new SqlCommand("viewSpecificManufacturerOrders", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (Session["field1"] == null)
                {
                    //if user is not logged in, then he cannot access a user's order detail page
                    //redirect him to the login page
                    Response.Redirect("Start.aspx");
                }
                else
                {
                    //if username exists in the session, then store it
                    String username = (String)Session["field1"];
                    //Add input of procedure
                    cmd.Parameters.Add(new SqlParameter("@username", username));
                    cmd.Parameters.Add(new SqlParameter("@orderId", orderId));
                    //Executing the SQLCommand
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    //if order exists
                    if (rdr.Read())
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
                        string hospName = rdr.GetString(rdr.GetOrdinal("name"));
                        //Get the value of the attribute address from the output of the procedure
                        string hospAddress = rdr.GetString(rdr.GetOrdinal("address"));

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
                           "<p> Customer Name: " + hospName + " </p>" +
                           "<p> Shipping Address: " + hospAddress + " </p>" +
                           "<p> Quantity:" + quantity + "</p>" +
                           "<p> Total Price: EGP" + totalPrice + "</p>" +
                           "<p> Current Status: " + status + "</p>" +
                           //"<p> Please enter new status: " + dl + "</p>" +
                           "</div>" +

                           "</div>" +
                           "</div>";

                        orderCard.Controls.Add(listed);

                        //Create lables for order detail and add them to the form
                        //Label pageTitle = new Label();
                        //pageTitle.Text = "Order Details";
                        //form1.Controls.Add(pageTitle);
                        //Label newLine = new Label();
                        //newLine.Text = ("</br> </br>");
                        //form1.Controls.Add(newLine);
                        //newLine = new Label();
                        //newLine.Text = ("</br> </br>");
                        //form1.Controls.Add(newLine);

                        //Label orderID = new Label();
                        //orderID.Text = "Order ID: #" + orderno;
                        //form1.Controls.Add(orderID);
                        //newLine = new Label();
                        //newLine.Text = ("</br> </br>");
                        //form1.Controls.Add(newLine);

                        //Label prodName = new Label();
                        //prodName.Text = "Product name: " + productName;
                        //form1.Controls.Add(prodName);
                        //newLine = new Label();
                        //newLine.Text = ("</br> </br>");
                        //form1.Controls.Add(newLine);

                        //Label orderDate = new Label();
                        //orderDate.Text = "Ordered on: " + date;
                        //form1.Controls.Add(orderDate);
                        //newLine = new Label();
                        //newLine.Text = ("</br> </br>");
                        //form1.Controls.Add(newLine);

                        //Label hospname = new Label();
                        //hospname.Text = "Customer name: " + hospName;
                        //form1.Controls.Add(hospname);
                        //newLine = new Label();
                        //newLine.Text = ("</br> </br>");
                        //form1.Controls.Add(newLine);

                        //Label hospaddress = new Label();
                        //hospaddress.Text = "shipping address: " + hospAddress;
                        //form1.Controls.Add(hospaddress);
                        //newLine = new Label();
                        //newLine.Text = ("</br> </br>");
                        //form1.Controls.Add(newLine);

                        //Label quant = new Label();
                        //quant.Text = "Quantity ordered: " + quantity;
                        //form1.Controls.Add(quant);
                        //newLine = new Label();
                        //newLine.Text = ("</br> </br>");
                        //form1.Controls.Add(newLine);

                        //Label totPrice = new Label();
                        //totPrice.Text = "Total price: EGP" + totalPrice;
                        //form1.Controls.Add(totPrice);
                        //newLine = new Label();
                        //newLine.Text = ("</br> </br>");
                        //form1.Controls.Add(newLine);

                        //Label stat = new Label();
                        //stat.Text = "Current status of order: " + status;
                        //form1.Controls.Add(stat);
                        //newLine = new Label();
                        //newLine.Text = ("</br> </br>");
                        //form1.Controls.Add(newLine);

                        //add label
                        //Label l = new Label();
                        //l.Text = "Please enter new status of order";
                        //form1.Controls.Add(l);

                        //Creating and setting the properties of dropdown box
                        var dl = new DropDownList();
                        dl.ID = "status";
                        dl.Items.Add("Please select the status of the order");
                        dl.Items.Add("Pending");
                        dl.Items.Add("Out for Delivery");
                        dl.Items.Add("Delivered");

                        // Adding this dropdown box  to the form 
                        hidden.Controls.Add(dl);

                        //add  Update status of order button
                        Button myButton = new Button();
                        //add text to button
                        myButton.Text = "Update status of order";
                        myButton.CssClass = "btn-primary";
                        //Add a Button Click Event handler
                        myButton.Click += new EventHandler(updateStatus);
                        //add order id to the  button so the update status procedure can know which order will be updated when we click on button
                        myButton.CommandArgument = orderno.ToString();
                        ////add button to form
                        hiddenButton.Controls.Add(myButton);
                    }
                    else
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
     
        private void updateStatus(object sender, EventArgs e)
        {
            try
            {
                //create a new SQL command which takes as parameters the name of the stored procedure and the SQLconnection name
                SqlCommand cmd = new SqlCommand("update_status", conn);

                //Preparing input for the procedure
                string username = (String)Session["field1"];
                Button b = (Button)sender;
                Control c = form1.FindControl("status");
                DropDownList d = (DropDownList)c;
                String val = d.Text;
                if (val != "Please select the status of the order")
                {
                    int orderNo = Int32.Parse(b.CommandArgument);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@orderId", orderNo));
                    cmd.Parameters.Add(new SqlParameter("@username", username));
                    cmd.Parameters.Add(new SqlParameter("@status", val));

                    //Executing the SQLCommand
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    //To navigate to another webpage
                    Response.Write("<script>alert('Order status has been changed');</script>");
                    Response.Write("<script>location.href='Manf_order_details.aspx'</script>");
                }
                else
                {
                    Response.Write("<script>alert('You have not selected a status');</script>");

                }



            }
            catch (Exception e1)
            {
                //we will output No order id found matching the users hospital id.
                Response.Write(e1.Message);
            }
        }
    }
}