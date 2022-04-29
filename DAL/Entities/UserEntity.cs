using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarResale.DAL.Entities
{
    public record UserEntity(
            Guid Id,
            string FirstName,
            string? Surname,
            string PhoneNumber,
            string Email,
            string Password) : IEntity
    {
        //Automapper requires parameter less constructor for collection synchronization for now
#nullable disable
        public UserEntity() : this(default, default, default, default, default, default) { }
#nullable enable
        public ICollection<AdvertisementEntity> Advertisements { get; init; } = new List<AdvertisementEntity>();
    }
}
