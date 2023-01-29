using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using allinibp.Data.Models;

namespace allinibp.Services
{
    public interface ICategoryService
    {
        public Task<string> CreateCategory(CategoryDto request);
        public Task<Category[]>? GetCategories();
        public Task<Category> GetCategory(int Id);
        public Task<string> UpdateCategory(int Id, CategoryDto request);
        public Task<string> DeleteCategory(int Id);

    }
}