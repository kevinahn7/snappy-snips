using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistControllerTest
    {
        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            StylistsController controller = new StylistsController();
            ActionResult indexView = controller.Index();
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Details_ReturnsCorrectView_True()
        {
            StylistsController controller = new StylistsController();
            ActionResult indexView = controller.Details(4);
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Index_HasCorrectModelType_Results()
        {
            //Arrange
            StylistsController controller = new StylistsController();
            ViewResult costDataType = controller.Index() as ViewResult;

            //Act
            var result = costDataType.ViewData.Model;

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<Stylist>));
        }
    }
}
