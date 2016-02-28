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
            configuration.DataBaseIntegration(x =>
            {
                //TODO: root password, Port 4040 only for NEOR PROFILE SQL
                x.ConnectionString = "Server=localhost; Port=4040; Database=heurigenkalender; " +
                                     "Persist Security Info=True; User ID=root; Password=";
                x.Driver<MySqlDataDriver>();
                x.Dialect<MySQL5Dialect>();
                x.LogFormattedSql = false;
                x.LogSqlInConsole = false;
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
