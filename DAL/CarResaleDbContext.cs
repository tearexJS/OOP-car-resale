using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Seeds;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    class CarResaleDbContext : DbContext
    {
        private readonly bool _seedDemoData;

        public CarResaleDbContext(DbContextOptions contextOptions, bool seedDemoData = false)
        {
            _seedDemoData = seedDemoData;
        }

        public DbSet<Advertisement> Advertisements => Set<Advertisement>();
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<CarManufacturer> CarManufacturers => Set<CarManufacturer>();
        public DbSet<CarModel> CarModels => Set<CarModel>();
        public DbSet<CarType> CarTypes => Set<CarType>();
        public DbSet<Credentials> Credentials => Set<Credentials>();
        public DbSet<Image> Images => Set<Image>();
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            if(_seedDemoData)
            {
                UserSeeds.Seed(modelBuilder);
            }
        }
    }
}
