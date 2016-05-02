using MODELS.Dto;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    public class LocationsService : BaseService
    {
        public List<LocationDto> getAllLocations()
        {
            var client = new RestClient(endpoint);

            var request = new RestRequest("api/locations", Method.GET);
            request.RequestFormat = RestSharp.DataFormat.Json;

            var list = client.Get<List<LocationDto>>(request).Data;
            return list;
        }
    }
}
