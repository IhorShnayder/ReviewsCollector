using Microsoft.AspNet.Identity.Owin;
using ReviewsCollector.DataAccess.Identity;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace ReviewsCollector.Web.Infrastructure
{
    public static class IdentityHelpers
    {
        public static MvcHtmlString GetUserName(this HtmlHelper html, string id)
        {
            ApplicationUserManager mgr = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            return new MvcHtmlString(mgr.FindByIdAsync(id).Result.UserName);
        }

        public static bool IsAdmin(this IPrincipal user)
        {
            return user.IsInRole("Administrator");
        }
    }
}