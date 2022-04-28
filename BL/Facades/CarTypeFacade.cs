using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL.Models;
using CarResale.BL.Facades;
using CarResale.DAL.Entities;
using CarResale.DAL.UnitOfWork;

namespace CarResale.BL.Facades
{
    public class CarTypeFacade : CRUDFacade<CarTypeEntity, CarTypeDetailModel, CarTypeDetailModel>
    {
        public CarTypeFacade(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : base(unitOfWorkFactory, mapper){ }
    }
}
