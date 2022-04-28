using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarResale.DAL.Entities;

namespace CarResale.BL.Models
{
    public record CarDetailModel(
        decimal Mileage,
        int YearOfManufacture
    ) : ModelBase
    {
        public decimal Mileage { get; set; } = Mileage;
        public int YearOfManufacture { get; set; } = YearOfManufacture;

        public class MapperProfile : Profile
        {
            public MapperProfile()
            {

                CreateMap<CarEntity, CarDetailModel>()
                    .ReverseMap();
            }
        }

    }

}
