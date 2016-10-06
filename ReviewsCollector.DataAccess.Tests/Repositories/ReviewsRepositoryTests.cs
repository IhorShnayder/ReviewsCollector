using Moq;
using NUnit.Framework;
using ReviewsCollector.DataAccess.Interfaces;
using ReviewsCollector.DataAccess.Repositories;
using ReviewsCollector.DataAccess.Tests;
using ReviewsCollector.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ReviewsCollector.DataAccess.Tests
{
    [TestFixture]
    public class ReviewsRepositoryTests
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
        public void GetAll_ShouldReturnAllItemsInRepository()
        {
            //Arrange
            var reviewsRepository = new ReviewsRepository(_unitOfWork);

            //Act
            var items = reviewsRepository.GetAll();

            //Assert
            Assert.AreEqual(3, items.Count());
        }

        [TestCase]
        public void GetById_ShouldReturnReview_WhenFound()
        {
            //Arrange
            var reviewsRepository = new ReviewsRepository(_unitOfWork);

            //Act
            var result = reviewsRepository.GetById(1);

            //Assert
            Assert.AreEqual(1, result.Id);
        }

        [TestCase]
        public void GetById_ShouldReturnNull_WhenNotFound()
        {
            //Arrange
            var reviewsRepository = new ReviewsRepository(_unitOfWork);

            //Act
            var result = reviewsRepository.GetById(9999);

            //Assert
            Assert.IsNull(result);
        }

        [TestCase]
        public void Delete_ShouldDeleteSpecifiedItemAndReturnTrue_WhenFound()
        {
            //Arrange
            var reviewsRepository = new ReviewsRepository(_unitOfWork);

            //Act
            var deletingResult = reviewsRepository.Delete(1);
            var item = reviewsRepository.GetById(1);

            //Assert
            Assert.AreEqual(2, reviewsRepository.GetAll().Count());
            Assert.AreEqual(true, deletingResult);
            Assert.IsNull(item);
        }

        [TestCase]
        public void Delete_ShouldReturnFalse_WhenNotFound()
        {
            //Arrange
            var reviewsRepository = new ReviewsRepository(_unitOfWork);

            //Act
            var result = reviewsRepository.Delete(9999);

            //Assert
            Assert.AreEqual(3, reviewsRepository.GetAll().Count());
            Assert.AreEqual(false, result);
        }

        [TestCase]
        public void Add_ShouldIncreaseItemsCount()
        {
            //Arrange
            var reviewsRepository = new ReviewsRepository(_unitOfWork);

            //Act
            var result = reviewsRepository.Add(new Review() { Id = 3333, Name = "Test", Description = "Description", Content = "Content" });

            //Assert
            Assert.AreEqual(4, reviewsRepository.GetAll().Count());
            Assert.IsNotNull(result);
        }

        [TestCase]
        public void Update_ShouldUpdateItemAndReturnUpdatedItem_WhenItemFound()
        {
            //Arrange
            var reviewsRepository = new ReviewsRepository(_unitOfWork);

            //Act
            var result = reviewsRepository.Update(new Review() { Id = 1, Name = "Test", Description = "Description", Content = "Content" });

            //Assert
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Test", result.Name);
            Assert.AreEqual("Description", result.Description);
            Assert.AreEqual("Content", result.Content);
        }

        [TestCase]
        public void Update_ShouldReturnNull_WhenItemNotFound()
        {
            //Arrange
            var reviewsRepository = new ReviewsRepository(_unitOfWork);

            //Act
            var result = reviewsRepository.Update(new Review() { Id = 9999, Name = "Test", Description = "Description", Content = "Content" });

            //Assert
            Assert.IsNull(result);            
        }
    }
}
