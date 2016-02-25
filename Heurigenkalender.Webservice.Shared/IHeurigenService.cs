using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Heurigenkalender.Webservice.Shared.DTOs;

namespace Heurigenkalender.Webservice.Shared
{
    [ServiceContract (Name = "HeurigenService")]
    internal interface IHeurigenService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/CreateHeurigen")]
        HeurigenResponse CreateHeurigen(Heurigen heurigen);

        [OperationContract (Name = "GetHeurigen")]
        [WebGet(UriTemplate = "/GetHeurigen?Id={Id}&Name={Name}&Skip={Skip}&Limit={Limit}", ResponseFormat = WebMessageFormat.Json)] 
        HeurigenResponse GetHeurigen(int id, string name, int skip, int limit);

        [OperationContract(Name = "GetHeurigenByLocation")]
        [WebGet(UriTemplate = "/GetHeurigenByLocation?Lat={latitude}&Long={longitude}&Radius={radius}&Skip={skip}&Limit={limit}",
            ResponseFormat = WebMessageFormat.Json)]
        HeurigenResponse GetHeurigenByLocation(double latitude, double longitude, int radius, int skip, int limit);
    }
    
}
