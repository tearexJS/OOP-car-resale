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
        public CarModelListModel CarModel { get; set; }

        public class MapperProfile : Profile
        {
            public MapperProfile()
            {
                //FIX: IncludeMembers(), CarModel
                CreateMap<CarEntity, CarDetailModel>()
                    .ReverseMap()
                    .ForMember(entity => entity.CarModel, opt => opt.Ignore());
            }
        }

    }

}
