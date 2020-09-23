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
    public partial class ManfRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            List<string> list = new List<string>();


            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("SELECT id, name FROM Manufacturers", conn);
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
            DropDownList1.DataSource = list; //just to get the formview going

            DropDownList1.DataBind();

        }

       

        protected void VendorReg(object sender, EventArgs e)
        {

            
            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("manufacturerRegister", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //To read the input from the user
            string username = usr.Text;
            string password = pass.Text;
            string company_name = DropDownList1.SelectedValue;
            string email = eml.Text;
            
          
 

            //pass parameters to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@username", username));
            cmd.Parameters.Add(new SqlParameter("@password", password));
            cmd.Parameters.Add(new SqlParameter("@email", email));
            cmd.Parameters.Add(new SqlParameter("@manufacturer_name", company_name));

            //Save the output from the procedure


            //Executing the SQLCommand

            if (username == "" || password == ""  || email == "" || company_name == "" )
            {
               // txtMessages.Text = "please fill all boxes";
                txtWarning.Text = "!Please fill in all Feilds.";
            }
            else
            {
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //txtMessages.Text = ("success");
                    txtWarning.Text = ("success");
                    conn.Close();

                }
                catch (SqlException ex)
                {
                    //if (ex.Number == 2627 || ex.Number == 2601 || ex.Number== 50007)
                    //{
                    //txtMessages.Text = "this username is already taken";
                    //  txtWarning.Text = "This username is already taken";
                    //}
                    //else
                    //{
                    // txtMessages.Text = ("please choose another username (below 30 characters).error:" + ex.Number);
                    txtWarning.Text = ("Error:" + ex.Number + " " + ex.Message);                    //}

                }
            }

            //Response.Write("Registration Successful!");


        }


    }
}