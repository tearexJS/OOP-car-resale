using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarResale.DAL;

namespace CarResale.DAL.Tests
{
    public class DbContextLocalDBTestingFactory : IDbContextFactory<CarResaleDbContext>
    {
        private readonly string _databaseName;
        private readonly bool _seedTestingData;

        public DbContextLocalDBTestingFactory(string databaseName, bool seedTestingData = false)
        {
            _databaseName = databaseName;
            _seedTestingData = seedTestingData;
        }
        public CarResaleDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<CarResaleDbContext> builder = new();
            builder.UseSqlServer($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Projects\\OOP-car-resale\\DAL\\Resale.mdf;Integrated Security=True;");

             //contextOptionsBuilder.LogTo(System.Console.WriteLine); //Enable in case you want to see tests details, enabled may cause some inconsistencies in tests
             //builder.EnableSensitiveDataLogging();

            return new CarResaleTestingDbContext(builder.Options, _seedTestingData);
        }
    }
}
