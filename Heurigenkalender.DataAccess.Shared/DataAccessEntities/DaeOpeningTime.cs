using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heurigenkalender.DataAccess.Shared.DataAccessEntities
{
    [Serializable]
    public class DaeOpeningTime
    {
        public int Id { get; set; } 

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
        
        public int FkHeurigenId { get; set; }
    }
}
