using MSSQLManagementObjects;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.SqlServer.Management.Common;

namespace MSSQLManagementObjects.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void CreateDBTest()
        {
            var x = new MSSQLManagementObjects().CreateDB(new ServerConnection("localhost", "sa3", "sa"), "TestC");
            if (x == false) Assert.Fail();
        }

        [TestMethod()]
        public void DeleteDBTest()
        {
            var x = new MSSQLManagementObjects().DeleteDB(new ServerConnection("localhost", "sa3", "sa"), "TestC");
            if (x == false) Assert.Fail();
        }

        [TestMethod()]
        public void CreateSQLUserTest()
        {
            var x = new MSSQLManagementObjects().CreateSQLUser(new ServerConnection("localhost", "sa3", "sa"), "bob8", "Password100@", "TestC");
            if (x == false) Assert.Fail();
        }
        [TestMethod()]
        public void AssignSQLUserTest()
        {
            var x = new MSSQLManagementObjects().AssignSQLUser(new ServerConnection("localhost", "sa3", "sa"), "bob8", "Password100@", "TestC");
            if (x == false) Assert.Fail();
        }

        [TestMethod()]
        public void AssignRoleTest()
        {
            var x = new MSSQLManagementObjects().AssignRole(new ServerConnection("localhost", "sa3", "sa"), "bob8", "db_owner", "TestC");
            Assert.Fail();
        }
    }
}

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
