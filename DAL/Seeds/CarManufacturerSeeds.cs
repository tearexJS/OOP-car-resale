using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarResale.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Seeds
{
    public static class CarManufacturerSeeds
    {

        public static readonly CarManufacturerEntity ManufacturerBMW = new
            CarManufacturerEntity(
                Id: Guid.Parse(input: "524b7a8c-c082-410e-94fe-acb8d36b7eb9"),
                ManufacturerName: "BMW"
            );
        public static readonly CarManufacturerEntity ManufacturerSkoda = new
            CarManufacturerEntity(
                Id: Guid.Parse(input: "30634fbe-728b-4c34-885b-f84bdc98f476"),
                ManufacturerName: "Skoda"
            );
        public static readonly CarManufacturerEntity ManufacturerDacia = new
            CarManufacturerEntity(
                Id: Guid.Parse(input: "3ebab845-0469-4445-8fe6-565e51f8ad77"),
                ManufacturerName: "Dacia"
            );
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarManufacturerEntity>().HasData(
                ManufacturerBMW,
                ManufacturerSkoda,
                ManufacturerDacia
            );
        }
    }
}
