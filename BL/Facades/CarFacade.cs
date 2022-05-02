using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarResale.BL.Models;
using CarResale.DAL.Entities;
using CarResale.DAL.Factories;
using CarResale.DAL.UnitOfWork;

namespace CarResale.BL.Facades
{
    public class CarFacade : CRUDFacade<CarEntity, CarListModel, CarDetailModel>
    {
        public CarFacade(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : base(unitOfWorkFactory, mapper) { }
    }
}
