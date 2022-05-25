using ChallengeRecursiva.Business.Interfaces;
using ChallengeRecursiva.Business.Services;
using ChallengeRecursiva.DataAccess.Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeRecursiva.Business
{
    public static class BusinessConfig
    {
        public static void AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccessServices(configuration);

            services.AddScoped<IService<Log>, LogService>();
        }
    }
}
