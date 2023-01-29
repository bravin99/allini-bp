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

        public async Task<string> DeleteCategory(int Id)
        {
            var c = await _context.Categories!.FirstOrDefaultAsync(c => c.Id == Id);
            if (c != null)
            {
                _context.Categories!.Remove(c);
                await _context.SaveChangesAsync();
                return $"The category {c!.Name}, has been deleted!";
            }
            else
            {
                return $"The category with id {c!.Name}, was not found!";
            }
        }

        public async Task<Category[]>? GetCategories()
        {
            var catgs = await _context.Categories!.Include(c => c.Products).ToArrayAsync();

            return !catgs.Any() ? null! : catgs;
        }

        public async Task<Category> GetCategory(int Id)
        {
            var cat = await _context.Categories!.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == Id);
            return cat == null ? null! : cat;
        }

        public async Task<string> UpdateCategory(int Id, CategoryDto request)
        {
            var cat = await _context.Categories!.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == Id);
            if (cat != null)
            {
                cat.Name = request.Name;
                cat.Description = request.Description;
                cat.Display = request.Display;
                cat.Updated = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return $"Category {cat.Name} updated!";
            }
            return $"Category {cat!.Name} not found!";
        }
    }
}