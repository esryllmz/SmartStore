using SmartStore.Core.Repositories;
using SmartStore.DataAccess.Abstracts;
using SmartStore.DataAccess.Contexts;
using SmartStore.Models.Entities;

namespace SmartStore.DataAccess.Concretes
{
    public class EfProductRepository: EfBaseRepository<BaseDbContext, Product,int>, IProductRepository
    {
        public EfProductRepository(BaseDbContext context):base(context) { }
    }
}
