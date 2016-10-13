using Owin;
using ReviewsCollector.DataAccess.Identity;

namespace ReviewsCollector.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            IdentityConfig.Config(app);
        }
    }
}
