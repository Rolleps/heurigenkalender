using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Heurigenkalender.Webservice.Shared.DTOs
{
    public interface IResponse<T>
    {
        bool Success { get; set; }
        List<T> Data { get; set; }
    }
}
