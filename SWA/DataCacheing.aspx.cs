using ProductLib.Libraries;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class DataCacheing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cacheObject();
                grdDetails.DataSource = Cache["myData"] as List<Product>;
                grdDetails.DataBind();
                
            }
        }

        private void cacheObject()
        {
            if (Cache["myData"] == null)
            {
                var component = ProductFactory.GetComponent();
                var data = component.GetAllProducts();
                var textfile = Server.MapPath("MyCache.txt");
                /////////////////////////////////////////////////File Dependency////////////////////////////////////////////
                //Cache.Add("myData", data, new System.Web.Caching.CacheDependency(textfile), DateTime.Now.AddMinutes(2), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, null);
                //Cache["myData"] = data;
                ////////////////////////////////////////////////Sql Dependency//////////////////////////////////////////////
                string strCon = ConfigurationManager.ConnectionStrings["cacheString"].ConnectionString;
                SqlCacheDependencyAdmin.EnableNotifications(strCon);
                SqlCacheDependencyAdmin.EnableTableForNotifications(strCon, "Product");
                SqlCacheDependency dependency = new SqlCacheDependency("Output-Cache", "Product");
                Cache.Add("myData", data, dependency, DateTime.Now.AddMinutes(1), Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
                Response.Write("Data got from the DB");
            }
            else
            {
                Response.Write("Data got from the cache");
            }
        }
    }
}