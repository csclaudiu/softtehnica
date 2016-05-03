using MODELS.Dto;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    public class OrdersService : BaseService
    {
        public OrdersService(TokenDto oToken)
        {
            tkn = oToken;
        }

        public List<OrderHistoryDto> getAllOrders(LocationDto currentLocation)
        {
            var client = new RestClient(endpoint);

            //var request = new RestRequest("api/orders", Method.GET);
            //var request = new RestRequest("rpc/ordersHistory/showHistory", Method.GET);
            var request = new RestRequest(string.Format("rpc/ordersHistory/showHistoryLocation/{0}", currentLocation.id), Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", tkn.access_token));
            request.RequestFormat = DataFormat.Json;


            var list = client.Get<List<OrderHistoryDto>>(request);

            return list.Data;
        }

        public bool addOrder(ref OrderDto newOrder)
        {
            var client = new RestClient(endpoint);

            var request = new RestRequest("api/orders");
            request.AddHeader("Authorization", string.Format("Bearer {0}", tkn.access_token));
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddJsonBody(newOrder);

            var response = client.Post<OrderDto>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                newOrder = response.Data;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
