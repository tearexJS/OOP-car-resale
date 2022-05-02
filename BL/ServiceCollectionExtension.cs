using CarResale.BL.Facades;
using CarResale.DAL.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using CarResale.DAL;

namespace CarResale.BL
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddBLServices(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();
            services.AddSingleton<CarFacade>();
            services.AddSingleton<CarManufacturerFacade>();
            services.AddSingleton<CarTypeFacade>();
            services.AddSingleton<CarModelFacade>();

            services.AddAutoMapper((serviceProvider, cfg) =>
            {
                cfg.AddCollectionMappers();

                var dbContextFactory = serviceProvider.GetRequiredService<IDbContextFactory<CarResaleDbContext>>();
                using var dbContext = dbContextFactory.CreateDbContext();
                cfg.UseEntityFrameworkCoreModel<CarResaleDbContext>(dbContext.Model);
            }, typeof(BusinessLogic).Assembly);
            return services;
        }
    }
}
