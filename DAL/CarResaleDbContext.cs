using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarResale.DAL.Entities;
using CarResale.DAL.Seeds;
using Microsoft.EntityFrameworkCore;

namespace CarResale.DAL
{
    public class CarResaleDbContext : DbContext
    {
        private readonly bool _seedDemoData;

        public CarResaleDbContext(DbContextOptions contextOptions, bool seedDemoData = false) : base(contextOptions)
        {
            _seedDemoData = seedDemoData;
        }

        public DbSet<AdvertisementEntity> Advertisements => Set<AdvertisementEntity>();
        public DbSet<CarEntity> Cars => Set<CarEntity>();
        public DbSet<CarManufacturerEntity> CarManufacturers => Set<CarManufacturerEntity>();
        public DbSet<CarModelEntity> CarModels => Set<CarModelEntity>();
        public DbSet<CarTypeEntity> CarTypes => Set<CarTypeEntity>();
        public DbSet<ImageEntity> Images => Set<ImageEntity>();
        public DbSet<UserEntity> Users => Set<UserEntity>();

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
                UserSeeds.Seed(modelBuilder);
            }
        }
    }
}
