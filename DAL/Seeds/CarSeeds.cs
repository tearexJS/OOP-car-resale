using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarResale.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Seeds
{
    public static class CarSeeds
    {

        public static readonly CarEntity NewOctavia = new
            CarEntity(
                Id: Guid.Parse(input: "1d67aa3e-c3c5-4596-85fc-d686138435e9"),
                Mileage: 25000,
                YearOfManufacture: 2015,
                ImagePath: @"https://iprenders.blob.core.windows.net/basenx3s22100915/0F0FJPajxrCsGXSn-NtG637wqCc-w2jczupgTsV-RXsT9WNBlIeEm2qFtay6c_-8X4k3lOZJGDtdAM1aSqywhoE-AGHDB-19201080dayvext_front1000080.png",
                CarModelId: Guid.Parse(input: "6f075339-9b67-41a5-86c8-6aa5b7ac65a1")
            );
        public static readonly CarEntity OldOctavia = new
            CarEntity(
                Id: Guid.Parse(input: "3d010772-c4a7-4414-a893-28198f0d8e06"),
                Mileage: 250000,
                YearOfManufacture: 2005,
                ImagePath: @"https://www.bazos.sk/img/1/163/137100163.jpg",
                CarModelId: Guid.Parse(input: "6f075339-9b67-41a5-86c8-6aa5b7ac65a1")
             );
        public static readonly CarEntity NewX1 = new
            CarEntity(
                Id: Guid.Parse(input: "e6009e19-9062-46c8-8f1e-2b5c49070dbd"),
                Mileage: 25000,
                YearOfManufacture: 2018,
                ImagePath: @"https://img.tipcars.com/fotky_velke/33554565_1/1639064407/E/bmw-x1-xdrive20d.jpg",
                CarModelId: Guid.Parse(input: "2a508c3a-de2c-4977-8ab2-36476df6ab1e")
            );
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarEntity>().HasData(
                NewOctavia,
                OldOctavia,
                NewX1
            );
        }
    }
}
