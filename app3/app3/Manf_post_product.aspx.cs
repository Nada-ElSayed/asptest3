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
    public partial class Manf_post_product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void postProduct(object sender, EventArgs e)
        {


            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand cmd = new SqlCommand("PostProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@username", Session["field1"]));
            cmd.Parameters.Add(new SqlParameter("@pname", Textpname.Text));
            cmd.Parameters.Add(new SqlParameter("@info", Textinfo.Text));
            cmd.Parameters.Add(new SqlParameter("@unit_price", Textunit_price.Text));
            cmd.Parameters.Add(new SqlParameter("@amount", Textamount.Text));
            cmd.Parameters.Add(new SqlParameter("@gtin", Textgtin.Text));

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
            Label1.Text = "Product Updated Successfully!";
            try
            {
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }



        }
    }
}