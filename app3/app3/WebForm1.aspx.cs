using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace app3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void ButtonClick(Object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                Label1.Text = "Page is valid.";
            }
            else
            {
                Label1.Text = "Page is not valid!!";
            }

        }
    }
}