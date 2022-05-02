using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarResale.DAL.Entities
{
    public record CarEntity(
            Guid Id,
            decimal Mileage,
            int YearOfManufacture,
            string ImagePath,
            Guid CarModelId
        ) : IEntity
    {
        public CarModelEntity? CarModel { get; init; }
    }
}
