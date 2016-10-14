using Microsoft.AspNet.Identity.EntityFramework;

namespace ReviewsCollector.DataAccess.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Description { get; set; }
    }
}
