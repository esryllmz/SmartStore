using SmartStore.DataAccess.Abstracts;

namespace SmartStore.Services.Rules
{
    public class CategoryBusinessRules(ICategoryRepository categoryRepository)
    {
        public async Task IsCategoryExistAsync(int id)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                throw new Exception($"Category with ID {id} does not exist.");
            }
        }

        public async Task IsNameUniqueAsync(string name)
        {
            var existingCategory = await categoryRepository.GetByNameAsync(name);
            if (existingCategory != null)
            {
                throw new Exception($"Category with name '{name}' already exists.");
            }
        }



    }
}
