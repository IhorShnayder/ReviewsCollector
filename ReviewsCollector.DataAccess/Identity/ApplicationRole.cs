using Microsoft.AspNet.Identity.EntityFramework;

namespace ReviewsCollector.DataAccess.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base()
        {

        }

        public ApplicationRole(string roleName) : base(roleName)
        {

        }
    }
}
