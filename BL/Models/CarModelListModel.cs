using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarResale.BL.Models;
using CarResale.DAL.Entities;
using AutoMapper;
using AutoMapper.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarResale.BL.Models
{
    public record CarModelListModel(
        string ModelName,
        decimal Engine,
        decimal Power,
        int Seats,
        decimal TrunkSize,
        string ManufacturerName,
        string Type
        ) : ModelBase
    {
        public string ModelName { get; set; } = ModelName;
        public decimal Engine { get; set; } = Engine;
        public decimal Power { get; set; } = Power;
        public int Seats { get; set; } = Seats;
        public decimal TrunkSize { get; set; } = TrunkSize;
        public string ManufacturerName { get; set; } = ManufacturerName;
        public string Type { get; set; } = Type;

        public class MapperProfile : Profile
        {
            public MapperProfile()
            {

                CreateMap<CarModelEntity, CarModelListModel>()
                    .ConstructUsing(src => new CarModelListModel("",default,default,default,default,"",""))
                    .IncludeMembers(src => src.Type, src => src.Manufacturer)
                    .ForMember(dest => dest.ManufacturerName, opt => opt.MapFrom(src => src.Manufacturer.ManufacturerName))
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Type));

                CreateMap<CarTypeEntity, CarModelListModel>(MemberList.None)
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));

                CreateMap<CarManufacturerEntity, CarModelListModel>(MemberList.None)
                    .ForMember(dest => dest.ManufacturerName, opt => opt.MapFrom(src => src.ManufacturerName));

                CreateMap<CarModelDetailModel, CarModelListModel>()
                    .ConstructUsing(src => new CarModelListModel("", default, default, default, default, "", ""))
                    .IncludeMembers(src => src.Type, src => src.Manufacturer)
                    .ForMember(dest => dest.ManufacturerName, opt => opt.MapFrom(src => src.Manufacturer.ManufacturerName))
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Type));

                CreateMap<CarTypeDetailModel, CarModelListModel>(MemberList.None)
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));

                CreateMap<CarManufacturerDetailModel, CarModelListModel>(MemberList.None)
                    .ForMember(dest => dest.ManufacturerName, opt => opt.MapFrom(src => src.ManufacturerName));

            }
        }
    }
}
