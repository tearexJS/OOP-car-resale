using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarResale.DAL.Factories;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace CarResale.DAL.Tests
{
    public class DbContextTestsBase
    {
        protected DbContextTestsBase(ITestOutputHelper output)
        {
            XUnitTestOutputConverter converter = new(output);
            Console.SetOut(converter);

            // DbContextFactory = new DbContextTestingInMemoryFactory(GetType().Name, seedTestingData: true);
            // DbContextFactory = new DbContextLocalDBTestingFactory(GetType().FullName!, seedTestingData: true);
            DbContextFactory = new LocalDbContextFactory("Resale.mdf", seedDemoData: true);

            CarResaleDbContextSUT = DbContextFactory.CreateDbContext();
        }

        protected IDbContextFactory<CarResaleDbContext> DbContextFactory { get; }
        protected CarResaleDbContext CarResaleDbContextSUT { get; }


        public void Initialize()
        {
            CarResaleDbContextSUT.Database.EnsureDeleted();
            CarResaleDbContextSUT.Database.EnsureCreated();
        }

        public void Dispose()
        {
            CarResaleDbContextSUT.Database.EnsureDeleted();
            CarResaleDbContextSUT.Dispose();
        }
    }
}
