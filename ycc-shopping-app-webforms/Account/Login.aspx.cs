using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingLibrary;

namespace ycc_shopping_app_webforms.Account
{
    public partial class Login : System.Web.UI.Page
    {
        Encryption encryption;
        protected void Page_Load(object sender, EventArgs e)
        {
            encryption = new Encryption() { Key = "" };
        }

        protected void BTN_Click(object sender, EventArgs e)
        {
            var txt = txtOne.Text;
            TextBox1.Text = encryption.GetSH256(txt);
            TextBox2.Text = encryption.GetMD5(txt);
        }
    }
}