using System;
using AutoMapper;
using CleanArch.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1.MappingConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services )
        {

            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            
            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile),
                typeof(ViewModelToDomainMappingProfile));
            
        }
    }
}