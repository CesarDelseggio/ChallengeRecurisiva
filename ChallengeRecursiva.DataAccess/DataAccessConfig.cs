using ChallengeRecursiva.DataAccess;
using ChallengeRecursiva.DataAccess.Data.Models;
using ChallengeRecursiva.DataAccess.Interfaces;
using ChallengeRecursiva.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeRecursiva.Business
{
    public static class DataAccessConfig
    {
        public static void AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionStrings")));

            services.AddScoped<UnitOfWork, UnitOfWork>();
            services.AddScoped<IRepository<Log>, Repository<Log>>();
        }
    }
}
