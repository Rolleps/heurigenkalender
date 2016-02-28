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
        [TestMethod]
        public void MySQLJoinTest()
        {
            var dbConnection = new DatabaseConnection();
            ISessionFactory sessionFactory = dbConnection.GetSessionFactory();

            IList<DaeHeurigen> returnList;
            DaeRating rating;
            using (var session = sessionFactory.OpenSession())
            {
                DaeHeurigen myHeurigen = null;
                DaeRating myRating = null;

                var query = session.QueryOver<DaeHeurigen>(() => myHeurigen)
                    .JoinAlias(x => x.Ratings, () => myRating)
                    .TransformUsing(Transformers.AliasToBean<DaeHeurigen>());

                query
                    .SelectList(list => list
                        .SelectGroup(() => myHeurigen.Id).WithAlias(() => myHeurigen.Id)
                        .SelectAvg(() => myRating.RatingStars).WithAlias(() => myHeurigen.AverageRating))
                    .Take(20)
                    .Skip(0);



                returnList = session.QueryOver<DaeHeurigen>()
                    .WithSubquery.WhereProperty(x => x.Id).Eq(query.)
                    .List<DaeHeurigen>();

            }
            Assert.IsNotNull(returnList);
        }
    }
}
