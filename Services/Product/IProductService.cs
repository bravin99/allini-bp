using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using allinibp.Data.Models;

namespace allinibp.Services
{
    public interface IProductService
    {
        public Task<string> CreateCategory(CategoryDto request);
        public Task<List<Category>>? GetCategories();
        public Task<Category> GetCategory();
        public Task<string> UpdateCategory(CategoryDto request);
        public Task<string> DeleteCategory(int Id);

    }
}