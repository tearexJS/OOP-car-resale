using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Facades;
using BL.Models;
using CarResale.BL.Facades;
using CarResale.BL.Models;
using CarResale.BL.Tests;
using Xunit;
using Xunit.Abstractions;
using CarResale.DAL.Tests;
using Microsoft.EntityFrameworkCore;


namespace BL.Tests
{
    public class CarModelFacadeTests : CRUDFacadeTestsBase
    {
        private readonly CarModelFacade _carModelFacadeSUT;
        private readonly CarTypeFacade _carTypeFacadeSUT;
        private readonly CarManufacturerFacade _carManufacturerFacadeSUT;
        public CarModelFacadeTests(ITestOutputHelper output) : base(output)
        {
            _carModelFacadeSUT = new CarModelFacade(UnitOfWorkFactory, Mapper);
            _carTypeFacadeSUT = new CarTypeFacade(UnitOfWorkFactory, Mapper);
            _carManufacturerFacadeSUT = new CarManufacturerFacade(UnitOfWorkFactory, Mapper);
        }

        [Fact]
        public async Task NewCarModel_InsertOrUpdate_CarModelAdded()
        {
            var dbxAssert = DbContextFactory.CreateDbContext();
            var carManufacaturerModel = new CarManufacturerDetailModel(
                    ManufacturerName: "nigga"
                );
            var carTypeModel = new CarTypeDetailModel(
                Type: "shit"
                );

            carManufacaturerModel = await _carManufacturerFacadeSUT.SaveAsync(carManufacaturerModel);
            carTypeModel = await _carTypeFacadeSUT.SaveAsync(carTypeModel);
            //Arrange
            var carModel = new CarModelDetailModel(
                ModelName: "Water",
                Engine: (decimal) 1.2,
                Power: 123,
                Seats: 4,
                TrunkSize: 234
            )
            {
                Type = Mapper.Map<CarTypeDetailModel>(carTypeModel),
                ManufacturerName = Mapper.Map<CarManufacturerDetailModel>(carManufacaturerModel)
            };

        //Act
            
            carModel = await _carModelFacadeSUT.SaveAsync(carModel);

            //Assert
            var carModeFromDb = dbxAssert.CarModels.Include(i => i.Type).Include(i => i.ManufacturerName).Single(i => i.Id == carModel.Id);
            DeepAssert.Equal(carModel, Mapper.Map<CarModelDetailModel>(carModeFromDb));
        }

       [Fact]
        public async Task NewCarListModel_Read()
        {
            var dbxAssert = DbContextFactory.CreateDbContext();
            var carManufacaturerModel = new CarManufacturerDetailModel(
                ManufacturerName: "asdf"
            );
            var carTypeModel = new CarTypeDetailModel(
                Type: "asdf"
            );

            carManufacaturerModel = await _carManufacturerFacadeSUT.SaveAsync(carManufacaturerModel);
            carTypeModel = await _carTypeFacadeSUT.SaveAsync(carTypeModel);
            //Arrange
            var carModel = new CarModelDetailModel(
                ModelName: "asdf",
                Engine: (decimal)1.22,
                Power: 1234,
                Seats: 42,
                TrunkSize: 2343
            )
            {
                Type = Mapper.Map<CarTypeDetailModel>(carTypeModel),
                ManufacturerName = Mapper.Map<CarManufacturerDetailModel>(carManufacaturerModel)
            };
            carModel = await _carModelFacadeSUT.SaveAsync(carModel);
            var carListModelExpected = new CarModelListModel(
                    ModelName:"asdf",
                    Engine:(decimal)1.22,
                    Power: 1234,
                    Seats: 42,
                    TrunkSize:2343,
                    ManufacturerName:"asdf",
                    Type:"asdf"
                );
            var carModeFromDb = dbxAssert.CarModels.Include(i => i.Type).Single(i => i.Id == carModel.Id);
            DeepAssert.Equal(carListModelExpected, Mapper.Map<CarModelListModel>(carModeFromDb));
        }
       [Fact]
       public async Task MapCarModelDetialModelToCarModeListMode()
       {
           var
           CarModelDetail = new CarModelDetailModel(
                ModelName:"asdf",
                Power:1,
                Engine:1,
                Seats:1,
                TrunkSize:1
               )
           {
               Type = new CarTypeDetailModel("asdf"),
               ManufacturerName = new CarManufacturerDetailModel("asdf")
           };

           var carModelList = new CarModelListModel(
               ModelName:"asdf",
               Engine:1,
               Power:1,
               Seats:1,
               TrunkSize:1,
               ManufacturerName:"asdf",
               Type:"asdf"
               );

           DeepAssert.Equals(carModelList, Mapper.Map<CarModelListModel>(CarModelDetail));
       }
        /* private static void FixIds(CarModelDetailModel expectedModel, CarModelDetailModel returnedModel)
         {
             returnedModel.Id = expectedModel.Id;

             foreach (var ingredientAmountModel in returnedModel.Cars)
             {
                 var ingredientAmountDetailModel = expectedModel.Cars.FirstOrDefault(i =>
                     i. == ingredientAmountModel.IngredientName
                     && i.IngredientDescription == ingredientAmountModel.IngredientDescription
                     && i.IngredientImageUrl == ingredientAmountModel.IngredientImageUrl
                     && Math.Abs(i.Amount - ingredientAmountModel.Amount) <= 0
                     && i.Unit == ingredientAmountModel.Unit);

                 if (ingredientAmountDetailModel != null)
                 {
                     ingredientAmountModel.Id = ingredientAmountDetailModel.Id;
                     ingredientAmountModel.IngredientId = ingredientAmountDetailModel.IngredientId;
                 }
             }
         }*/
    }
}
