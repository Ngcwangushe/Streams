using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Streams.Dtos;
using Streams.Models;

namespace Streams.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            //Mapp Objects
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}