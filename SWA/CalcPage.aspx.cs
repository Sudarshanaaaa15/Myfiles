using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class CalcPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResult_Click(object sender, EventArgs e)
        {
            var v1 = double.Parse(firstText.Text);
            var v2 = double.Parse(secondText.Text);
            var operation = dplist.SelectedValue;
            var Res = Result(v1, v2, operation);
            displaylbl.Text = "The Result: " + Res;
        }

        private double Result(double v1,double v2, string operation)
        {
            switch (operation)
            {
                case "add": return v1 + v2;
                case "subtrasct": return v1 - v2;
                case "multiply": return v1 * v2;
                case "division": return v1 / v2;
                default:
                    break;
            }
            return 0;
        }
    }
}