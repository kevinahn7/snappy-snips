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
            Stylist newStylist = new Stylist("Bob", "funny guy");
            newStylist.Name = "Tim";

            Assert.AreEqual("Tim", newStylist.Name);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfObjectsAreTheSame_ReturnsEqualValue()
        {
            Stylist firstItem = new Stylist("Bob", "Cool");
            Stylist secondItem = new Stylist("Bob", "Cool");

            Assert.AreEqual(firstItem, secondItem);
        }

        [TestMethod]
        public void Find_FindsStylist_ReturnEqualValue()
        {
            Stylist newStylistJeff = new Stylist("Bob", "Cool", 4);
            newStylistJeff.Save();
            
            Stylist foundStylist = Stylist.Find(newStylistJeff.Id);

            
            Assert.AreEqual(foundStylist, newStylistJeff);
        }

    }
    

}
