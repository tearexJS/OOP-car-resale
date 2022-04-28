using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL.Models;
using CarResale.BL.Models;
using CarResale.DAL.Entities;

namespace CarResale.BL.Models
{
    public record CarManufacturerDetailModel(
        string ManufacturerName
    ) : ModelBase

    {
        public string ManufacturerName { get; set; } = ManufacturerName;

        public class MapperProfile : Profile
        {
            public MapperProfile()
            {

                CreateMap<CarManufacturerEntity, CarManufacturerDetailModel>()
                    .ReverseMap();
            }
        }
    }

}
