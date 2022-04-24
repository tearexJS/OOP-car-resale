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
        public ICollection<CarModelEntity> Models { get; init; }
    }
}
