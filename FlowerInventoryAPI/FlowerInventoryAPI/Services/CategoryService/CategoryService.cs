using FlowerInventoryAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlowerInventoryAPI.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ProjectDbContext _dbContext;

        public CategoryService(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Category> CreateCategory(Category categoryRequest)
        {
            try
            {
                if(categoryRequest == null || categoryRequest.CategoryName == null)
                {
                    throw new Exception("Either whole category object or category name are null. Please check again your object");
                } else
                {
                    _dbContext.Category.Add(categoryRequest);
                    _dbContext.SaveChanges();
                    return categoryRequest;
                }
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseCommandResponse> DeleteCategory(Category categoryRequest)
        {
            try
            {
                _dbContext.Category.Remove(categoryRequest);
                _dbContext.SaveChanges();

                BaseCommandResponse response = new BaseCommandResponse
                {
                    Id = categoryRequest.CategoryId,
                    Entity = "Category",
                    Message = "Category Object has been deleted successfully"
                };

                return response;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Category>> GetAllCategories()
        {
            try
            {
                var list = _dbContext.Category.ToList();
                return list;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Category> GetCategoryByCategoryId(int categoryId)
        {
            try
            {
                var categoryExists = _dbContext.Category.AsNoTracking().FirstOrDefault(c=>c.CategoryId == categoryId);
                if(categoryExists == null)
                {
                    throw new Exception("Category Object does not exist in the database");
                }
                else
                {
                    return categoryExists;
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Category> UpdateCategory(Category categoryRequest)
        {
            try
            {
                var categoryExists = _dbContext.Category.AsNoTracking().FirstOrDefault(c => c.CategoryId == categoryRequest.CategoryId);
                if (categoryExists == null)
                {
                    throw new Exception("Category Object does not exist in the database");
                }
                else
                {
                    _dbContext.Category.Update(categoryRequest);
                    _dbContext.SaveChanges();
                    return categoryRequest;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
