using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ycc_shopping_app_webforms.Shop
{
    public partial class Default : System.Web.UI.Page
    {
        HtmlElements elements = new HtmlElements();
        protected void Page_Load(object sender, EventArgs e)
        {
            Item();
        }
        private void Item()
        {
            int pos = 0;
            string d = string.Empty;
            for (int i = 0; i < 6; i++)
            {
                if (i % 3 == 0) { d += "<div class='row'>"; }

                d += elements.DisplayItems($"images{i+1}.jpg", $"Title {i+1}", $"Description {i+1}", "89");

                if (i % 3 == 2) { d += "</div>"; }
            }
            ITemLiteral.Text = d;
        }
    }
}