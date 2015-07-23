using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Heurigenkalender.Webservice.Shared.DTOs
{
    [DataContract(Name = "OpeningTime")]
    public class OpeningTime
    {
        [DataMember(Name = "From")]
        public DateTime From { get; set; }
        [DataMember(Name = "To")]
        public DateTime To { get; set; }
    }
}
