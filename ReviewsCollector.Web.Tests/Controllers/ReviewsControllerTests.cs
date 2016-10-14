using NUnit.Framework;
using ReviewsCollector.Domain.Entities;
using ReviewsCollector.Web.Controllers;
using System.Collections.Generic;
using Moq;
using ReviewsCollector.Domain.Interfaces;

namespace ReviewsCollector.Web.Tests.Controllers
{
    [TestFixture]
    public class ReviewsControllerTests
    {
        private IUnitOfWork _unitOfWork;

        [SetUp]
        public void TestSetup()
        {
            Mock<IReviewsRepository> reviewsRepositoryMock = new Mock<IReviewsRepository>();
            reviewsRepositoryMock.Setup(f => f.GetAll(null)).Returns(new List<Review>());
            
            Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(f => f.Reviews).Returns(reviewsRepositoryMock.Object);

            _unitOfWork = unitOfWorkMock.Object;
        }

        [TestCase]
        public void ReviewsList_ShouldReturnReviewsListView()
        {
            //Arrange
            var reviewsController = new ReviewsController(_unitOfWork);

            //Act
            var result = reviewsController.ReviewsList();

            //Assert
            Assert.AreEqual("ReviewsList", result.ViewName);
        }

        [TestCase]
        public void ReviewsList_ShouldReturnAllReviews()
        {
            //Arrange
            var reviewsController = new ReviewsController(_unitOfWork);

            //Act
            var model = reviewsController.ReviewsList().Model as IEnumerable<Review>;

            //Assert
            Assert.IsNotNull(model);
        }
    }
}
