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
            IList<DaeHeurigen> returnList;
            using (var session = _sessionFactory.OpenSession())
            {

                DaeHeurigen myHeurigen = null;

                try
                {
                    var query = session.CreateCriteria<DaeHeurigen>("h")
                    .CreateCriteria("h.Ratings", "r", JoinType.LeftOuterJoin)
                    .SetProjection(Projections.ProjectionList()

                        .Add(Projections.Property("h.Name").WithAlias(() => myHeurigen.Name))
                        .Add(Projections.Property("h.Postcode").WithAlias(() => myHeurigen.Postcode))
                        .Add(Projections.Property("h.City").WithAlias(() => myHeurigen.City))
                        .Add(Projections.Property("h.Street").WithAlias(() => myHeurigen.Street))
                        .Add(Projections.Property("h.Telephone").WithAlias(() => myHeurigen.Telephone))
                        .Add(Projections.Property("h.Mail").WithAlias(() => myHeurigen.Mail))
                        .Add(Projections.Property("h.HomepageUrl").WithAlias(() => myHeurigen.HomepageUrl))
                        .Add(Projections.Property("h.Description").WithAlias(() => myHeurigen.Description))
                        .Add(Projections.Property("h.Latitude").WithAlias(() => myHeurigen.Latitude))
                        .Add(Projections.Property("h.Longitude").WithAlias(() => myHeurigen.Longitude))
                        .Add(Projections.Property("h.WarmFood").WithAlias(() => myHeurigen.WarmFood))
                        .Add(Projections.Property("h.Logo").WithAlias(() => myHeurigen.Logo))
                        .Add(Projections.Avg("r.RatingStars").WithAlias(() => myHeurigen.AverageRating))
                        .Add(Projections.GroupProperty("h.Id").WithAlias(() => myHeurigen.Id)))

                        .SetResultTransformer(Transformers.AliasToBean<DaeHeurigen>());


                    if (!string.IsNullOrEmpty(name))
                    {
                        query.Add(Restrictions.Like("h.Name", name, MatchMode.Anywhere));
                    }
                    if (id != 0)
                    {
                        query.Add(Restrictions.Eq("h.Id", id));
                    }

                    query.SetFirstResult(skip);
                    query.SetMaxResults(limit);

                    returnList = query.List<DaeHeurigen>();

                }
                catch (Exception e)
                {
                    throw new DataAccessLayerException("MySQLRepo: Failed to Select all Heurigen", e);
                }
                
            }
            return (List<DaeHeurigen>) returnList;
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
