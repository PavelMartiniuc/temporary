using Gitarist.Areas.Admin.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace Gitarist.Areas.Admin.Controllers
{
    public class AuthorizeController : Controller
    {
        //
        // GET: /Admin/Authorize/
        [HttpGet]
        public ActionResult Index()
        {
            return View(new UserAccount());
        }

        [HttpPost]
        public ActionResult Index(UserAccount user)
        {
            user.ErrorMessage = "";
            if (ModelState.IsValid)
            {
                if (FormsAuthentication.Authenticate(user.Login.Trim(), user.Password.Trim()))
                    FormsAuthentication.RedirectFromLoginPage(user.Login.Trim(), user.RememeberMe);
                else
                    user.ErrorMessage = "Неверный логин или пароль";
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");
        }

    }
}
