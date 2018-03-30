using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Customs;
using ShoppingLibrary;


namespace ycc_shopping_app_webforms
{
    public class SessionVerification:System.Web.UI.Page
    {
        RegExpression reg = new RegExpression();
        Encryption enc = new Encryption() { Key = "" };
        
        public SessionVerification()
        {
            var (check, result) = reg.IsPassword("john");
            if (check)
            {
                Session["password"] = enc.GetMD5(enc.StrongEncrypt("john"));
            }
            else { Session["message"] = result; }
        }
    }
}