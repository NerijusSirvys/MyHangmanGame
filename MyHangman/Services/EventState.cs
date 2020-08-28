using Microsoft.AspNet.Identity;

namespace MyHangman.Services
{
    public class EventState
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        internal static EventState GetEventState(IdentityResult result)
        {
            EventState outcome = new EventState();
            if (result.Succeeded)
            {
                outcome.Message = "Registration Complete";
                outcome.IsSuccess = true;
            }
            else
            {
                outcome.Message = "An error occured while adding new player";
                outcome.IsSuccess = false;
            }

            return outcome;
        }
    }
}