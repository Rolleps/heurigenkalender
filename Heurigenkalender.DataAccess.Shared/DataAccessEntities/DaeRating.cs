using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heurigenkalender.DataAccess.Shared.DataAccessEntities
{
    [Serializable]
    public class DaeRating
    {
        public int Id { get; set; }

        public string RatingText { get; set; }

        public int RatingStars { get; set; }

        public int FkHeurigenId { get; set; }
    }
}
