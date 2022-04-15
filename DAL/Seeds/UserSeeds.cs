using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace DAL.Seeds
{
    public static class UserSeeds
    {
        public static readonly User User = new User
        {
            UserId = 1,
            FirstName = "Jozko",
            Surname = "Mrkvicka"
        };

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(User);
        }
    }
}
