using Microsoft.Extensions.DependencyInjection;
using SmartStore.Services.Abstracts;
using SmartStore.Services.Concretes;
using SmartStore.Services.Profiles;
using SmartStore.Services.Rules;
using System.Reflection;

namespace SmartStore.Services.Extensions
{
    public static class ServicesDependencies
    {

        public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<CategoryBusinessRules>();
            services.AddScoped<ProductBusinessRules>();


            return services;
        }

    }
}
