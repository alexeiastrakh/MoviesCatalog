using MoviesCatalog.Models.DBContext;
using MoviesCatalog.Models;
using MoviesCatalog.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MoviesCatalog.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MovieDbContext _context;

        public CategoryRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public void UpdateCategory(Category category)
        {
            _context.Update(category);
        }

        public async Task DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
