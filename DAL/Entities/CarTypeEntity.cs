using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarResale.DAL.Entities
{
    public record CarTypeEntity(
            Guid Id,
            string Type
        ) : IEntity
    {
        //Automapper requires parameter less constructor for collection synchronization for now
#nullable disable
        public CarTypeEntity() : this(default, default) { }
#nullable enable
        public ICollection<CarModelEntity> CarModels { get; init; } = new List<CarModelEntity>();
    }
}
