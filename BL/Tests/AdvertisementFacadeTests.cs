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
using Microsoft.EntityFrameworkCore;

namespace CarResale.BL.Tests
{
    public class AdvertisementFacadeTests : CRUDFacadeTestsBase
    {
        private readonly AdvertisementFacade _advertisementFacadeSUT;
        private readonly UserFacade _userFacadeSUT;
        private readonly CarFacade _carFacadeSUT;
        private readonly CarTypeFacade _carTypeFacadeSUT;
        private readonly CarManufacturerFacade _carManufacturerFacadeSUT;
        private readonly CarModelFacade _carModelFacadeSUT;
        public AdvertisementFacadeTests(ITestOutputHelper output) : base(output) 
        {
            _advertisementFacadeSUT = new AdvertisementFacade(UnitOfWorkFactory, Mapper);
            _userFacadeSUT = new UserFacade(UnitOfWorkFactory, Mapper);
            _carFacadeSUT = new CarFacade(UnitOfWorkFactory, Mapper);
            _carTypeFacadeSUT = new CarTypeFacade(UnitOfWorkFactory, Mapper);
            _carManufacturerFacadeSUT = new CarManufacturerFacade(UnitOfWorkFactory, Mapper);
            _carModelFacadeSUT = new CarModelFacade(UnitOfWorkFactory, Mapper);
        }
        [Fact]
        public async Task NewAdvertisement_InsertOrUpdate_AdvertisementsAdded()
        {
            
            var carType = new CarTypeDetailModel(
                    Type: "asdf"
                );
            carType = await _carTypeFacadeSUT.SaveAsync(carType);
            var carManufacturer = new CarManufacturerDetailModel(
                    ManufacturerName: "asdfasdf"
                );
            carManufacturer = await _carManufacturerFacadeSUT.SaveAsync(carManufacturer);

            var carModel = new CarModelDetailModel(
                    ModelName: "bmw",
                    Engine: (decimal)1.2,
                    Power: 123,
                    Seats: 4,
                    TrunkSize: 124
                )
            {
                Type = carType,
                Manufacturer = carManufacturer
            };
            carModel = await _carModelFacadeSUT.SaveAsync(carModel);
            var car = new CarDetailModel(
                    Mileage: 111,
                    YearOfManufacture: 2012
                )
            {
                CarModel = Mapper.Map<CarModelListModel>(carModel)
            };
            //car = await _carFacadeSUT.SaveAsync(car);
            var user = new UserDetailModel(
                    FirstName: "Martin",
                    Surname: "Martinez",
                    PhoneNumber: "0123456789",
                    Email: "nigga@nigger.com",
                    Password: "12345"
                );
            user = await _userFacadeSUT.SaveAsync(user);
            var advertisementModel = new AdvertisementDetailModel(
                    Title: "niggas car",
                    Description: "very good almosts new",
                    Price: 5,
                    PublicationTime: DateTime.Now
            )
            {
                Images = new List<ImageDetailModel>(),
                Car = car,
                User = Mapper.Map<UserListModel>(user)
            };
            advertisementModel = await _advertisementFacadeSUT.SaveAsync(advertisementModel);

            var dbxAssert = DbContextFactory.CreateDbContext();
            var advertisementFromDb = dbxAssert.Advertisements.Include(i => i.Car).Include(i => i.User).Single(i => i.Id == advertisementModel.Id);
            var advertisementModelFromDb = Mapper.Map<AdvertisementDetailModel>(advertisementFromDb);
            DeepAssert.Equals(advertisementModel, advertisementFromDb);

        }
    }
}
