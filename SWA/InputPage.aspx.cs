using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class InputPage : System.Web.UI.Page
    {
        static int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            count++;
        }
        //Called when the user clicks the button....
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            /***************************QueryString***************************
            string Url = $"RecipiantData.aspx?name={txtName.Text}&email={txtEmail.Text}&contact={txtContact.Text}";
            Response.Redirect(Url);
            /***************************Cookies********************/
            HttpCookie cookie = new HttpCookie("MyUserInfo");
            cookie.Values.Add("name", txtName.Text);
            cookie.Values.Add("email", txtEmail.Text);
            cookie.Values.Add("phone", txtContact.Text);
            Response.Cookies.Add(cookie);
            Response.Redirect("RecipiantData.aspx");
            /**********************ViewState**************************
            ViewState["Hits"] = count;
            Response.Write("The Hits: " + ViewState["Hits"].ToString());
            ******************************************************/
        }
       
    }
}