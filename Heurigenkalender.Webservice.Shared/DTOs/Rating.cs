using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Heurigenkalender.Webservice.Shared.DTOs
{
    [DataContract(Name = "Rating")]
    public class Rating
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }
        [DataMember(Name = "RatingText")]
        public string RatingText { get; set; }
        [DataMember(Name = "RatingStars")]
        public int RatingStars{ get; set; }

    }
}
