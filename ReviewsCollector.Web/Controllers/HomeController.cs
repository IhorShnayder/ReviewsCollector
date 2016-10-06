using ReviewsCollector.DataAccess.Repositories;
using System.Web.Mvc;

namespace ReviewsCollector.Web.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork _u;
        public HomeController(UnitOfWork u)
        {
            _u = u;
        }

        public ViewResult Index()
        {
            return View("Index");
        }

        public ViewResult Reviews()
        {
            var allReviews = _u.Reviews.GetAll();

            return View("Reviews", allReviews);
        }
    }
}