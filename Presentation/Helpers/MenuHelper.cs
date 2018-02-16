using System.Web.Mvc;

namespace Gitarist.Helpers
{
    public static class MenuHelper
    {
        public static MvcHtmlString GetActiveClass(this HtmlHelper helper, string curentUrl, string linkUrlPart)
        {

            if (curentUrl.Contains(linkUrlPart))
                return new MvcHtmlString("class='active'");
   
            return new MvcHtmlString("");
        }
    }
}