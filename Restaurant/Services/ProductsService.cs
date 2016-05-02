using MODELS.Dto;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    public class ProductsService : BaseService
    {
        public ProductsService(TokenDto oToken)
        {
            tkn = oToken;
        }
        public List<ProductDto> getAllProducts()
        {
            var client = new RestClient(endpoint);

            var request = new RestRequest("api/products", Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", tkn.access_token));
            request.RequestFormat = RestSharp.DataFormat.Json;

            var list = client.Get<List<ProductDto>>(request).Data;

            return list;
        }
    }
}
