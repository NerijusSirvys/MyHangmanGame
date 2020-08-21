using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MyHangman.Managers;
using MyHangman.Models;
using MyHangman.Services;
using MyHangman.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyHangman.Controllers
{
    public class AccountController : Controller
    {
        private UserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<UserManager>();
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

                Player player = new Player
                {
                    UserName = model.UserName,
                    GoldenCoins = 0,
                    GameScore = 0
                };

                IdentityResult result = IdentityResult.Failed();
                try
                {
                    result = await UserManager.CreateAsync(player, model.Password);
                }
                catch (Exception ex)
                {
                    throw new HttpException(ex.Message);
                }

                EventState eventState = new EventState();
                if (result.Succeeded)
                {
                    eventState.Message = "Registration Complete";
                    eventState.IsSuccess = true;
                }
                else
                {
                    eventState.Message = "An error occured while adding new player";
                    eventState.IsSuccess = false;
                }

                return View("Status", eventState);
            }

            return View(model);
        }
    }
}