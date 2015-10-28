using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Heurigenkalender.Webservice.Shared.DTOs
{
    [DataContract(Name = "Day")]
    public class Day
    {
        [DataMember(Name = "Weekday")]
        public Weekdays Weekday { get; set; }
        [DataMember(Name = "FromTime")]
        public string TimeFrom { get; set; }
        [DataMember(Name = "TimeTo")]
        public string TimeTo { get; set; }
    }

    [DataContract(Name = "Weekdays")]
    public enum Weekdays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
}
