using AutoMapper;
using HarshTestUserApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarshTestUserApp
{
    public static class AutoMapperConfig
    {
        public static void ConfigureMapping()
        {
            Mapper.CreateMap<UserViewModel, tblUser>().ReverseMap();
        }
    }
}