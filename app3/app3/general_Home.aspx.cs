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
    public partial class general_Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            findGloves(sender, e);
            findMasks(sender, e);
            findVents(sender, e);

        }

        public void getManf(object sender, EventArgs e)
        {
            List<string> list = new List<string>();


            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("SELECT id, name, rating FROM Manufacturers", conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                //Get the value of the attribute name in the Company table
                int manf_id = rdr.GetInt32(rdr.GetOrdinal("id"));
                string manf_name = rdr.GetString(rdr.GetOrdinal("name"));

                list.Add(manf_name);



            }
        }


        public void getHosp(object sender, EventArgs e)
        {
            List<string> list = new List<string>();


            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("SELECT id, name FROM Hospitals", conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                //Get the value of the attribute name in the Company table
                int manf_id = rdr.GetInt32(rdr.GetOrdinal("id"));
                string manf_name = rdr.GetString(rdr.GetOrdinal("name"));

                list.Add(manf_name);



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
    }
}