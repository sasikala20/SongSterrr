using DataAccess.EFCore.Repositories;
using Domain.Entities;
using Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace DataAccess.EFCore.UnitTest
{
    public class AlbumRepositoryTests
    {
        private Mock<IGenericRepository<Album>> _mockGenericRepository;
        private IEnumerable<Album> Data => new List<Album> { new Album { Id = 1, Title = "This is test of data", ArtistName = "Name", Rating = 5 } };

        public AlbumRepositoryTests() {
            _mockGenericRepository= new Mock<IGenericRepository<Album>>();
        }
        [Fact]
        public void Constructor_WhenContextNull_ThrowsArgumentNullException()
        {
            //Act
            var actual = Assert.Throws<ArgumentNullException>(() => new AlbumRepository(null));

            //Assert
            Assert.Equal($"Value cannot be null. (Parameter 'context')", actual.Message);

        }

        [Fact]
        public void Constructor_When_Passing_Parameter_NotThrownExpection()
        {
             
            //Act
            var actual = Record.Exception(() => new AlbumRepository(_mockGenericRepository.Object));

            //Assert
            Assert.Null(actual);

        }
        [Theory]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("")]
        public void Get_WhenTitleSearch_is_Null_ThrowsArgumentNullException(string searchText)
        {
            //Arrange
            var repos = new AlbumRepository(_mockGenericRepository.Object);

            //Act
            var actual = Assert.Throws<ArgumentNullException>(() =>  repos.Get(searchText));

            //Assert
            Assert.Equal($"Value cannot be null. (Parameter 'titlesearch')", actual.Message);

        }

        [Fact]
        public void Get_WhenTitleSearch_Expected_Return_Empty_Data()
        {
            //Arrange
            var repos = new AlbumRepository(_mockGenericRepository.Object);

            //Act
            var actual = repos.Get("of");

            //Assert
            Assert.Empty(actual);

        }

        [Fact]
        public void Get_WhenTitleSearch_Expected_Data()
        {
            //Arrange
            var repos = new AlbumRepository(_mockGenericRepository.Object);
            _mockGenericRepository.Setup(s => s.Get(It.IsAny<Expression<Func<Album, bool>>>(),
                                                                    It.IsAny<Func<IQueryable<Album>, IOrderedQueryable<Album>>>(),
                                                                    It.IsAny<string>())).Returns(Data);
            //Act
            var actual = repos.Get("of");

            //Assert
            Assert.Single(actual);
            Assert.Equal("This is test <b>of</b> data", actual.FirstOrDefault().Title);

        }
 
    }
}
