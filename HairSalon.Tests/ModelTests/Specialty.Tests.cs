using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialtyTest : IDisposable
    {
        public void Dispose()
        {
            Stylist.DeleteAll();
        }

        public SpecialtyTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=kevin_ahn_test;";
        }

        [TestMethod]
        public void GetSetProperties_GetsSetsProperties_ReturnEqualValue()
        {
            Specialty newSpecialty = new Specialty("Fast");
            newSpecialty.Name = "Slow";

            Assert.AreEqual("Slow", newSpecialty.Name);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfObjectsAreTheSame_ReturnsEqualValue()
        {
            Specialty firstItem = new Specialty("Cool");
            Specialty secondItem = new Specialty("Cool");

            Assert.AreEqual(firstItem, secondItem);
        }

        [TestMethod]
        public void Save_SavesSpecialty_ReturnEqualValue()
        {
            Specialty newSpecialty = new Specialty("Nice", 34);
            newSpecialty.Save();
            List<Specialty> allSpecialties = Specialty.GetAll();
            List<Specialty> expectedList = new List<Specialty>() { newSpecialty };
            CollectionAssert.AreEqual(expectedList, allSpecialties);
        }

        [TestMethod]
        public void Find_FindsStylist_ReturnEqualValue()
        {
            Specialty newSpecialty = new Specialty("Nice");
            newSpecialty.Save();

            Specialty foundSpecialty = Specialty.Find(newSpecialty.Id);

            Assert.AreEqual(foundSpecialty, newSpecialty);
        }

        [TestMethod]
        public void GetAll_GetsEntries_True()
        {
            Specialty newSpecialtyCool = new Specialty("Cool", 4);
            newSpecialtyCool.Save();
            Specialty newSpecialtyNice = new Specialty("Nice", 3);
            newSpecialtyNice.Save();
            List<Specialty> ListOfSpecialties = new List<Specialty> { newSpecialtyCool, newSpecialtyNice };
            List<Specialty> newList = Specialty.GetAll();
            CollectionAssert.AreEqual(newList, ListOfSpecialties);
        }

        [TestMethod]
        public void DeleteAll_DeletesAllEntries_True()
        {
            Specialty newSpecialtyCool = new Specialty("Cool");
            newSpecialtyCool.Save();
            Specialty newSpecialtyNice = new Specialty("Nice");
            newSpecialtyNice.Save();
            Specialty.DeleteAll();
            List<Specialty> newList = Specialty.GetAll();
            Assert.AreEqual(newList.Count, 0);
        }

        [TestMethod]
        public void DeleteSingleSpecialty_DeletesAnEntry_True()
        {
            Specialty newSpecialtyCool = new Specialty("Cool");
            newSpecialtyCool.Save();
            Specialty newSpecialtyNice = new Specialty("Nice");
            newSpecialtyNice.Save();
            Specialty.DeleteSingleSpecialty(newSpecialtyCool.Id);
            List<Specialty> newList = Specialty.GetAll();
            Assert.AreEqual(newList.Count, 1);
        }
    }
}
