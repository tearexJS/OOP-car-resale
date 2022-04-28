using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using BL.Models;
using CarResale.DAL.Entities;

namespace CarResale.BL.Models
{
    public record CarModelDetailModel(
        string ModelName,
        decimal Engine,
        decimal Power,
        int Seats,
        decimal TrunkSize
    ) : ModelBase
    {
        public string ModelName { get; set; } = ModelName;
        public decimal Engine { get; set; } = Engine;
        public decimal Power { get; set; } = Power;
        public int Seats { get; set; } = Seats;
        public decimal TrunkSize { get; set; } = TrunkSize;
        public CarTypeDetailModel Type { get; set; }
        public CarManufacturerDetailModel ManufacturerName { get; set; }

        public List<CarDetailModel> Cars { get; set; } = new();

        public class MapperProfile : Profile
        {
            public MapperProfile()
            {

                CreateMap<CarModelEntity, CarModelDetailModel>(MemberList.Destination)
                    .ForMember(dest => dest.Type, opt => opt.Ignore())
                    .ForMember(dest => dest.ManufacturerName, opt => opt.Ignore())
                    .ReverseMap()
                    .ForMember(entity => entity.Type, exp => exp.Ignore())
                    .ForMember(entity => entity.ManufacturerName, exp => exp.Ignore());
                //CreateMap<CarTypeDetailModel, CarModelDetailModel>(MemberList.Source).DisableCtorValidation();
                // CreateMap<CarManufacturerDetailModel, CarModelDetailModel>(MemberList.Source).DisableCtorValidation();

            }
        }
    }
}
