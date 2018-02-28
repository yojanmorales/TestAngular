using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using APINET;
using APINET.Controllers;

namespace APINET.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {

        //private Mock<ICityData> cityDataMock = null;
        //private CityBussiness cityBussiness = null;

        [TestInitialize]
        public void InitializeTest()
        {
            //    this.cityDataMock = new Mock<ICityData>();
            //    this.cityBussiness = new CityBussiness(
            //        this.cityDataMock.Object);
        }
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
