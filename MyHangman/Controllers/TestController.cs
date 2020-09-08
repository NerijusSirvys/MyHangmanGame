using MyHangman.Messages;
using System.Web.Mvc;

namespace MyHangman.Controllers
{
    // Test controler for testing individual pages and their functionality
    public class TestController : Controller
    {
        // Status page displayed after registration
        // Different variations if registration is complete and if error occured for any reason
        public ActionResult StatusPage()
        {
            RegistrationMessage stateSuccess = new RegistrationMessage { IsSuccess = true, Message = "Registration Complete" };
            RegistrationMessage stateFailed = new RegistrationMessage { IsSuccess = false, Message = "Error. Registration cancelled" };
            return View("Status", stateSuccess);
        }

        public ActionResult GameOverPage()
        {
            RegistrationMessage eventState = new RegistrationMessage
            {
                IsSuccess = false,
                Message = "You run out of guesses. Game Over..."
            };

            return View("Status", eventState);
        }
    }
}