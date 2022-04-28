using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using CarResale.BL.Facades;
using CarResale.BL.Models;
using CarResale.BL.Tests;
using Xunit;
using Xunit.Abstractions;
using CarResale.DAL.Tests;


namespace CarResale.BL.Tests
{
    public class CarTypeFacadeTests : CRUDFacadeTestsBase
    {
        private readonly CarTypeFacade _carTypeFacadeSUT;
        public CarTypeFacadeTests(ITestOutputHelper output) : base(output)
        {
            _carTypeFacadeSUT = new CarTypeFacade(UnitOfWorkFactory, Mapper);
        }

        [Fact]
        public async Task NewCarType_InsertOrUpdate_CarTypeAdded()
        {
            //Arrange
            var carType = new CarTypeDetailModel(
                Type: "shit"
            );

            //Act
            carType = await _carTypeFacadeSUT.SaveAsync(carType);

            //Assert
            var dbxAssert = DbContextFactory.CreateDbContext();
            var carModeFromDb = dbxAssert.CarTypes.Single(i => i.Id == carType.Id);
            DeepAssert.Equal(carType, Mapper.Map<CarTypeDetailModel>(carModeFromDb));
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
