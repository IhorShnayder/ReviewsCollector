using Microsoft.AspNet.Identity.EntityFramework;
using ReviewsCollector.Domain.Entities;
using System.Collections.Generic;

namespace ReviewsCollector.DataAccess.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Review> Reviews { get; set; }
    }
}
