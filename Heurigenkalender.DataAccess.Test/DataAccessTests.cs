using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Heurigenkalender.DataAccess.Shared.DataAccessEntities;
using Heurigenkalender.DataAccessMySQL;
using Heurigenkalender.DataAccessMySQL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Hql;
using NHibernate.Linq;
using NHibernate.SqlCommand;
using NHibernate.Transform;

namespace Heurigenkalender.DataAccess.Test
{
    [TestClass]
    public class DataAccessTests
    {
        
        public void MySQLJoinTest()
        {
            var dbConnection = new DatabaseConnection();
            ISessionFactory sessionFactory = dbConnection.GetSessionFactory();

            IList<DaeHeurigen> returnList;
            using (var session = sessionFactory.OpenSession())
            {
                DaeHeurigen myHeurigen = null;

                var query = session.CreateCriteria<DaeHeurigen>("h")
                    .CreateCriteria("h.Ratings", "r", JoinType.InnerJoin)
                    .SetProjection(Projections.ProjectionList()

                        .Add(Projections.GroupProperty("h.Id").WithAlias(() => myHeurigen.Id))
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

                        .Add(Projections.Avg("r.RatingStars").WithAlias(() => myHeurigen.AverageRating))

                        .Add(Projections.Property("h.Logo").WithAlias(() => myHeurigen.Logo)))
                        .SetResultTransformer(Transformers.AliasToBean<DaeHeurigen>());

                returnList = query.List<DaeHeurigen>();

            }
            Assert.IsNotNull(returnList);
        }
        [TestMethod]
        public void SQLTest()
        {
            var dbConnection = new DatabaseConnection();
            ISessionFactory sessionFactory = dbConnection.GetSessionFactory();

            IList<DaeHeurigen> returnList;
            string name = "";
            int id = 2;
            int skip = 0;
            int limit = 20;

            using (var session = sessionFactory.OpenSession())
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
                catch (Exception)
                {
                    
                    throw;
                }
                

            }
            Assert.IsNotNull(returnList);
        }

        [TestMethod]
        public void SQLRatingTest()
        {
            var dbConnection = new DatabaseConnection();
            ISessionFactory sessionFactory = dbConnection.GetSessionFactory();

            IList<DaeRating> returnList;

            using (var session = sessionFactory.OpenSession())
            {
                var rquery = session.CreateCriteria<DaeRating>()
                    .Add(Restrictions.Eq("FkHeurigenId", 1));

                returnList = rquery.List<DaeRating>();
            }
            Assert.IsTrue(returnList.Any());
        }
    }
}