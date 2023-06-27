using allinibp.Data.Models;

namespace allinibp.Services
{
    public interface IProductService
    {
        public Task<Product[]>? GetProducts();
        public Task<Product>? GetProduct(int id);
        public Task<string> CreateProduct(ProductDto request);
        public Task<string> UpdateProduct(int id, ProductDto request);
        public Task<string> DeleteProduct(int id);
        public Task<string> AddSupplier(int id, List<Supplier> suppliers);
        public Task<string> RemoveSupplier(int productId, int supplierId);
    }
}