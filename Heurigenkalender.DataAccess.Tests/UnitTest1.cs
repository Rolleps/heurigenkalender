using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Heurigenkalender.DataAccess.Shared.DataAccessEntities;
using Heurigenkalender.DataAccessMySQL;
using Heurigenkalender.DataAccessMySQL.Repositories;
using Heurigenkalender.Webservice.Shared.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTopologySuite.Geometries;
using NHibernate.Util;
using Remotion.Linq;

namespace Heurigenkalender.DataAccess.Tests
{
    [TestClass]
    public class UnitTest1
    {
        /*
        [TestMethod]
        public void TestDBConnection_MySQLLocalhost()
        {
            var dbconn = new DatabaseConnection();
            var factory = dbconn.GetSessionFactory();
            Assert.IsNotNull(factory);
        }

        [TestMethod]
        public void SelectAll()
        {
            var repo = new MySQLHeurigenRepository();
            var dbresponse = repo.Select();
            Assert.IsNotNull(dbresponse);
        }

        [TestMethod]
        public void SelectByName()
        {
            var repo = new MySQLHeurigenRepository();
            var dbresponse = repo.Select("David Heurigen");
            Assert.IsNotNull(dbresponse);
        }

        [TestMethod]
        public void SelectById()
        {
            var repo = new MySQLHeurigenRepository();
            var dbresponse = repo.Select("", 2);
            Assert.IsNotNull(dbresponse);
        }

        [TestMethod]
        public void CreateHeurigenMYSQL_TEST()
        {
            var repo = new MySQLHeurigenRepository();
            var heurigentestobject = new DaeHeurigen();
            heurigentestobject.Name = "David Heurigen";
            heurigentestobject.Postcode = "2020";
            heurigentestobject.City = "Hollabrunn";
            heurigentestobject.Street = "Marichtalerweg 9";
            heurigentestobject.Telephone = "02952465498";
            heurigentestobject.Description = "testbeschreibung";
            heurigentestobject.Latitude = 48.563000;
            heurigentestobject.Longitude = 16.079113;


            //heurigentestobject.Location = point;
            repo.Create(heurigentestobject);
            Assert.AreEqual(dbresponse, -1);
        }


        [TestMethod]
        public void GeoSelectMYSQL_TEST()
        {
            var repo = new MySQLHeurigenRepository();
            var point = new Location();
            point.Latitude = 48.563000;
            point.Longitude = 16.079113;
            var test = repo.SelectByLocation(point, 50, 0, 10);
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void UpdateOnlyChangedPropertiesInObject()
        {
            var heurigen = new DaeHeurigen();
            heurigen.Name = "test";
            heurigen.Id = 22;
            heurigen.Latitude = 0.4324;
            var test = new DaeHeurigen();
            test.Name = "eggad";
            test.Id = 1;
            test.Latitude = 0.5;

            foreach (var prop in heurigen.GetType().GetProperties()
                .Where(x => !x.GetIndexParameters().Any())
                .Where(x => x.CanRead && x.CanWrite))
            {
                var value = prop.GetValue(heurigen, null);
                prop.SetValue(test, value, null);
            }

            Assert.AreEqual(heurigen.Name, test.Name);

        }

        [TestMethod]
        public void UpdateHeurigen()
        {
            var updatedHeurigen = new DaeHeurigen();
            updatedHeurigen.Id = 1;
            updatedHeurigen.Name = "David Heurigen";
            updatedHeurigen.Postcode = "2020";
            updatedHeurigen.City = "Raschala";
            updatedHeurigen.Street = "Hadmargasse 10";
            updatedHeurigen.Telephone = "0664123456789";
            updatedHeurigen.Mail = "david@heurigen.at";

            var repo = new MySQLHeurigenRepository();
            repo.Update(updatedHeurigen);

            var returnHeurigen = repo.Select("", (int) updatedHeurigen.Id);

            Assert.AreEqual(updatedHeurigen.Telephone, returnHeurigen.First().Telephone);
        }

        
    */

    }
}


