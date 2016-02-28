using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using NHibernate.SqlCommand;
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

        public void Create(DaeHeurigen heurigen)
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
        }

        public void Update(DaeHeurigen heurigen)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    DaeHeurigen heurigenToUpdate;

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

                    try
                    {
                        foreach (var prop in heurigen.GetType().GetProperties()
                            .Where(x => !x.GetIndexParameters().Any())
                            .Where(x => x.CanRead && x.CanWrite))
                        {
                            var value = prop.GetValue(heurigen, null);
                            prop.SetValue(heurigenToUpdate, value, null);
                        }
                    }
                    catch (Exception e)
                    {
                        //log fehlt
                        throw new DataAccessLayerException("Failed during Updating Objects for DB Update", e);
                    }
                    


                    try
                    {
                        session.Merge(heurigenToUpdate);
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        //_log.Error("MySQLRepo: Failed to Update Heurigen");
                        throw new DataAccessLayerException("Failed to Update Heurigen in Database", e);
                    }
                }
            }
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
                        throw new DataAccessLayerException("Failed to Delete Heurigen in Database", e);
                    }
                }
            }
        }

        public List<DaeHeurigen> Select(string name, int id, int skip, int limit)
        {
            List<DaeHeurigen> returnList;
            using (var session = _sessionFactory.OpenSession())
            {
                try
                {
                    var criteria = session.CreateCriteria<DaeHeurigen>("heurigen");
                    if (!string.IsNullOrEmpty(name))
                    {
                        criteria.Add(Restrictions.Like("Name", name, MatchMode.Anywhere));
                    }
                    if (id != 0)
                    {
                        criteria.Add(Restrictions.Eq("Id", id));
                    }


                    criteria.SetFirstResult(skip);
                    criteria.SetMaxResults(limit);

                    returnList = (List<DaeHeurigen>) criteria.List<DaeHeurigen>();
                    
                }
                catch (Exception e)
                {
                    throw new DataAccessLayerException("MySQLRepo: Failed to Select all Heurigen", e);
                }
                
            }
            return returnList;
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
