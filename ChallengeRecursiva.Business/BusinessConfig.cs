using ChallengeRecursiva.Business.Interfaces;
using ChallengeRecursiva.Business.Services;
using ChallengeRecursiva.DataAccess.Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ChallengeRecursiva.Business.Mapping;

namespace ChallengeRecursiva.Business
{
    public static class BusinessConfig
    {
        public static void AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccessServices(configuration);

            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IImportServices, ImportServices>();
            services.AddScoped<IReportPartnerServices, ReportPartnerServices>();

            //configura automapper with data of MappingProfile
            Mapper.Initialize(cfg => cfg.AddProfile<MappingProfile>());
            services.AddAutoMapper();
        }
    }
}
