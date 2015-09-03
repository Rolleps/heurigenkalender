using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heurigenkalender.DataAccess.Shared.DataAccessEntities
{
    [Serializable]
    public class DaeDay
    {
        public string Weekday { get; set; }

        public string TimeFrom { get; set; }

        public string TimeTo { get; set; }

        public int FkOpeningTime { get; set; }
    }
}
