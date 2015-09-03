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
        [DataMember(Name = "DateFrom")]
        public DateTime DateFrom { get; set; }
        [DataMember(Name = "DateTo")]
        public DateTime DateTo { get; set; }

        [DataMember(Name = "Days")]
        public List<Day> Days { get; set; }

        public OpeningTime()
        {
            this.Days = new List<Day>();
        }
    }
}
