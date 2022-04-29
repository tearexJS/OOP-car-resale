using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
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
        public CarManufacturerDetailModel Manufacturer { get; set; }

        public List<CarDetailModel> Cars { get; set; } = new();

        public class MapperProfile : Profile
        {
            public MapperProfile()
            {

                CreateMap<CarModelEntity, CarModelDetailModel>(MemberList.Destination)
                    .ReverseMap()
                    .ForMember(entity => entity.Type, exp => exp.Ignore())
                    .ForMember(entity => entity.Manufacturer, exp => exp.Ignore());
                //CreateMap<CarTypeDetailModel, CarModelDetailModel>(MemberList.Source).DisableCtorValidation();
                // CreateMap<CarManufacturerDetailModel, CarModelDetailModel>(MemberList.Source).DisableCtorValidation();

            }
        }
    }
}
