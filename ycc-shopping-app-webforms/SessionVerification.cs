using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingLibrary;


namespace ycc_shopping_app_webforms
{
    public class SessionVerification:System.Web.UI.Page
    {
        
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        RegExpression reg = new RegExpression();
        Encryption enc = new Encryption();
        public SessionVerification()
        {

        }
    }
}