using DATA;
using MODELS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.App_Start
{
    public static class MappingConfig
    {
        public static void registerMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<ClientDto, client> ();
                config.CreateMap<LocationDto, location>();
                config.CreateMap<OrderDto, order>();
                config.CreateMap<ProductDto, product>();

                //reverse
                config.CreateMap<client, ClientDto>();
                config.CreateMap<location,LocationDto>();
                config.CreateMap<order, OrderDto>();
                config.CreateMap<product, ProductDto>();
            });
        }
    }
}