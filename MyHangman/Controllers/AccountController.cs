using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MyHangman.Managers;
using MyHangman.Messages;
using MyHangman.Models;
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
                IMessage registrationMessage = new RegistrationMessage { IsSuccess = false, Message = "Incorrect pasword or user name" };
                return View("Status", registrationMessage);
            }

            ClaimsIdentity identity = await UserManager.CreateIdentityAsync(player, DefaultAuthenticationTypes.ApplicationCookie);

            AuthManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);

            return RedirectToAction("BeginNewLevel", "Home");
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
            if (ModelState.IsValid)
            {
                Player player = new Player { UserName = model.UserName };

                IdentityResult result = await UserManager.CreateAsync(player, model.Password);

                if (result.Succeeded)
                {
                    ClaimsIdentity identity = await UserManager.CreateIdentityAsync(player, DefaultAuthenticationTypes.ApplicationCookie);

                    AuthManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);

                    return RedirectToAction("BeginNewLevel", "Home");
                }
                else
                {
                    IMessage registrationMessage = RegistrationMessage.GetRegistrationMessage(result);

                    return View("Status", registrationMessage);
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            AuthManager.SignOut();

            return RedirectToAction("Welcome");
        }
    }
}