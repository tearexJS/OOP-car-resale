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
        //Automapper requires parameter less constructor for collection synchronization for now
#nullable disable
        public CarModelEntity() : this(default, default, default, default, default, default, default, default) { }
#nullable enable
        public ICollection<CarEntity> Cars { get; init; } = new List<CarEntity>();
        public CarTypeEntity? Type { get; init; }
        public CarManufacturerEntity? ManufacturerName { get; init; }
    }
}
