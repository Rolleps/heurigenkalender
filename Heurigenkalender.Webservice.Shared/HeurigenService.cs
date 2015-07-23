using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heurigenkalender.Webservice.Shared.DTOs;

namespace Heurigenkalender.Webservice.Shared
{
    public class HeurigenService : IHeurigenService
    {
        public void CreateHeurigen(Heurigen heurigen)
        {
            throw new NotImplementedException();
        }

        public string GetHeurigen(string id)
        {
            return "got id" + id;
        }
    }
}
