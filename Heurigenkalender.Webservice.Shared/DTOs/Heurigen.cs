using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Heurigenkalender.Webservice.Shared.DTOs
{
    [DataContract(Name = "Heurigen")]
    public class Heurigen
    {
        [DataMember(Name = "Id")]
        public int? Id { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Postcode")]
        public string Postcode { get; set; }

        [DataMember(Name = "City")]
        public string City { get; set; }

        [DataMember(Name = "Street")]
        public string Street { get; set; }

        [DataMember(Name = "Telephone")]
        public string Telephone { get; set; }

        [DataMember(Name = "Mail")]
        public string Mail { get; set; }

        [DataMember(Name = "HomepageUrl")]
        public string HomepageUrl { get; set; }

        [DataMember(Name = "Description")]
        public string Description { get; set; }

        [DataMember(Name = "Location")]
        public Location Location { get; set; }

        [DataMember(Name = "WarmFood")]
        public bool WarmFood { get; set; }

        [DataMember(Name = "Logo")]
        public byte[] Logo { get; set; }

        [DataMember(Name = "AverageRating")]
        public double AverageRating { get; set; }

        [DataMember(Name = "Ratings")]
        public List<Rating> Ratings { get; set; }

        [DataMember(Name = "OpeningTimes")]
        public List<OpeningTime> OpeningTimes { get; set; }

        [DataMember(Name = "Distance")]
        public double? Distance { get; set; }

        public Heurigen()
        {
            this.Ratings = new List<Rating>();
            this.OpeningTimes = new List<OpeningTime>();
        }
    }

}
