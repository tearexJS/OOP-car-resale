﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarResale.DAL.Entities;

namespace CarResale.BL.Models
{
    public record AdvertisementDetailModel(
            string Title,
            string Description,
            decimal Price,
            DateTime PublicationTime
        ) :ModelBase
    {
        public string Title { get; set; } = Title;
        public string Description { get; set; } = Description;
        public decimal Price { get; set; } = Price;
        public DateTime PublicationTime { get; set; } = PublicationTime;
        public CarDetailModel Car { get; set; }
        public UserListModel User { get; set; }
        public List<ImageDetailModel> Images { get; set; } = new();

        public class MapperProfile : Profile
        {
            public MapperProfile()
            {

                CreateMap<AdvertisementEntity, AdvertisementDetailModel>()
                    .ReverseMap()
                    .ForMember(entity => entity.User, opt => opt.Ignore());
            }
        }
    }
}