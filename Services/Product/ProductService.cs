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
            // var category = await _dbContext.Categories!.FirstOrDefaultAsync(c => c.Id == request.CategoryId);
            // if (category != null)
            //     NewProduct.Category = category;

            await _dbContext.Products!.AddAsync(newProduct);
            await _dbContext.SaveChangesAsync();
            return "Product created";
        }

        public async Task<string> DeleteProduct(int Id)
        {
            var p = await _dbContext.Products!.FirstOrDefaultAsync(p => p.Id == Id);
            if (p != null)
            {
                _dbContext.Products!.Remove(p);
                await _dbContext.SaveChangesAsync();
                return "The product was deleted successfully!";
            }
            return "The product you are trying to delete was not found!";
        }

        public async Task<Product>? GetProduct(int Id)
        {
            var product = await _dbContext.Products!.Include(
                    p => p.Suppliers).Include(
                    c => c.Category).FirstOrDefaultAsync(
                p => p.Id == Id);
            return product!;
        }

        public async Task<Product[]>? GetProducts()
        {
            var products = await _dbContext.Products!.ToArrayAsync();
            return products!;
        }

        public async Task<string> UpdateProduct(int Id, ProductDto request)
        {
            var product = await _dbContext.Products!.FirstOrDefaultAsync(p => p.Id == Id);
            if (product != null)
            {
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
                // product.Supplier = request.Supplier;

                await _dbContext.SaveChangesAsync();
                return "Product was upated successfully";
            }
            return "Error trying to update product";
        }
        
        public async Task<string> AddSupplier(int id, List<Supplier> suppliers)
        {
            var product = await _dbContext.Products!.Include(
                s => s.Suppliers).FirstOrDefaultAsync(x => x.Id == id);

            if (product == null) return "product does not exist";

            foreach (var s in suppliers)
            {
                if (!(product.Suppliers!.Any(x => x.Id == s.Id))) 
                    product.Suppliers!.Add(s);
            }
            await _dbContext.SaveChangesAsync();
            
            return "supplier added to product";
        }
        
    }
}