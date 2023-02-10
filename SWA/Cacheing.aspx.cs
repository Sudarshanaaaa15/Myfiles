using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class Cacheing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            if (Request.QueryString["City"] != null)
            {
                string text = Request.QueryString["City"];
                switch (text.ToLower())
                {
                    case "new delhi":
                        text = DateTime.Now.ToLongTimeString();
                        break;
                    case "london":
                        text = DateTime.Now.AddHours(-5.3).ToLongTimeString();
                        break;
                    case "new york":
                        text = DateTime.Now.AddHours(-11.3).ToLongTimeString();
                        break;
                    case "tokyo":
                        text = DateTime.Now.AddHours(-3.3).ToLongTimeString();
                        break;
                    
                }
                lblClock.Text = text;
            }
        }

        protected void btnTime_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cacheing.aspx?City=" + dpCities.SelectedValue);
        }
    }
}