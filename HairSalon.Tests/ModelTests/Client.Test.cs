using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientTest : IDisposable
    {
        public void Dispose()
        {
            Client.DeleteAll();
        }

        public ClientTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=kevin_ahn_test;";
        }

        [TestMethod]
        public void GetSetProperties_GetsSetsProperties_ReturnEqualValue()
        {
            Client newClient = new Client("Bob", 2);
            newClient.Name = "Tim";

            Assert.AreEqual("Tim", newClient.Name);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfObjectsAreTheSame_ReturnsEqualValue()
        {
            Client firstItem = new Client("Bob", 1);
            Client secondItem = new Client("Bob", 1);

            Assert.AreEqual(firstItem, secondItem);
        }

        [TestMethod]
        public void Save_SavesStylist_ReturnEqualValue()
        {
            Client newClientBob = new Client("Bob", 3);
            newClientBob.Save();
            List<Client> allClients = Client.GetAll();
            List<Client> expectedList = new List<Client>() { newClientBob };
            CollectionAssert.AreEqual(expectedList, allClients);
        }

        [TestMethod]
        public void Find_FindsStylist_ReturnEqualValue()
        {
            Client newClientBob = new Client("Bob", 4);
            newClientBob.Save();

            Client foundClient = Client.Find(newClientBob.Id);

            Assert.AreEqual(foundClient, newClientBob);
        }

        [TestMethod]
        public void GetAll_GetsEntries_True()
        {
            Client newClientJeff = new Client("Jeff", 4);
            newClientJeff.Save();
            Client newClientBob = new Client("Bob", 3);
            newClientBob.Save();
            List<Client> listOfStylists = new List<Client> { newClientJeff, newClientBob };
            List<Client> newList = Client.GetAll();
            CollectionAssert.AreEqual(newList, listOfStylists);
        }

        [TestMethod]
        public void DeleteAll_DeletesAllEntries_True()
        {
            Client newClientJeff = new Client("Jeff", 4);
            newClientJeff.Save();
            Client newClientBob = new Client("Bob", 3);
            newClientBob.Save();
            Client.DeleteAll();
            List<Client> newList = Client.GetAll();
            Assert.AreEqual(newList.Count, 0);
        }
    }
}
