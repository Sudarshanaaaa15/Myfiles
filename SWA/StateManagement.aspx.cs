using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SampleWebApp.Models;

namespace SampleWebApp
{
    public partial class StateManagement : System.Web.UI.Page
    {
        static MusicProducts choosedproduct = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var data = Application["Musicalproducts"] as List<MusicProducts>;
                repeat.DataSource = Application["Musicalproducts"] as List<MusicProducts>;
                repeat.DataBind();
            }
        }
        protected void Click_Onview(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                var id = Convert.ToInt32(e.CommandArgument);
                var data = Application["Musicalproducts"] as List<MusicProducts>;
                choosedproduct = data.Find((p) => p.ProductId == id);
                imgsel.ImageUrl = choosedproduct.Image;
                textpid.Text = choosedproduct.ProductId.ToString();
                textpname.Text = choosedproduct.ProductName;
                textpcost.Text = choosedproduct.Price.ToString();
                textpquanty.Text = choosedproduct.Quantity.ToString();

                var recentList = Session["recentItems"] as Queue<MusicProducts>;
                if (recentList.Count == 5)
                    recentList.Dequeue();
                recentList.Enqueue(choosedproduct);
                Session["recentItems"] = recentList;
                var list = recentList.Reverse();
                recentlst.DataSource = list;
                recentlst.DataBind();
            }
        }
    }
}