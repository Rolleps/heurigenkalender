using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heurigenkalender.Webservice.Shared.DTOs;

namespace Heurigenkalender.DataAccess.Shared.DataAccessEntities
{
    [Serializable]
    public class DaeHeurigen
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Postcode { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Telephone { get; set; }

        public string Mail { get; set; }

        public string HomepageUrl { get; set; }

        public string Description { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        //public GeoAPI.Geometries.IGeometry Location { get; set; }

        public double Distance { get; set; }

        public bool? WarmFood { get; set; }

        public byte[] Logo { get; set; }

        public double AverageRating { get; set; }
    }
}
