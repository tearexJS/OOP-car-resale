using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarResale.DAL.Entities
{
    public record AdvertisementEntity(
            Guid Id,
            string Title,
            string Description,
            decimal Price,
            DateTime PublicationTime,
            Guid CarId,
            Guid UserId
        ) : IEntity
    {
#nullable disable
        public AdvertisementEntity() : this(default, default, default, default, default, default, default) { }
#nullable enable
        public ICollection<ImageEntity>? Images { get; init; } = new List<ImageEntity>();
        public CarEntity? Car { get; init; }
        public UserEntity? User { get; init; }
    }
}
