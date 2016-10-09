using ReviewsCollector.Domain.Interfaces;
using System.Web.Mvc;

namespace ReviewsCollector.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork _u;
        public HomeController(IUnitOfWork u)
        {
            _u = u;
        }

        public ViewResult Index()
        {
            return View("Index");
        }
    }
}