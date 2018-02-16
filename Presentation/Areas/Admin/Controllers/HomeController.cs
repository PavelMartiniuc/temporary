using System.Web.Mvc;

namespace Gitarist.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //
        // GET: /Admin/Start/

       
        public ActionResult Index()
        {
            return View();
        }

    }
}
