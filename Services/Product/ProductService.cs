using Microsoft.EntityFrameworkCore;
using allinibp.Data;
using allinibp.Data.Models;

namespace allinibp.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateCategory(CategoryDto request)
        {
            var AlreadyExists = await _context.Categories!.Where(o => o.Name == request.Name).ToArrayAsync();
            if (AlreadyExists != null)
            {
                return $"The catergory {request.Name}, already exists!";
            }

            Category newCategory = new Category(){
                Name = request.Name,
                Description = request.Description,
            };
            await _context.Categories!.AddAsync(newCategory);
            await _context.SaveChangesAsync();
            return $"Category: {request.Name} has been created successfully.";
        }

        public Task<string> DeleteCategory(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>>? GetCategories()
        {
            var catgs = await _context.Categories!.ToListAsync();

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