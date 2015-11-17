using GeoAPI.Geometries;
using Heurigenkalender.DataAccess.Shared.DataAccessEntities;
using Heurigenkalender.DataAccessMySQL;
using Heurigenkalender.DataAccessMySQL.Repositories;
using Heurigenkalender.Webservice.Shared.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTopologySuite.Geometries;
using Location = Heurigenkalender.Webservice.Shared.DTOs.Location;

namespace Heurigenkalender.DataAccess.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDBConnection_MySQLLocalhost()
        {
            var dbconn = new DatabaseConnection();
            var factory = dbconn.GetSessionFactory();
            Assert.IsNotNull(factory);
        }

        [TestMethod]
        public void SelectAllMYSQL_TEST()
        {
            var repo = new MySQLHeurigenRepository();
            var dbresponse = repo.SelectAll("", 0);
            Assert.IsNotNull(dbresponse);
        }


        [TestMethod]
        public void CreateHeurigenMYSQL_TEST()
        {
            var repo = new MySQLHeurigenRepository();
            var heurigentestobject = new DaeHeurigen();
            heurigentestobject.Name = "hollabrunnerkebapheurigen";
            heurigentestobject.Postcode = "2020";
            heurigentestobject.City = "Hollabrunn";
            heurigentestobject.Street = "Marichtalerweg 9";
            heurigentestobject.Telephone = "02952465498";
            heurigentestobject.Description = "testbeschreibung";
            heurigentestobject.Latitude = 48.563000;
            heurigentestobject.Longitude = 16.079113;


            //heurigentestobject.Location = point;
            var dbresponse = repo.Create(heurigentestobject);
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
    }


}


