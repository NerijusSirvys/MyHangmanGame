using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using MyHangman.Data;
using MyHangman.Models;

namespace MyHangman.Managers
{
    public class UserManager : UserManager<Player>
    {
        public UserManager(IUserStore<Player> store) : base(store)
        {
        }

        public static UserManager Create(IdentityFactoryOptions<UserManager> options, IOwinContext context)
        {
            GameDbContext gameDbContext = context.Get<GameDbContext>();
            UserManager manager = new UserManager(new UserStore<Player>(gameDbContext));

            manager.UserValidator = new UserValidator<Player>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequireDigit = false,
                RequiredLength = 5,
                RequireLowercase = false,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false
            };

            return manager;
        }
    }
}