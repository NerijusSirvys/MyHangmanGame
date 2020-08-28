using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MyHangman.Managers;
using MyHangman.Models;
using MyHangman.Services;
using MyHangman.ViewModels;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyHangman.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private UserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<UserManager>();
            }
        }

        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [HttpGet]
        public ActionResult Welcome()
        {
            return View("Welcome");
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogIn(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Looks at the database if there is user with provided username and password
            Player player = await UserManager.FindAsync(model.UserName, model.Password);
            if (player == null)
            {
                EventState eventState = new EventState { IsSuccess = false, Message = "Incorrect pasword or user name" };
                return View("Status", eventState);
            }

            ClaimsIdentity identity = await UserManager.CreateIdentityAsync(player, DefaultAuthenticationTypes.ApplicationCookie);
            AuthManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);

            // TODO map player to game view model
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new RegisterVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            IdentityResult result = await UserManager.CreateAsync(new Player { UserName = model.UserName }, model.Password);

            EventState eventState = EventState.GetEventState(result);

            return View("Status", eventState);
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            AuthManager.SignOut();

            return RedirectToAction("Welcome");
        }
    }
}