using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistTest: IDisposable
    {
        public void Dispose()
        {
            Stylist.DeleteAll();
        }

        public StylistTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=kevin_ahn_test;";
        }

        [TestMethod]
        public void GetSetProperties_GetsSetsProperties_ReturnEqualValue()
        {
            Stylist newStylist = new Stylist("Bob", "funny guy", 3);
            newStylist.Name = "Tim";

            Assert.AreEqual("Tim", newStylist.Name);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfObjectsAreTheSame_ReturnsEqualValue()
        {
            Stylist firstItem = new Stylist("Bob", "Cool", 4);
            Stylist secondItem = new Stylist("Bob", "Cool", 4);

            Assert.AreEqual(firstItem, secondItem);
        }

        [TestMethod]
        public void Find_FindsStylist_ReturnEqualValue()
        {
            Stylist newStylistJeff = new Stylist("Bob", "Cool", 4, 1);
            Stylist newStylistTom = new Stylist("Tom", "Funny", 3, 2);
            List<Stylist> newList = Stylist.GetAll();
            Stylist foundStylist = Stylist.Find(1);
            Stylist actualStylist = newList[1];
            Assert.AreEqual(foundStylist, actualStylist);
        }

    }

}
