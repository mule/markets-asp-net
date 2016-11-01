using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using markets_aspnet;
using markets_aspnet.Controllers;

namespace markets_aspnet.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Should_return_all_markets_exposure_when_path_is_empty()
        {
            var controller = new HomeController();
            var result = controller.Exposures(String.Empty);

            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void Should_return_level_1_market_exposures_when_path_is_allmarkets()
        {
            var controller = new HomeController();
            var result = controller.Exposures("allmarkets.*");

            Assert.IsNotNull(result);

        }
    }
}
