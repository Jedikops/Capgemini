using System.Web.Mvc;
using Xunit;
using Xunit.Abstractions;
using Capgemini.Tests.XUnit.Fixtures;

namespace Capgemini.Tests.Controllers
{
    [Collection("Controllers Collection")]
    [Trait("Category", "Home Controller Tests")]   
    public class HomeControllerTest //: IClassFixture<ControllersFixture> //: IDisposable 
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly ControllersFixture _fixture;

        //private HomeController _controller;

        public HomeControllerTest(ITestOutputHelper helper, ControllersFixture fixture)
        {
            _outputHelper = helper;
            //_outputHelper.WriteLine("Create sut");
            //_controller = new HomeController();
            _fixture = fixture;

        }

        [Fact]
        public void Index()
        {
            // Arrange


            // Act
            //ViewResult result = _controller.Index() as ViewResult;
            ViewResult result = _fixture.HomeController.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Message()
        {
            // Arrange

            // Act
            //ViewResult result = _controller.Contact() as ViewResult;
            ViewResult result = _fixture.HomeController.Contact() as ViewResult;

            _outputHelper.WriteLine("Checking message string value.");

            // Assert
            Assert.Equal("Your contact page.", result.ViewBag.Message);
        }

        [Fact]
        public void Contact()
        {
            // Arrange

            // Act
            //ViewResult result = _controller.Contact() as ViewResult;
            ViewResult result = _fixture.HomeController.Contact() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        //public void Dispose()
        //{
        //    _outputHelper.WriteLine("Disposing sut");
        //}
    }
}
