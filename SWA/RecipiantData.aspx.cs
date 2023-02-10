using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class RecipiantData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //querystring();
            cookies();
        }

        private void cookies()
        {
            var cookie = Request.Cookies["MyUserInfo"];
            if (cookie == null)
            {
                lblMessage.Text = "This page doesn't contain any information. Please visit the Mainpage and provide the required informations.";
            }
            else
            {
                string msg = $"The Name is {cookie.Values["name"]}<br/>The Email Address is {cookie.Values["email"]}<br/>The Contact No entered is {cookie.Values["phone"]}";
                lblMessage.Text = msg;
            }
        }

        private void querystring()
        {
            if (Request.QueryString.Count == 0)
            {
                lblMessage.Text = "This page does not contain any information. Please visit the Mainpage and provide the required informations.";
            }
            else
            {
                try
                {
                    string msg = $"The Name entered is {Request.QueryString["name"]}<br/>The Email Address is {Request.QueryString["email"]}<br/>The Contact No entered is {Request.QueryString["contact"]}";
                    lblMessage.Text = msg;
                }
                catch (NullReferenceException)
                {
                    lblMessage.Text = "Querystring keys are not correct";
                }
                catch (FormatException)
                {
                    lblMessage.Text = "String wasnt populated properly";
                }

            }
        }
    }
}