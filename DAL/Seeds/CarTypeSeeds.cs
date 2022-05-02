using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarResale.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Seeds
{
    public static class CarTypeSeeds
    {
        public static readonly CarTypeEntity PersonalCar = new
            CarTypeEntity(
                Id: Guid.Parse(input: "55e4f738-0706-440d-8e55-48169e3b33fb"),
                Type: "personal"
            );
        public static readonly CarTypeEntity TruckCar = new
            CarTypeEntity(
                Id: Guid.Parse(input: "321284c6-a771-4627-8e71-9d77c0b70795"),
                Type: "truck"
            );
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarTypeEntity>().HasData(
                PersonalCar,
                TruckCar
            );
        }
    }
}
