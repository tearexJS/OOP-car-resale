using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarResale.DAL.Entities
{
    public record CarManufacturerEntity(
            Guid Id,
            string ManufacturerName
        ) : IEntity
    {
        //Automapper requires parameter less constructor for collection synchronization for now
#nullable disable
        public CarManufacturerEntity() : this(default, default) { }
#nullable enable
        public ICollection<CarModelEntity> Models { get; init; }
    }
}
