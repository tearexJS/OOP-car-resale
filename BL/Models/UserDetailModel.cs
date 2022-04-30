using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarResale.DAL.Entities;

namespace CarResale.BL.Models
{
    public record UserDetailModel(
            string FirstName,
            string? Surname,
            string PhoneNumber,
            string Email,
            string Password
        ) :ModelBase
    {
        public string FirstName { get; set; } = FirstName;
        public string Surname { get; set; } = Surname;
        public string PhoneNumber { get; set; } = PhoneNumber;
        public string Email { get; set; } = Email;
        public string Password { get; set; } = Password;
        public List<AdvertisementDetailModel> Advertisements { get; set; } = new();

        public class MapperProfile : Profile
        {
            public MapperProfile()
            {

                CreateMap<UserEntity, UserDetailModel>()
                    .ReverseMap()
                    .ForMember(entity => entity.Advertisements, opt => opt.Ignore());

                CreateMap<UserDetailModel, UserListModel>();
            }
        }

    }
}
