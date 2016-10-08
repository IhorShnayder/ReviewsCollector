using Moq;
using NUnit.Framework;
using ReviewsCollector.DataAccess.Interfaces;
using ReviewsCollector.DataAccess.Repositories;
using ReviewsCollector.DataAccess.Tests;
using ReviewsCollector.Domain.Entities;
using ReviewsCollector.Web.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ReviewsCollector.Web.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        /// <summary>
        /// Test data
        /// </summary>
        private IEnumerable<Review> _reviewItems = new List<Review>()
        {
            new Review() { Id = 1, Name = "Name 1", Description = "Description 1", Content = "Content 1" },
            new Review() { Id = 2, Name = "Name 2", Description = "Description 2", Content = "Content 2" },
            new Review() { Id = 3, Name = "Name 3", Description = "Description 3", Content = "Content 3" }
        };


        private UnitOfWork _unitOfWork;
        private IDatabaseContext _dbContext;

        /// <summary>
        /// Mock database and fill it
        /// </summary>
        [SetUp]
        public void TestSetup()
        {
            Mock<IDatabaseContext> dbContextMock = new Mock<IDatabaseContext>();
            dbContextMock.Setup(f => f.Reviews).Returns(new CustomDbSetForBaseEntitiy<Review>(_reviewItems));
            dbContextMock.Setup(f => f.SaveChanges()).Returns(0);
            _dbContext = dbContextMock.Object;

            _unitOfWork = new UnitOfWork(_dbContext);
        }

        [TestCase]
        public void Index_ShouldReturnIndexView()
        {
            //Arrange
            var homeController = new HomeController(_unitOfWork);

            //Act
            var result = homeController.Index();

            //Assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestCase]
        public void Index_ShouldReturnReviewsView()
        {
            //Arrange
            var homeController = new HomeController(_unitOfWork);

            //Act
            var result = homeController.Reviews();

            //Assert
            Assert.AreEqual("Reviews", result.ViewName);
        }

        [TestCase]
        public void Index_ShouldReturnAllReviews()
        {
            //Arrange
            var homeController = new HomeController(_unitOfWork);

            //Act
            var model = homeController.Reviews().Model as IEnumerable<Review>;

            //Assert
            Assert.IsNotNull(model);
            Assert.AreEqual(_reviewItems.Count(), model.Count());
        }
    }
}
