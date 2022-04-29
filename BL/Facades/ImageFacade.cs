﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarResale.BL.Models;
using CarResale.BL.Facades;
using CarResale.DAL.Entities;
using CarResale.DAL.UnitOfWork;

namespace CarResale.BL.Facades
{
    public class ImageFacade : CRUDFacade<ImageEntity, ImageDetailModel, ImageDetailModel>
    {
        public ImageFacade(IUnitOfWorkFactory unitOfWorkFactory, Mapper mapper) : base(unitOfWorkFactory, mapper) { }
    }
}
