using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistTest : IDisposable
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
        public void Save_SavesStylist_ReturnEqualValue()
        {
            Stylist newStylistBob = new Stylist("Bob", "Nice");
            newStylistBob.Save();
            List<Stylist> allStylists = Stylist.GetAll();
            List<Stylist> expectedList = new List<Stylist>() { newStylistBob };
            CollectionAssert.AreEqual(expectedList, allStylists);
        }

        [TestMethod]
        public void Find_FindsStylist_ReturnEqualValue()
        {
            Stylist newStylistJeff = new Stylist("Bob", "Cool", 4);
            newStylistJeff.Save();

            Stylist foundStylist = Stylist.Find(newStylistJeff.Id);

            Assert.AreEqual(foundStylist, newStylistJeff);
        }

        [TestMethod]
        public void GetAll_GetsEntries_True()
        {
            Stylist newStylistJeff = new Stylist("Jeff", "Cool", 4);
            newStylistJeff.Save();
            Stylist newStylistBob = new Stylist("Bob", "Nice", 3);
            newStylistBob.Save();
            List<Stylist> listOfStylists = new List<Stylist> { newStylistJeff, newStylistBob };
            List<Stylist> newList = Stylist.GetAll();
            CollectionAssert.AreEqual(newList, listOfStylists);
        }

        [TestMethod]
        public void DeleteAll_DeletesAllEntries_True()
        {
            Stylist newStylistJeff = new Stylist("Jeff", "Cool", 4);
            newStylistJeff.Save();
            Stylist newStylistBob = new Stylist("Bob", "Nice", 3);
            newStylistBob.Save();
            Stylist.DeleteAll();
            List<Stylist> newList = Stylist.GetAll();
            Assert.AreEqual(newList.Count, 0);
        }

        [TestMethod]
        public void DeleteSingleStylist_DeletesAnEntry_True()
        {
            Stylist newStylistJeff = new Stylist("Jeff", "Cool", 4);
            newStylistJeff.Save();
            Stylist newStylistBob = new Stylist("Bob", "Nice", 3);
            newStylistBob.Save();
            Stylist.DeleteSingleStylist(newStylistBob.Id);
            List<Stylist> newList = Stylist.GetAll();
            Assert.AreEqual(newList.Count, 1);
        }


        [TestMethod]
        public void GetClients_GetsClients_True()
        {
            Client newClientJeff = new Client("Jeff", 4);
            newClientJeff.Save();
            Client newClientBob = new Client("Bob", 3);
            newClientBob.Save();
            Stylist newStylistKevin = new Stylist("Kevin", "Cool");
            newStylistKevin.Save();
            List<Client> newList = newStylistKevin.GetClients();
            List<Client> anotherList = new List<Client> { newClientJeff, newClientBob };
            
            CollectionAssert.AreEqual(newList, anotherList);
        }

    }
}
