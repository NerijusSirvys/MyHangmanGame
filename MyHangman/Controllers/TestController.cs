using MyHangman.Services;
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
            EventState stateSuccess = new EventState { IsSuccess = true, Message = "Registration Complete" };
            EventState stateFailed = new EventState { IsSuccess = false, Message = "Error. Registration cancelled" };
            return View("Status", stateSuccess);
        }
    }
}