using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarResale.DAL.Entities;
using Xunit;
using Xunit.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CarResale.DAL.Tests
{
    public class DbContextCarManufacturerTest : DbContextTestsBase
    {
       public DbContextCarManufacturerTest(ITestOutputHelper output) : base(output)
       {
       }

        [Fact]
        public void AddNewUserPersisted()
        {
            //Arrange
            UserEntity entity = new(
                Guid.Parse("898d1adf-678f-44e7-89b8-47047d5d5744"),
                FirstName: "Jozko",
                Surname: "Mrkvicka",
                PhoneNumber: "0909 369 951",
                Email: "jozko.mrkvicka@email.com",
                Password: "JoziMrkvi123"
            );
            
            //Act
            CarResaleDbContextSUT.Users.Add(entity);
            CarResaleDbContextSUT.SaveChanges();
            Console.WriteLine("RUUUUUUN");
            //Assert
            using var dbx =  DbContextFactory.CreateDbContext();
            var actualEntities = dbx.Users.Single(i => i.Id == entity.Id);
            Assert.Equal(entity, actualEntities);
        }
    }
}
