using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialtiesControllerTest
    {
        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            SpecialtiesController controller = new SpecialtiesController();
            ActionResult indexView = controller.Index();
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void All_ReturnsCorrectView_True()
        {
            SpecialtiesController controller = new SpecialtiesController();
            ActionResult indexView = controller.Add();
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Index_HasCorrectModelType_Results()
        {
            //Arrange
            SpecialtiesController controller = new SpecialtiesController();
            ViewResult costDataType = controller.Index() as ViewResult;

            //Act
            var result = costDataType.ViewData.Model;

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<Specialty>));
        }
    }
}
