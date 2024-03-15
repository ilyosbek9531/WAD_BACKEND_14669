using WAD_BACKEND_14669.Models;

namespace WAD_BACKEND_14669.Repositories
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
        Task PostCategory(Category movie);
        Task PutCategory(Category movie);
        Task DeleteCategory(int id);
    }
}
