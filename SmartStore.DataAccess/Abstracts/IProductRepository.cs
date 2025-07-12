using SmartStore.Core.Repositories;
using SmartStore.Models.Entities;


namespace SmartStore.DataAccess.Abstracts
{
    public interface IProductRepository : IRepository< Product,int>
    {
        Task<Product?> GetByNameAsync(string name);

    }
}
