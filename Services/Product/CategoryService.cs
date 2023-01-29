using Microsoft.EntityFrameworkCore;
using allinibp.Data;
using allinibp.Data.Models;

namespace allinibp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateCategory(CategoryDto request)
        {
            var AlreadyExists = await _context.Categories!.FirstOrDefaultAsync(o => o.Name == request.Name);
            if (AlreadyExists == null && !string.IsNullOrWhiteSpace(request.Name))
            {
                Category newCategory = new Category()
                {
                    Name = request.Name,
                    Description = request.Description,
                    Display = request.Display
                };
                _context.Categories!.Add(newCategory);
                await _context.SaveChangesAsync();
                return $"Category: {request.Name} has been created successfully.";
            }
            else if(string.IsNullOrWhiteSpace(request.Name))
            {
                return "Can't create a category without a name";
            }
            else
            {
                return $"The catergory {AlreadyExists!.Name} already exists!";
            }
        }

        public Task<string> DeleteCategory(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Category[]>? GetCategories()
        {
            var catgs = await _context.Categories!.Include(c => c.Products).ToArrayAsync();

            return !catgs.Any() ? null! : catgs;
        }

        public Task<Category> GetCategory()
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateCategory(CategoryDto request)
        {
            throw new NotImplementedException();
        }
    }
}