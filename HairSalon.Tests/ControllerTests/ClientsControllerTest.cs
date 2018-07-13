using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientsControllerTest
    {
        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            ClientsController controller = new ClientsController();
            ActionResult indexView = controller.Index();
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void All_ReturnsCorrectView_True()
        {
            ClientsController controller = new ClientsController();
            ActionResult indexView = controller.All();
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Index_HasCorrectModelType_Results()
        {
            //Arrange
            ClientsController controller = new ClientsController();
            ViewResult costDataType = controller.Index() as ViewResult;

            //Act
            var result = costDataType.ViewData.Model;

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<Stylist>));
        }
    }
}
