using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarResale.DAL.Entities
{
    public record CarModelEntity(
            Guid Id,
            string ModelName,
            decimal Engine,
            decimal Power,
            int Seats,
            decimal TrunkSize,
            Guid CarTypeId,
            Guid CarManufacturerId
        ) : IEntity
    { 
        public ICollection<CarEntity> Cars { get; init; } = new List<CarEntity>();
    }
}
