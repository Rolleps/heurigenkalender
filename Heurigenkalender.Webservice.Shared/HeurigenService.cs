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
        public string CreateHeurigen(Heurigen heurigen)
        {
            return "id: " + heurigen.Id + " name: " + heurigen.Name;
        }

        public string GetHeurigen(string id)
        {
            return "got id " + id;
        }
    }
}
