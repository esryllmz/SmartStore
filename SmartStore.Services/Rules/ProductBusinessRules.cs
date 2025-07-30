using SmartStore.Core.Exceptions;
using SmartStore.DataAccess.Abstracts;

namespace SmartStore.Services.Rules
{
    public class ProductBusinessRules(IProductRepository _productRepository)
    {
     

        public async Task IsProductExistAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                throw new NotFoundException($"Product with ID {id} does not exist.");
            }
        }

        public async Task IsNameUnique(string name)
        {
            var product = await _productRepository.GetByNameAsync(name);

            if (product != null)
            {
                throw new BusinessException($"Product with name '{name}' already exists.");
            }
        }

    }
}
