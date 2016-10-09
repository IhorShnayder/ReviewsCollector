using ReviewsCollector.Domain.Entities.Enums;
using ReviewsCollector.Domain.Interfaces;
using System.Web.Mvc;

namespace ReviewsCollector.Web.Controllers
{
    public class ReviewsController : Controller
    {
        private IUnitOfWork _u;
        public ReviewsController(IUnitOfWork u)
        {
            _u = u;
        }

        public ViewResult ReviewsList()
        {
            var allReviews = _u.Reviews.GetAll(EntityStatusEnum.Published);

            return View("ReviewsList", allReviews);
        }
    }
}