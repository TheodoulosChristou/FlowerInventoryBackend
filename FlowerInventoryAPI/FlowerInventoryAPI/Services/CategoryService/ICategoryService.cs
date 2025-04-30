using FlowerInventoryAPI.Entities;

namespace FlowerInventoryAPI.Services.CategoryService
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetAllCategories();

        public Task<Category> GetCategoryByCategoryId(int categoryId);

        public Task<Category> CreateCategory(Category categoryRequest);

        public Task<Category> UpdateCategory(Category categoryRequest);

        public Task<BaseCommandResponse> DeleteCategory(Category categoryRequest);


    }
}
