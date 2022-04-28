using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarResale.BL.Facades;
using CarResale.BL.Models;
using CarResale.DAL.Entities;
using CarResale.DAL.UnitOfWork;

namespace BL.Facades
{
    public class CarManufacturerFacade : CRUDFacade<CarManufacturerEntity, CarManufacturerDetailModel, CarManufacturerDetailModel>
    {
        public CarManufacturerFacade(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : base(unitOfWorkFactory, mapper){}
    }
}
