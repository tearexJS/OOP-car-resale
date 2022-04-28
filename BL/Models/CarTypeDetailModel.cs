using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarResale.BL.Models;
using CarResale.DAL.Entities;

namespace BL.Models
{
    public record CarTypeDetailModel(
        string Type
    ) : ModelBase
    {
        public string Type { get; set; } = Type;
    }


    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<CarTypeEntity, CarTypeDetailModel>()
                .ReverseMap();
        }
    }
}

