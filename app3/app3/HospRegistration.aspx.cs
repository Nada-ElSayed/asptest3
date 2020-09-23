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
    public partial class HospRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
            DropDownList1.DataSource = list; //just to get the formview going

            DropDownList1.DataBind();

        }

        protected void HospitalReg(object sender, EventArgs e)
        {


            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("hospitalRegister", conn);
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
            cmd.Parameters.Add(new SqlParameter("@hospital_name", company_name));

            //Save the output from the procedure


            //Executing the SQLCommand

            if (username == "" || password == "" || email == "" || company_name == "")
            {
                txtWarning.Text = "Please fill in all fields";
            }
            else
            {
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    txtWarning.Text = ("Registration Successful");
                    conn.Close();

                }
                catch (SqlException ex)
                {
                    txtWarning.Text = ("Error:" + ex.Number + " "+ ex.Message);


                }
            }

            //Response.Write("Registration Successful!");


        }


    }
}