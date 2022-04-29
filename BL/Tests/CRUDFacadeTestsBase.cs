using System;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.EquivalencyExpression;

using CarResale.DAL;
using CarResale.DAL.Factories;
using CarResale.DAL.UnitOfWork;
using CarResale.DAL.Tests;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;
using CarResale.BL;

namespace CarResale.BL.Tests
{


    public class CRUDFacadeTestsBase : IAsyncLifetime
    {
        protected CRUDFacadeTestsBase(ITestOutputHelper output)
        {
            XUnitTestOutputConverter converter = new(output);
            Console.SetOut(converter);

            // DbContextFactory = new DbContextTestingInMemoryFactory(GetType().Name, seedTestingData: true);
            DbContextFactory = new DbContextLocalDBTestingFactory(GetType().FullName!, seedTestingData: true);
            //DbContextFactory = new DbContextLocalDBTestingFactory("OOPresale.sqlite", seedTestingData: true);


            UnitOfWorkFactory = new UnitOfWorkFactory(DbContextFactory);

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(new[]
                {
                        typeof(BusinessLogic),
                    });
                cfg.AddCollectionMappers();

                using var dbContext = DbContextFactory.CreateDbContext();
                cfg.UseEntityFrameworkCoreModel<CarResaleDbContext>(dbContext.Model);
            }
            );
            Mapper = new Mapper(configuration);
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        protected IDbContextFactory<CarResaleDbContext> DbContextFactory { get; }

        protected Mapper Mapper { get; }

        protected UnitOfWorkFactory UnitOfWorkFactory { get; }

        public async Task InitializeAsync()
        {
            await using var dbx = DbContextFactory.CreateDbContext();
            await dbx.Database.EnsureDeletedAsync();
            await dbx.Database.EnsureCreatedAsync();
        }

        public async Task DisposeAsync()
        {
            await using var dbx = DbContextFactory.CreateDbContext();
            await dbx.Database.EnsureDeletedAsync();
        }
    }
}