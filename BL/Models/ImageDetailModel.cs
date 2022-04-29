using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarResale.BL.Models;
using CarResale.DAL.Entities;

namespace CarResale.BL.Models
{
    public record ImageDetailModel(
        string ImagePath
    ) :ModelBase
    {
        public string ImagePath { get; set; } = ImagePath;

        public class MapperProfile : Profile
        {
            public MapperProfile()
            {
                CreateMap<ImageEntity, ImageDetailModel>()
                    .ReverseMap();
            }
        }
    }
}
