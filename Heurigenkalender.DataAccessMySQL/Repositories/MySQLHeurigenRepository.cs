using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heurigenkalender.DataAccess.Shared;
using Heurigenkalender.DataAccess.Shared.DataAccessEntities;
using Heurigenkalender.DataAccess.Shared.Interfaces;
using Heurigenkalender.Webservice.Shared.DTOs;
using NHibernate;
using NHibernate.Linq;

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

        public Heurigen Create(Heurigen t)
        {
            throw new NotImplementedException();
        }

        public Heurigen Update(Heurigen t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Heurigen t)
        {
            throw new NotImplementedException();
        }

        public List<DaeHeurigen> SelectAll(string name, int skip, int limit)
        {
            List<DaeHeurigen> returnList;
            using (var session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        returnList = session.Query<DaeHeurigen>().ToList();
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        throw new DataAccessLayerException("MySQLRepo: Failed to Select all Heurigen", e);
                    }
                }
            }
                throw new NotImplementedException();
        }

        public DaeHeurigen SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public List<DaeHeurigen> SelectByLocation(Location point, int radius, int skip, int limit)
        {
            throw new NotImplementedException();
        }
    }
}
