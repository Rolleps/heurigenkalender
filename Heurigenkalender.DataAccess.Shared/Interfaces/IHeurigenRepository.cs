using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Heurigenkalender.DataAccess.Shared.DataAccessEntities;
using Heurigenkalender.Webservice.Shared.DTOs;

namespace Heurigenkalender.DataAccess.Shared.Interfaces
{
    public interface IHeurigenRepository : IRepository<Heurigen>
    {
        List<DaeHeurigen> SelectAll(string name, int skip, int limit);
        DaeHeurigen SelectById(int id);
        List<DaeHeurigen> SelectByLocation(Location point, int radius, int skip, int limit);
    }
}
