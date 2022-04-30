using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarResale.DAL.Entities;
namespace CarResale.BL.Models
{
    public record AdvertisementListModel(
            string Title,
            string Description,
            DateTime PublicationTime
        ) :ModelBase
    {
        public string Title { get; set; } = Title;
        public string Description { get; set; } = Description;
        public DateTime PublicationTime { get; set; } = PublicationTime;
        public UserListModel User { get; set; }
        public List<ImageDetailModel> Images { get; set; }

        public class MapperProfile : Profile
        {
            public MapperProfile()
            {

                CreateMap<AdvertisementEntity, AdvertisementListModel>();
                CreateMap<AdvertisementDetailModel, AdvertisementListModel>();
            }
        }
    }
}
