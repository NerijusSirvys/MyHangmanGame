using System.Web.Mvc;

namespace MyHangman.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Welcome()
        {
            return View("Welcome");
        }

        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}