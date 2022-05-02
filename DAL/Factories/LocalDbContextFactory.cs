using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarResale.DAL.Factories
{
    public class LocalDbContextFactory : IDbContextFactory<CarResaleDbContext>
    {
        private readonly string _connectionString;
        private readonly bool _seedDemoData;

        public LocalDbContextFactory(string connectionString, bool seedDemoData = false)
        {
            _connectionString = connectionString;
            _seedDemoData = seedDemoData;
        }
        public CarResaleDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarResaleDbContext>();
            optionsBuilder.UseSqlite(_connectionString);
            return new CarResaleDbContext(optionsBuilder.Options, _seedDemoData);
        }
    }
}
