using Moq;
using NUnit.Framework;
using ReviewsCollector.DataAccess.Interfaces;
using ReviewsCollector.DataAccess.Repositories;
using ReviewsCollector.Domain.Entities;
using ReviewsCollector.Domain.Interfaces;
using ReviewsCollector.Tests;
using ReviewsCollector.Web.Controllers;
using System.Collections.Generic;

namespace ReviewsCollector.Web.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        private IUnitOfWork _unitOfWork;

        [SetUp]
        public void TestSetup()
        {            
            _unitOfWork = new Mock<IUnitOfWork>().Object;
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
    }
}
