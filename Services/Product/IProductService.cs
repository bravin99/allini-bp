using allinibp.Data;
using allinibp.Data.Models;

namespace allinibp.Services
{
    public interface IProductService
    {
        public Task<Product[]>? GetProducts();
        public Task<Product>? GetProduct(int Id);
        public Task<string> CreateProduct(ProductDto request);
        public Task<string> UpdateProduct(int Id, ProductDto request);
        public Task<string> DeleteProduct(int Id);
        public Task<string> AddSupplier(int id, List<Supplier> suppliers);
    }
}