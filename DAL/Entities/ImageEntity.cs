using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarResale.DAL.Entities
{
    public record ImageEntity(
            Guid Id,
            string ImagePath,
            Guid AdvertisementId
        ) : IEntity
    {
        public AdvertisementEntity? Advertisement { get; init; }
    }
}
