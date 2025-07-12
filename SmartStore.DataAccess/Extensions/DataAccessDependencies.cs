using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartStore.DataAccess.Abstracts;
using SmartStore.DataAccess.Concretes;
using SmartStore.DataAccess.Contexts;

namespace SmartStore.DataAccess.Extensions
{
    public static class DataAccessDependencies
    {
        public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            services.AddScoped<IProductRepository, EfProductRepository>();
            services.AddDbContext<BaseDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

            return services;

        }
    }
}
