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

    }
}
