using SampleWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SampleWebApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["Musicalproducts"] = ProductRepo.AllProducts;
        }
        protected void Session_start(object sender,EventArgs e)
        {
            Session["MyLocalcart"] = new List<MusicProducts>();
            Session["RecentItems"] = new Queue<MusicProducts>();
        }
    }
}