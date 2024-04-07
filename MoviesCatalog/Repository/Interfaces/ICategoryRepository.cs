using MoviesCatalog.Models;

namespace MoviesCatalog.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategory(int id);
        Task AddCategory(Category category);
        void UpdateCategory(Category category);
        Task DeleteCategory(int id);
        Task SaveAsync();
    }
}
