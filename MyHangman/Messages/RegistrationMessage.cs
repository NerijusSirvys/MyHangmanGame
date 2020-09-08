using Microsoft.AspNet.Identity;

namespace MyHangman.Messages
{
    public class RegistrationMessage : IMessage
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public static RegistrationMessage GetRegistrationMessage(IdentityResult result)
        {
            RegistrationMessage outcome = new RegistrationMessage();
            if (result.Succeeded)
            {
                outcome.Message = "Registration Complete. Go back and log in to play";
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