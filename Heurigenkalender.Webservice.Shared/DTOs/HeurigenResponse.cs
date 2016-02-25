using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Heurigenkalender.Webservice.Shared.DTOs
{
    [DataContract(Name = "HeurigenResponse")]
    public class HeurigenResponse:IResponse<Heurigen>
    {
        [DataMember (Name = "Success")]
        public bool Success { get; set; }
        [DataMember(Name = "Data")]
        public List<Heurigen> Data { get; set; }

        public HeurigenResponse()
        {
            this.Success = true;
        }
    }
}
