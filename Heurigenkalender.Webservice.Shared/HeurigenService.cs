using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Heurigenkalender.DataAccess.Shared.DataAccessEntities;
using Heurigenkalender.DataAccessMySQL.Repositories;
using Heurigenkalender.Webservice.Shared.DTOs;

namespace Heurigenkalender.Webservice.Shared
{
    public class HeurigenService : IHeurigenService
    {
        public HeurigenService()
        {
            AutoMapper.Mapper.CreateMap<DaeHeurigen, Heurigen>();
        }

        public HeurigenResponse CreateHeurigen(Heurigen heurigen)
        {
            var response = new HeurigenResponse();
            if (heurigen.Id == null || heurigen.Name == null || heurigen.Postcode == null || heurigen.City == null || 
                heurigen.Street == null || heurigen.Description == null || heurigen.Location == null)
            {
                response.Success = false;
                return response;

            }
            if (heurigen.Location != null && (heurigen.Location.Latitude == null || heurigen.Location.Longitude == null))
            {
                response.Success = false;
                return response;

            }

            //TODO: Create Heurigen with repo
            return response;

        }

        public HeurigenResponse GetHeurigen(int id, string name, int skip, int limit)
        {
            if (limit == 0)
            {
                limit = 20;
            }
            var repo = new MySQLHeurigenRepository();
            var returnList = repo.Select(name, id, skip, limit);

            var mappedList = AutoMapper.Mapper.Map<List<DaeHeurigen>, List<Heurigen>>(returnList);

            var response = new HeurigenResponse();
            response.Data = mappedList;

            return response;
        }

        public HeurigenResponse GetHeurigenByLocation(double latitude, double longitude, int radius, int skip, int limit)
        {
            if (limit == 0)
            {
                limit = 20;
            }

            if (radius == 0)
            {
                radius = 50;
            }

            var response = new HeurigenResponse();
            var point = new Location();

            if (latitude != 0 && longitude != 0) //TODO: Check for null not 0 --> Querystringconverter unterstützt keine nullable doubles
            {
                point.Latitude = latitude;
                point.Longitude = longitude;
            }
            else
            {
                response.Success = false;
                return response;
            }

            var repo = new MySQLHeurigenRepository();
            var returnList = repo.SelectByLocation(point, radius, skip, limit);

            var mappedList = AutoMapper.Mapper.Map<List<DaeHeurigen>, List<Heurigen>>(returnList);

            
            response.Data = mappedList;

            return response;
        }
    }
}
