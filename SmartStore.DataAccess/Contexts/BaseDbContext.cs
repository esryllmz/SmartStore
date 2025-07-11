
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartStore.Models.Entities;
using System.Reflection;

namespace SmartStore.DataAccess.Contexts
{
    public class BaseDbContext: IdentityDbContext<User, IdentityRole,string>
    {

        public BaseDbContext(DbContextOptions opt): base(opt) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Category> Categories { get; set; } 

        public DbSet<Product> Products { get; set; }

    }
}
