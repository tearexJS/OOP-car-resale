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
        public ICollection<CarModelEntity>? CarModels { get; init; } = new List<CarModelEntity>();
    }
}
