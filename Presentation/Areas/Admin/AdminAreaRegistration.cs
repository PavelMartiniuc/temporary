using System.Web.Mvc;

namespace Gitarist.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}/{idc}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional, idc = UrlParameter.Optional },
                new[] { "Gitarist.Areas.Admin.Controllers"}
            );
        }
    }
}
