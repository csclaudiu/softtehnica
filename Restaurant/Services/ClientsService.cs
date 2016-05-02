using MODELS.Dto;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    public class ClientsService : BaseService
    {
        
        public ClientsService(TokenDto oToken)
        {
            tkn = oToken;
        }
        public List<ClientDto> getAllClients()
        {
            var client = new RestClient(endpoint);

            var request = new RestRequest("api/clients", Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", tkn.access_token));
            request.RequestFormat = RestSharp.DataFormat.Json;

            var list = client.Get<List<ClientDto>>(request).Data;

            return list;
        }

        public bool addClient(ref ClientDto newClient)
        {
            var client = new RestClient(endpoint);

            var request = new RestRequest("api/clients");
            request.AddHeader("Authorization", string.Format("Bearer {0}", tkn.access_token));
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddJsonBody(newClient);

            var response = client.Post<ClientDto>(request);
            if(response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                newClient = response.Data;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
