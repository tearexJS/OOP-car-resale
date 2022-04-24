using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarResale.DAL.UnitOfWork
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IDbContextFactory<CarResaleDbContext> _dbContextFactory;

        public UnitOfWorkFactory(IDbContextFactory<CarResaleDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public IUnitOfWork Create() => new UnitOfWork(_dbContextFactory.CreateDbContext());
    }
}
