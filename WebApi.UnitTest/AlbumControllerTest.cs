using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using WebApi.Controllers;
using Xunit;

namespace WebApi.UnitTest
{
    public class AlbumControllerTest
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IEnumerable<Album> Data => new List<Album> { new Album { Id = 1, Title = "This is test of data", ArtistName = "Name", Rating = 5 } };

        public AlbumControllerTest()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();

        }

        [Fact]
        public void Constructor_WhenContextNull_ThrowsArgumentNullException()
        {
            //Act
            var actual = Assert.Throws<ArgumentNullException>(() => new AlbumController(null));

            //Assert
            Assert.Equal($"Value cannot be null. (Parameter 'unitOfWork')", actual.Message);

        }

        [Fact]
        public void Constructor_When_Passing_Parameter_NotThrownExpection()
        {

            //Act
            var actual = Record.Exception(() => new AlbumController(_mockUnitOfWork.Object));

            //Assert
            Assert.Null(actual);

        }

        [Theory]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("")]
        public void Search_WhenTitleSearch_is_Null_ThrowsArgumentNullException(string searchText)
        {
            //Arrange
            _mockUnitOfWork.Setup(s => s.Albums.Get(It.IsAny<string>())).Throws(new ArgumentNullException("titlesearch"));
            var controller = new AlbumController(_mockUnitOfWork.Object);
          
            //Act
            var actual =  controller.Search(searchText);

            //Assert
            var contentResult = Assert.IsType<BadRequestObjectResult>(actual);
            Assert.NotNull(contentResult);
            Assert.Equal((int)HttpStatusCode.BadRequest, contentResult.StatusCode);

            Assert.Equal($"Value cannot be null. (Parameter 'titlesearch')", contentResult.Value.ToString());

        }

        [Fact]
        public void Get_WhenTitleSearch_Expected_OkObjectResult()
        {
            //Arrange
            _mockUnitOfWork.Setup(s => s.Albums.Get(It.IsAny<string>())).Returns(Data);
            var controller = new AlbumController(_mockUnitOfWork.Object);
         
            //Act
            var actual = controller.Search("of");

            //Assert
            //Assert
            var contentResult = Assert.IsType<OkObjectResult>(actual);
            Assert.NotNull(contentResult);
            Assert.Equal((int)HttpStatusCode.OK, contentResult.StatusCode);

        }

        [Fact]
        public void Get_WhenTitleSearch_Expected_BadRequestResult()
        {
            //Arrange
            _mockUnitOfWork.Setup(s => s.Albums.Get(It.IsAny<string>())).Throws( new Exception("Test the controller expection block."));
            var controller = new AlbumController(_mockUnitOfWork.Object);

            //Act
            var actual = controller.Search("of");

            //Assert
            var contentResult = Assert.IsType<BadRequestObjectResult>(actual);
            Assert.NotNull(contentResult);
            Assert.Equal((int)HttpStatusCode.BadRequest, contentResult.StatusCode);

        }


    }
}
