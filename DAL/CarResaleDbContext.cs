using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarResale.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Seeds;

namespace CarResale.DAL
{
    public class CarResaleDbContext : DbContext
    {
        private readonly bool _seedDemoData;

        public CarResaleDbContext(DbContextOptions contextOptions, bool seedDemoData = false) : base(contextOptions)
        {
            _seedDemoData = seedDemoData;
        }

        public DbSet<CarEntity> Cars => Set<CarEntity>();
        public DbSet<CarManufacturerEntity> CarManufacturers => Set<CarManufacturerEntity>();
        public DbSet<CarModelEntity> CarModels => Set<CarModelEntity>();
        public DbSet<CarTypeEntity> CarTypes => Set<CarTypeEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            //creates entity Image
            /*modelBuilder.Entity<ImageEntity>();
            modelBuilder.Entity<UserEntity>();
            modelBuilder.Entity<CarEntity>();
            modelBuilder.Entity<CarManufacturerEntity>();
            modelBuilder.Entity<CarModelEntity>();
            modelBuilder.Entity<CarTypeEntity>();*/

            if(_seedDemoData)
            {
                CarManufacturerSeeds.Seed(modelBuilder);
                CarTypeSeeds.Seed(modelBuilder);
                CarModelSeeds.Seed(modelBuilder);
                CarSeeds.Seed(modelBuilder);
            }
        }
    }
}
