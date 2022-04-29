using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarResale.BL.Facades;
using CarResale.BL.Models;
using Xunit.Abstractions;
using Xunit;
using CarResale.DAL.Tests;

namespace CarResale.BL.Tests
{
    public class CarManufacturerFacadeTests : CRUDFacadeTestsBase
    {
        private readonly CarManufacturerFacade _carManufacturerFacadeSUT;

        public CarManufacturerFacadeTests(ITestOutputHelper output) : base(output) 
        {
            _carManufacturerFacadeSUT = new CarManufacturerFacade(UnitOfWorkFactory, Mapper);
        }
        [Fact]
        public async Task NewManufacturer_InsertOrUpdate_ManufacturerAdded() 
        {


            //Arrange
            var carManufacturer = new CarManufacturerDetailModel(
                    ManufacturerName: "Skoda"
                );

            //Act

            carManufacturer = await _carManufacturerFacadeSUT.SaveAsync(carManufacturer);

            //Assert
            var dbxAssert = DbContextFactory.CreateDbContext();
            var carModeFromDb = dbxAssert.CarManufacturers.Single(i => i.Id == carManufacturer.Id);
            DeepAssert.Equals(carManufacturer, Mapper.Map<CarManufacturerDetailModel>(carModeFromDb));
        }
    }
}
