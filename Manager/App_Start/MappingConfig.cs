using AutoMapper;
using DATA;
using Manager.CustomUserStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manager.App_Start
{
    public static class MappingConfig
    {
        public static void registerMaps()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<SoftTehnicaUser, user>();
                cfg.CreateMap<user, SoftTehnicaUser>();
            });
        }
    }
}