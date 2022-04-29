using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarResale.BL.Models;
using CarResale.DAL.Entities;
using CarResale.DAL.UnitOfWork;

namespace CarResale.BL.Facades
{
    public class CarModelFacade : CRUDFacade<CarModelEntity, CarModelListModel, CarModelDetailModel>
    {
        public CarModelFacade(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : base(unitOfWorkFactory,mapper){}
    }
}
