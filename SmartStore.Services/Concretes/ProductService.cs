using AutoMapper;
using SmartStore.Core.Responses;
using SmartStore.DataAccess.Abstracts;
using SmartStore.Models.Dtos.Products.Requests;
using SmartStore.Models.Dtos.Products.Responses;
using SmartStore.Models.Entities;
using SmartStore.Services.Abstracts;
using SmartStore.Services.Rules;
using System.Linq.Expressions;

namespace SmartStore.Services.Concretes
{
    public class ProductService (IProductRepository _productRepository, IMapper _mapper, ProductBusinessRules _businessRules) : IProductService
    {
        
        public async Task<ReturnModel<CreatedProductResponseDto>> AddAsync(CreateProductRequest request)
        {
            await _businessRules.IsNameUnique(request.Name);
            Product addedProduct= _mapper.Map<Product>(request);
            addedProduct= await _productRepository.AddAsync(addedProduct);
            CreatedProductResponseDto response= _mapper.Map<CreatedProductResponseDto>(addedProduct);

            return new ReturnModel<CreatedProductResponseDto>
            {
                Data = response,
                Success = true,
                Message = "Product added successfully.",
                StatusCode = 201
            };
        }

        public async Task<ReturnModel<List<ProductResponseDto>>> GetAllAsync(bool enableTracking = false, bool withDeleted = false, Expression<Func<Product, bool>>? filter = null, Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null, CancellationToken cancellationToken = default)
        {
            List<Product> products= await _productRepository.GetAllAsync(enableTracking, withDeleted, filter, orderBy, cancellationToken);

            List<ProductResponseDto> response= _mapper.Map<List<ProductResponseDto>>(products);
            return new ReturnModel<List<ProductResponseDto>>
            {
                Data = response,
                Success = true,
                Message = "Products retrieved successfully.",
                StatusCode = 200
            };

        }

        public async Task<ReturnModel<ProductResponseDto>> GetByIdAsync(int id)
        {
            await _businessRules.IsProductExistAsync(id);

            Product? product= await _productRepository.GetByIdAsync(id);

            ProductResponseDto response= _mapper.Map<ProductResponseDto>(product);

            return new ReturnModel<ProductResponseDto>
            {
                Data = response,
                Success = true,
                Message = "Product retrieved successfully.",
                StatusCode = 200
            };
        }

        public async Task<ReturnModel<ProductResponseDto>> RemoveAsync(int id)
        {
            await _businessRules.IsProductExistAsync(id);

            Product? deletedProduct = await _productRepository.GetByIdAsync(id);

            ProductResponseDto responseDto = _mapper.Map<ProductResponseDto>(deletedProduct);
            await _productRepository.DeleteAsync(deletedProduct);

            return new ReturnModel<ProductResponseDto>
            {
                Data = responseDto,
                Success = true,
                Message = "Product deleted successfully.",
                StatusCode = 200
            };


        }

        public async Task<ReturnModel<ProductResponseDto>> UpdateAsync(UpdateProductRequest request)
        {
            await _businessRules.IsProductExistAsync(request.Id);
            await _businessRules.IsNameUnique(request.Name);

            Product? existingProduct = await _productRepository.GetByIdAsync(request.Id);
            existingProduct.Name = request.Name;
            existingProduct.Price = request.Price;
            existingProduct.Description = request.Description;
            existingProduct.CategoryId = request.CategoryId;

            Product updatedProduct = await _productRepository.UpdateAsync(existingProduct);
            ProductResponseDto response = _mapper.Map<ProductResponseDto>(updatedProduct);
            return new ReturnModel<ProductResponseDto>
            {
                Data = response,
                Success = true,
                Message = "Product updated successfully.",
                StatusCode = 200
            };
        }
    }
}
