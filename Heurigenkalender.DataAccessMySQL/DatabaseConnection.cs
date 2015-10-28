using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace Heurigenkalender.DataAccessMySQL
{
    
    public class DatabaseConnection
    {
        private readonly ISessionFactory _sessionFactory;

        public DatabaseConnection()
        {
            var configuration = new Configuration();
            configuration.DataBaseIntegration(x => {
                x.ConnectionString = "Server=localhost; Database=heurigenkalender; " +
                                     "Persist Security Info=True; Uid=root; Password=;";
                x.Dialect<MySQLDialect>();
            });
            configuration.AddAssembly(Assembly.GetExecutingAssembly());
            _sessionFactory = configuration.BuildSessionFactory();
        }

        public ISessionFactory GetSessionFactory()
        {
            return _sessionFactory;
        }

    }
}
