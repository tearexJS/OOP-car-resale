using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarResale.DAL.Entities;

namespace CarResale.DAL.Seeds
{
    public static class UserSeeds
    {
        public static readonly UserEntity User = new UserEntity
        (
            Id: Guid.Parse("898d1adf-678f-44e7-89b8-47047d5d5744"),
            FirstName: "Jozko",
            Surname: "Mrkvicka",
            PhoneNumber: "0909 369 951",
            Email: "jozko.mrkvicka@email.com",
            Password: "JoziMrkvi123");

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(User);
        }
    }
}
