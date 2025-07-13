using AutoMapper;
using SmartStore.Core.Responses;
using SmartStore.DataAccess.Abstracts;
using SmartStore.Models.Dtos.Categories.Requests;
using SmartStore.Models.Dtos.Categories.Responses;
using SmartStore.Models.Entities;
using SmartStore.Services.Abstracts;
using SmartStore.Services.Rules;
using System.Linq.Expressions;

namespace SmartStore.Services.Concretes
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _businessRules;
        public async Task<ReturnModel<CategoryResponseDto>> AddAsync(CreateCategoryRequest request)
        {
            await _businessRules.IsNameUniqueAsync(request.Name);

            var addedcategory = _mapper.Map<Category>(request);
            await _categoryRepository.AddAsync(addedcategory);
            CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(addedcategory);

            return new ReturnModel<CategoryResponseDto>()
            {
                Data = response,
                Message = "Category added successfully.",
                Success = true,
                StatusCode=201
            };

        }

        public async Task<ReturnModel<List<CategoryResponseDto>>> GetAllAsync(bool enableTracking = false, bool withDeleted = false, Expression<Func<Category, bool>>? filter = null, Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null, CancellationToken cancellationToken = default)
        {
            List<Category> categories= await _categoryRepository.GetAllAsync(enableTracking, withDeleted, filter, orderBy, cancellationToken);
            List<CategoryResponseDto> response = _mapper.Map<List<CategoryResponseDto>>(categories);


            return new ReturnModel<List<CategoryResponseDto>>()
            {
                Data = response,
                Message = "Categories retrieved successfully.",
                Success = true,
                StatusCode = 200
            };
        }

        public async Task<ReturnModel<CategoryResponseDto>> GetByIdAsync(int id)
        {
            await _businessRules.IsCategoryExistAsync(id);

            Category? category = await _categoryRepository.GetByIdAsync(id);

            CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(category);

            return new ReturnModel<CategoryResponseDto>()
            {
                Data = response,
                Message = "Category retrieved successfully.",
                Success = true,
                StatusCode = 200
            };
        }

        public async Task<ReturnModel<CategoryResponseDto>> RemoveAsync(int id)
        {
            await _businessRules.IsCategoryExistAsync(id);

            Category? deletedCategory = await _categoryRepository.GetByIdAsync(id);
            await _categoryRepository.DeleteAsync(deletedCategory);
            CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(deletedCategory);
            return new ReturnModel<CategoryResponseDto>()
            {
                Data = response,
                Message = "Category removed successfully.",
                Success = true,
                StatusCode = 200
            };
        }

        public async Task<ReturnModel<CategoryResponseDto>> UpdateAsync(UpdateCategoryRequest request)
        {
            await _businessRules.IsCategoryExistAsync(request.Id);
            await _businessRules.IsNameUniqueAsync(request.Name);

            Category? existingCategory= await _categoryRepository.GetByIdAsync(request.Id);
            existingCategory.Id = request.Id; 
            existingCategory.Name = request.Name;
         
            Category updatedCategory= await _categoryRepository.UpdateAsync(existingCategory);

            CategoryResponseDto response= _mapper.Map<CategoryResponseDto>(updatedCategory);
            return new ReturnModel<CategoryResponseDto>()
            {
                Data = response,
                Message = "Category updated successfully.",
                Success = true,
                StatusCode = 200
            };


        }
    }
}
