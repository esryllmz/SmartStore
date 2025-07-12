using Microsoft.EntityFrameworkCore;
using SmartStore.Core.Repositories;
using SmartStore.DataAccess.Abstracts;
using SmartStore.DataAccess.Contexts;
using SmartStore.Models.Entities;

namespace SmartStore.DataAccess.Concretes
{
    public class EfCategoryRepository: EfBaseRepository<BaseDbContext,Category,int>, ICategoryRepository
    {

        public EfCategoryRepository(BaseDbContext context): base(context) { }

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
        }

    }
}
