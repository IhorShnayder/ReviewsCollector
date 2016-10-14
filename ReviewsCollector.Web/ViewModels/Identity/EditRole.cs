using ReviewsCollector.DataAccess.Identity;
using System.Collections.Generic;

namespace ReviewsCollector.Web.ViewModels.Identity
{
    public class EditRole
    {
        public ApplicationRole Role { get; set; }
        public IEnumerable<ApplicationUser> Members { get; set; }
        public IEnumerable<ApplicationUser> NonMembers { get; set; }
    }
}