using SmartStore.Core.Responses;
using SmartStore.Models.Dtos.Categories.Requests;
using SmartStore.Models.Dtos.Categories.Responses;
using SmartStore.Models.Entities;
using System.Linq.Expressions;

namespace SmartStore.Services.Abstracts
{
    public interface ICategoryService
    {
        Task<ReturnModel<List<CategoryResponseDto>>> GetAllAsync(
            bool enableTracking = false,
            bool withDeleted = false,
            Expression<Func<Category, bool>>? filter = null,
            Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null,
            CancellationToken cancellationToken = default);
        Task<ReturnModel<CategoryResponseDto>> GetByIdAsync(int id);
        Task<ReturnModel<CategoryResponseDto>> RemoveAsync(int id);

        Task<ReturnModel<CategoryResponseDto>> AddAsync(CreateCategoryRequest request);

        Task<ReturnModel<CategoryResponseDto>> UpdateAsync(int id, UpdateCategoryRequest request);


    }
}
