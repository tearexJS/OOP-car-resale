using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarResale.DAL;

namespace CarResale.DAL.Tests
{
    public class CarResaleTestingDbContext : CarResaleDbContext
    {
        private readonly bool _seedTestingData;

        public CarResaleTestingDbContext(DbContextOptions contextOptions, bool seedTestingData = false)
            : base(contextOptions, seedDemoData: false)
        {
            _seedTestingData = seedTestingData;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (_seedTestingData)
            {
                
            }
        }
    }
}
