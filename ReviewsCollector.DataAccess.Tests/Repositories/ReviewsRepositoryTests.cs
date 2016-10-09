using Moq;
using NUnit.Framework;
using ReviewsCollector.DataAccess.Interfaces;
using ReviewsCollector.DataAccess.Repositories;
using ReviewsCollector.Domain.Entities;
using ReviewsCollector.Domain.Entities.Enums;
using ReviewsCollector.Domain.Interfaces;
using ReviewsCollector.Tests;
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
            new Review() { Id = 1, Name = "Name 1", Description = "Description 1", Content = "Content 1", Status = EntityStatusEnum.Published },
            new Review() { Id = 2, Name = "Name 2", Description = "Description 2", Content = "Content 2", Status = EntityStatusEnum.Hidden },
            new Review() { Id = 3, Name = "Name 3", Description = "Description 3", Content = "Content 3", Status = EntityStatusEnum.Published }
        };

        private IUnitOfWork _unitOfWork;
        private IDatabaseContext _dbContext;


        [SetUp]
        public void TestSetup()
        {
            Mock<IDatabaseContext> dbContextMock = new Mock<IDatabaseContext>();
            dbContextMock.Setup(f => f.Reviews).Returns(new CustomDbSetForBaseEntitiy<Review>(_reviewItems));
            dbContextMock.Setup(f => f.SaveChanges()).Returns(0);
            _dbContext = dbContextMock.Object;
            
            _unitOfWork = new Mock<IUnitOfWork>().Object;            
        }

        [TestCase]
        public void Add_ShouldIncreaseItemsCount()
        {
            //Arrange
            var reviewsRepository = new ReviewsRepository(_unitOfWork, _dbContext);

            //Act
            var result = reviewsRepository.Add(new Review() { Id = 3333, Name = "Test", Description = "Description", Content = "Content" });

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, _dbContext.Reviews.Count());
        }

        [TestCase]
        public void Delete_ShouldDeleteSpecifiedItemAndReturnTrue_WhenFound()
        {
            //Arrange
            var reviewsRepository = new ReviewsRepository(_unitOfWork, _dbContext);

            //Act
            var deletingResult = reviewsRepository.Delete(1);

            //Assert
            Assert.AreEqual(true, deletingResult);
            Assert.AreEqual(2, _dbContext.Reviews.Count());
        }

        [TestCase]
        public void Delete_ShouldReturnFalse_WhenNotFound()
        {
            //Arrange
            var reviewsRepository = new ReviewsRepository(_unitOfWork, _dbContext);

            //Act
            var result = reviewsRepository.Delete(9999);

            //Assert            
            Assert.AreEqual(false, result);
            Assert.AreEqual(3, _dbContext.Reviews.Count());
        }

        [TestCase]
        public void GetAll_ShouldReturnAllItemsInRepository()
        {
            //Arrange
            var reviewsRepository = new ReviewsRepository(_unitOfWork, _dbContext);

            //Act
            var items = reviewsRepository.GetAll();

            //Assert
            Assert.AreEqual(3, items.Count());
        }

        [TestCase]
        public void GetAll_ShouldReturnAllItemsInRepositoryByFilter()
        {
            //Arrange
            var reviewsRepository = new ReviewsRepository(_unitOfWork, _dbContext);

            //Act
            var items = reviewsRepository.GetAll(EntityStatusEnum.Published);

            //Assert
            Assert.AreEqual(2, items.Count());
        }

        [TestCase]
        public void GetById_ShouldReturnReview_WhenFound()
        {
            //Arrange
            var reviewsRepository = new ReviewsRepository(_unitOfWork, _dbContext);

            //Act
            var result = reviewsRepository.GetById(1);

            //Assert
            Assert.AreEqual(1, result.Id);
        }

        [TestCase]
        public void GetById_ShouldReturnNull_WhenNotFound()
        {
            //Arrange
            var reviewsRepository = new ReviewsRepository(_unitOfWork, _dbContext);

            //Act
            var result = reviewsRepository.GetById(9999);

            //Assert
            Assert.IsNull(result);
        }

        [TestCase]
        public void Update_ShouldUpdateItemAndReturnUpdatedItem_WhenItemFound()
        {
            //Arrange
            var reviewsRepository = new ReviewsRepository(_unitOfWork, _dbContext);

            //Act
            var result = reviewsRepository.Update(new Review() { Id = 1, Name = "Test", Description = "Description", Content = "Content", Status = EntityStatusEnum.Hidden });

            //Assert
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Test", result.Name);
            Assert.AreEqual("Description", result.Description);
            Assert.AreEqual("Content", result.Content);
            Assert.AreEqual(EntityStatusEnum.Hidden, result.Status);

            var databaseItem = _dbContext.Reviews.FirstOrDefault(f => f.Id == 1);
            Assert.AreEqual("Test", databaseItem.Name);
            Assert.AreEqual("Description", databaseItem.Description);
            Assert.AreEqual("Content", databaseItem.Content);
            Assert.AreEqual(EntityStatusEnum.Hidden, databaseItem.Status);
        }

        [TestCase]
        public void Update_ShouldReturnNull_WhenItemNotFound()
        {
            //Arrange
            var reviewsRepository = new ReviewsRepository(_unitOfWork, _dbContext);

            //Act
            var result = reviewsRepository.Update(new Review() { Id = 9999, Name = "Test", Description = "Description", Content = "Content" });

            //Assert
            Assert.IsNull(result);            
        }
    }
}
