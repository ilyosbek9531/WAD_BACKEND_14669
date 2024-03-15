using Microsoft.EntityFrameworkCore;
using WAD_BACKEND_14669.Data;
using WAD_BACKEND_14669.Models;

namespace WAD_BACKEND_14669.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly MovieDbContext _dbContext;

        public CategoriesRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteCategory(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task PostCategory(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task PutCategory(Category category)
        {
            _dbContext.Entry(category).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
