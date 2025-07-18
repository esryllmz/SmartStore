﻿using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SmartStore.Services.Abstracts;
using SmartStore.Services.Concretes;
using SmartStore.Services.Profiles;
using SmartStore.Services.Rules;
using SmartStore.Services.Validations.Categories;
using System.Reflection;

namespace SmartStore.Services.Extensions
{
    public static class ServicesDependencies
    {

        public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            
            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<CategoryBusinessRules>();
            services.AddScoped<ProductBusinessRules>();

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }

    }
}
