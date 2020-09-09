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
    public partial class HospOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("viewHospitalOrders", conn);
            cmd.CommandType = CommandType.Text;
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

                // Button AddToCart_btn = new Button();
                // AddToCart_btn.Text = "   Add to cart: " ; 
                // form1.Controls.Add(AddToCart_btn);

            }
        }

        protected void HospitalReg(object sender, EventArgs e)
        {


        }
    }
}