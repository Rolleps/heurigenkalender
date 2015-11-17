using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Heurigenkalender.DataAccess.Shared;
using Heurigenkalender.DataAccess.Shared.DataAccessEntities;
using Heurigenkalender.DataAccess.Shared.Interfaces;
using Heurigenkalender.Webservice.Shared.DTOs;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using NHibernate.Transform;

namespace Heurigenkalender.DataAccessMySQL.Repositories
{
    public class MySQLHeurigenRepository : IHeurigenRepository
    {
        private readonly ISessionFactory _sessionFactory;

        public MySQLHeurigenRepository()
        {
            var dbConnection = new DatabaseConnection();
            _sessionFactory = dbConnection.GetSessionFactory();
        }

        public int Create(DaeHeurigen heurigen)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(heurigen);
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        throw new DataAccessLayerException("Failed to Create Heurigen in Database", e);
                    }
                }
            }
            return -1;
        }

        public DaeHeurigen Update(DaeHeurigen heurigen)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var heurigenToUpdate = new DaeHeurigen();
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        heurigenToUpdate = session.Query<DaeHeurigen>()
                            .Where(x => x.Id == heurigen.Id)
                            .Select(x => x).Single();
                    }
                    catch (Exception e)
                    {
                        //_log.Error("MySQLRepo: Failed to Select Heurigen at Update");
                        throw new DataAccessLayerException("Failed to Select Heurigen at Update", e);
                    }

                    heurigenToUpdate = heurigen;

                    try
                    {
                        session.Merge(heurigenToUpdate);
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        //_log.Error("MySQLRepo: Failed to Update Heurigen");
                        throw new DataAccessLayerException("Failed to Update MainWarehouse in Database", e);
                    }
                }
            }
            return heurigen;
        }

        public void Delete(DaeHeurigen heurigen)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(heurigen);
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        //_log.Error("MySQLRepo: Failed to Delete Heurigen in Database");
                        throw new DataAccessLayerException("Failed to Delete MainWarehouse in Database", e);
                    }
                }
            }
        }

        public List<DaeHeurigen> SelectAll(string name = "", int skip = 0, int limit = 20)
        {
            List<DaeHeurigen> returnList;
            using (var session = _sessionFactory.OpenSession())
            {
                try
                {
                    returnList = (List<DaeHeurigen>)session.CreateCriteria<DaeHeurigen>()
                        .SetProjection(Projections.ProjectionList()
                            .Add(Projections.Property("Id"), "Id")
                            .Add(Projections.Property("Name"), "Name")
                            .Add(Projections.Property("Postcode"), "Postcode")
                            .Add(Projections.Property("City"), "City")
                            .Add(Projections.Property("Street"), "Street")
                            .Add(Projections.Property("Telephone"), "Telephone")
                            .Add(Projections.Property("Mail"), "Mail")
                            .Add(Projections.Property("HomepageUrl"), "HomepageUrl")
                            .Add(Projections.Property("Description"), "Description")
                            .Add(Projections.Property("Latitude"), "Latitude")
                            .Add(Projections.Property("Longitude"), "Longitude")
                            .Add(Projections.Property("WarmFood"), "WarmFood")
                            //.Add(Projections.Property("Name"), "Name") --> @TODO JOIN mit Ratings
                            .Add(Projections.Property("Logo"), "Logo"))
                        .SetFirstResult(skip)
                        .SetMaxResults(limit)
                        .SetResultTransformer(Transformers.AliasToBean<DaeHeurigen>())
                    .List<DaeHeurigen>();
                }
                catch (Exception e)
                {
                    throw new DataAccessLayerException("MySQLRepo: Failed to Select Heurigen", e);
                }
                

                /*
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        returnList = session.Query<DaeHeurigen>()
                            .ToList();
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        throw new DataAccessLayerException("MySQLRepo: Failed to Select all Heurigen", e);
                    }
                }
                */
            }
            return returnList;
        }

        public DaeHeurigen SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public List<DaeHeurigen> SelectByLocation(Location point, int radius, int skip, int limit)
        {
            List<DaeHeurigen> returnList;
            using (var session = _sessionFactory.OpenSession())
            {
                IQuery query = session.GetNamedQuery("proc_geoselect");
                query.SetParameter("Latitude_", point.Latitude);
                query.SetParameter("Longitude_", point.Longitude);
                query.SetParameter("Radius_", radius);
                query.SetParameter("Skip_", skip);
                query.SetParameter("Limit_", limit);
                returnList = (List<DaeHeurigen>)query.List<DaeHeurigen>();
            }
            return returnList;
        }
    }
}
