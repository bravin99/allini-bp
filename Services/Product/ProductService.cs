using Microsoft.EntityFrameworkCore;
using allinibp.Data;
using allinibp.Data.Models;

namespace allinibp.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUtilsService _myUtils;

        public ProductService(ApplicationDbContext dbContext, IUtilsService myUtils)
        {
            _dbContext = dbContext;
            _myUtils = myUtils;
        }

        public async Task<string> CreateProduct(ProductDto request)
        {
            var skuString = _myUtils.RandomString(7).Result;

            Product newProduct = new Product()
            {
                Sku = skuString,
                BarCode = request.BarCode,
                Name = request.Name,
                Category = request.Category,
                Quantity = request.Quantity,
                AdjustedCount = request.Quantity,
                MinimumStock = request.MinimumStock,
                SafetyStock = request.SafetyStock,
                Cost = request.Cost,
                SalesPrice = request.SalesPrice,
                EndOfShelfLife = DateTime.SpecifyKind((DateTime)request.EndOfShelfLife!, DateTimeKind.Utc),
                Image = request.Image,
                Location = request.Location,
                LastCount = _myUtils.ToDateOnly(DateTime.UtcNow).Result,
            };

            await _dbContext.Products!.AddAsync(newProduct);
            await _dbContext.SaveChangesAsync();
            return "Product created";
        }

        public async Task<string> DeleteProduct(int id)
        {
            var product = await GetProduct(id)!;
            
            if (product == null!) return "No product with matching id found!";
            
            // remove product from context
            _dbContext.Products!.Remove(product);
            
            await _dbContext.SaveChangesAsync();
            
            return "product deleted successfully!";
        }

        public async Task<Product>? GetProduct(int id)
        {
            var product = await _dbContext.Products!.Include(
                    p => p.Suppliers).Include(
                    c => c.Category).FirstOrDefaultAsync(
                p => p.Id == id);
            return product!;
        }

        public async Task<Product[]>? GetProducts()
        {
            var products = await _dbContext.Products!.ToArrayAsync();
            return products!;
        }

        public async Task<string> UpdateProduct(int id, ProductDto request)
        {
            var product = await GetProduct(id)!;

            if (product == null!) return "Error trying to update product";
            
            product.BarCode = request.BarCode;
            product.Name = request.Name;
            product.Quantity = request.Quantity;
            product.MinimumStock = request.MinimumStock;
            product.SafetyStock = request.SafetyStock;
            product.Cost = request.Cost;
            product.SalesPrice = request.SalesPrice;
            product.EndOfShelfLife = DateTime.SpecifyKind((DateTime)request.EndOfShelfLife!, DateTimeKind.Utc);
            product.Image = request.Image;
            product.Location = request.Location;
            product.LastCount = _myUtils.ToDateOnly(DateTime.UtcNow).Result;

            await _dbContext.SaveChangesAsync();
            return "Product was updated successfully";
        }
        
        public async Task<string> AddSupplier(int id, List<Supplier> suppliers)
        {
            var product = await GetProduct(id)!;

            if (product == null!) return "product does not exist";

            foreach (var s in suppliers)
            {
                if (!(product.Suppliers!.Any(x => x.Id == s.Id))) 
                    product.Suppliers!.Add(s);
            }
            await _dbContext.SaveChangesAsync();
            
            return "supplier added to product";
        }

        public async Task<string> RemoveSupplier(int productId, int supplierId)
        {
            var product = await GetProduct(productId)!;
            var supplier = await _dbContext.Suppliers!.FirstOrDefaultAsync(
                s => s.Id == supplierId);

            if (product == null!) return "Product with id does not exist";
            if (supplier == null!) return "Supplier with id does not exist";

            product.Suppliers!.Remove(supplier);
            await _dbContext.SaveChangesAsync();

            return "Supplier removed";
        }
    }
}