using SmartStore.Core.Responses;
using SmartStore.Models.Dtos.Products.Requests;
using SmartStore.Models.Dtos.Products.Responses;
using SmartStore.Models.Entities;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace SmartStore.Services.Abstracts
{
    public interface IProductService
    {
        Task<ReturnModel<List<ProductResponseDto>>> GetAllAsync(
              bool enableTracking = false,
              bool withDeleted = false,
              Expression<Func<Product, bool>>? filter = null,
              Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null,
              CancellationToken cancellationToken = default);
        Task<ReturnModel<ProductResponseDto>> GetByIdAsync(int id);
        Task<ReturnModel<CreatedProductResponseDto>> AddAsync(CreateProductRequest request);
        Task<ReturnModel<ProductResponseDto>> RemoveAsync(int id);
        Task<ReturnModel<ProductResponseDto>> UpdateAsync(UpdateProductRequest request);
        


    }
}
