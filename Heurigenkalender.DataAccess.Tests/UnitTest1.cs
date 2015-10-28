using System;
using System.Security.Cryptography.X509Certificates;
using Heurigenkalender.DataAccessMySQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Heurigenkalender.DataAccess.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDBConnection_MySQLLocalhost()
        {
            var dbConnection = new DatabaseConnection();
            var sessionFactory = dbConnection.GetSessionFactory();
            Assert.IsNotNull(sessionFactory);
        }
    }
}
