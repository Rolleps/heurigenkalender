using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Heurigenkalender.Webservice.Shared.DTOs
{
    [DataContract(Name = "Location")]
    public class Location
    {
        [DataMember(Name = "Latitude")]
        private double Latitude { get; set; }
        [DataMember(Name = "Longitude")]
        private double Longitude { get; set; }
    }
}
