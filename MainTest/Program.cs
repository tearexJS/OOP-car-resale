using System;
using CarResale.DAL;
using CarResale.DAL.Factories;
namespace MainTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LocalDbContextFactory dbContextFactory = new LocalDbContextFactory("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Projects\\OOP-car-resale\\DAL\\Resale.mdf;Integrated Security=True");
            CarResaleDbContext dbContext = dbContextFactory.CreateDbContext();

            dbContext.Users.Add();
        }
    }
}
