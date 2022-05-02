using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarResale.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Seeds
{
    public static class CarModelSeeds
    {
        public static readonly CarModelEntity OctaviaModel = new 
            CarModelEntity(
                Id: Guid.Parse(input: "6f075339-9b67-41a5-86c8-6aa5b7ac65a1"),
                ModelName: "Octavia",
                Engine: (decimal)1.5,
                Power: 100,
                Seats: 5,
                TrunkSize: 50,
                TypeId: Guid.Parse(input: "55e4f738-0706-440d-8e55-48169e3b33fb"),
                ManufacturerId: Guid.Parse(input: "30634fbe-728b-4c34-885b-f84bdc98f476")
              );
        public static readonly CarModelEntity DusterModel = new
            CarModelEntity(
                Id: Guid.Parse(input: "8a54828c-2900-456a-9251-f986b3954b54"),
                ModelName: "Duster",
                Engine: (decimal)1.0,
                Power: 50,
                Seats: 5,
                TrunkSize: 70,
                TypeId: Guid.Parse(input: "55e4f738-0706-440d-8e55-48169e3b33fb"),
                ManufacturerId: Guid.Parse(input: "3ebab845-0469-4445-8fe6-565e51f8ad77")
            );
        public static readonly CarModelEntity X1Model = new
            CarModelEntity(
                Id: Guid.Parse(input: "2a508c3a-de2c-4977-8ab2-36476df6ab1e"),
                ModelName: "X1",
                Engine: (decimal)2.0,
                Power: 150,
                Seats: 5,
                TrunkSize: 80,
                TypeId: Guid.Parse(input: "55e4f738-0706-440d-8e55-48169e3b33fb"),
                ManufacturerId: Guid.Parse(input: "524b7a8c-c082-410e-94fe-acb8d36b7eb9")
            );
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarModelEntity>().HasData(
                OctaviaModel,
                DusterModel,
                X1Model
            );
        }
    }
}
