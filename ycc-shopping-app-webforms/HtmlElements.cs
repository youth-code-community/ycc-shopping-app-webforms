using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ycc_shopping_app_webforms
{
    public class HtmlElements
    {
        public HtmlElements() { }
        public string DisplayItems(string imageName, string title, string description, string cost)
        {
            string d = string.Empty;

            d = "<div class='col-md-4 '>" +
                "    <div class='card'>" +
               $"        <img alt='caption' src='../images/{imageName}' class='img-responsive' />" +
                "" +
                "        <div class='card-body'>" +
               $"            <h4 class='card-title'><a href='product.html' title='View Product'>{title}</a></h4>" +
               $"            <p class='card-text'>{description}</p>" +
                "            <hr />" +
                "            <div class='row'>" +
                "               <div class='col'>" +
               $"                   <p class='btn btn-info btn-block '>{cost}</p>" +
                "               </div>" +
                "                <div class='col'>" +
                "                   <a href='#' class='btn btn-success btn-block'>Add to cart</a>" +
                "               </div>" +
                "            </div>" +
                "        </div>" +
                "    </div>" +
                "</div>";

            return d;
        }
    }
}