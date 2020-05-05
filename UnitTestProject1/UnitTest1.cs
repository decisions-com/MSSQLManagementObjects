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
            var x = new MSSQLManagementObjectsClass().CreateDB("localhost", "sa3", "sa", "TestC");
            if (x == false) Assert.Fail();
        }

        [TestMethod()]
        public void DeleteDBTest()
        {
            var x = new MSSQLManagementObjectsClass().DeleteDB("localhost", "sa3", "sa", "TestC");
            if (x == false) Assert.Fail();
        }

        [TestMethod()]
        public void CreateSQLUserTest()
        {
            var x = new MSSQLManagementObjectsClass().CreateSQLUser("localhost", "sa3", "sa", "bob8", "Password100@", "TestC");
            if (x == false) Assert.Fail();
        }
        [TestMethod()]
        public void AssignSQLUserTest()
        {
            var x = new MSSQLManagementObjectsClass().AssignSQLUser("localhost", "sa3", "sa", "bob8", "Password100@", "TestC");
            if (x == false) Assert.Fail();
        }

        [TestMethod()]
        public void AssignRoleTest()
        {
            var x = new MSSQLManagementObjectsClass().AssignRole("localhost", "sa3", "sa", "bob8", "db_owner", "TestC");
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
