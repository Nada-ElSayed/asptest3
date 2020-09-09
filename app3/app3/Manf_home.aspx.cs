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

        protected void postProduct(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("INSERT INTO Products ", conn);
            cmd.CommandType = CommandType.Text;
            String prod_name=txt_prod_name.Text;
            String description = txt_desc.Text;
            String price = txt_price.Text;
            string category = radiolist_category.SelectedValue;
            String amount = txt_amount.Text;
            String gtin = txt_GTIN.Text;

            
            cmd.Parameters.Add(new SqlParameter("@name", prod_name));
            cmd.Parameters.Add(new SqlParameter("@description", description));
            cmd.Parameters.Add(new SqlParameter("@unit_price", price));
            cmd.Parameters.Add(new SqlParameter("@available", 1));
            cmd.Parameters.Add(new SqlParameter("@category", category));
            cmd.Parameters.Add(new SqlParameter("@amount", amount));
            cmd.Parameters.Add(new SqlParameter("@manufacturer_id", 1));
            cmd.Parameters.Add(new SqlParameter("@GTIN", gtin));

            conn.Open();

        }


    }
}