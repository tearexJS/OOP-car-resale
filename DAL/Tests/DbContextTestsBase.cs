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
    public class DbContextTestsBase : IAsyncLifetime
    {
        protected DbContextTestsBase(ITestOutputHelper output)
        {
            XUnitTestOutputConverter converter = new(output);
            Console.SetOut(converter);

            // DbContextFactory = new DbContextTestingInMemoryFactory(GetType().Name, seedTestingData: true);
            // DbContextFactory = new DbContextLocalDBTestingFactory(GetType().FullName!, seedTestingData: true);
            DbContextFactory = new DbContextLocalDBTestingFactory(GetType().FullName!, seedTestingData: true);


            CarResaleDbContextSUT = DbContextFactory.CreateDbContext();
        }

        protected IDbContextFactory<CarResaleDbContext> DbContextFactory { get; }
        protected CarResaleDbContext CarResaleDbContextSUT { get; }


        public async Task InitializeAsync()
        {
            await CarResaleDbContextSUT.Database.EnsureDeletedAsync();
            await CarResaleDbContextSUT.Database.EnsureCreatedAsync();
        }

        public async Task DisposeAsync()
        {
            await CarResaleDbContextSUT.Database.EnsureDeletedAsync();
            await CarResaleDbContextSUT.DisposeAsync();
        }
    }
}
