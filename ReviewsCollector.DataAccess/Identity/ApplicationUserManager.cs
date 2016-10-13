using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace ReviewsCollector.DataAccess.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {

        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            DatabaseContext db = context.Get<DatabaseContext>();

            ApplicationUserManager manager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));

            manager.PasswordValidator = new PasswordValidator()
            {
                RequireDigit = true
            };

            return manager;
        }
    }
}
