using Microsoft.EntityFrameworkCore;
using allinibp.Data;
using allinibp.Data.Models;

namespace allinibp.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> CreateProduct(ProductDto request)
        {
            Product NewProduct = new Product()
            {
                BarCode = request.BarCode,
                Name = request.Name,
                Quantity = request.Quantity,
                MinimumStock = request.MinimumStock,
                SafetyStock = request.SafetyStock,
                Cost = request.Cost,
                SalesPrice = request.SalesPrice,
                EndOfShelfLife = request.EndOfShelfLife,
                Image = request.Image,
                Location = request.Location,
                LastCount = request.LastCount,
            };
            var category = await _dbContext.Categories!.FirstOrDefaultAsync(c => c.Name == request.Category);
            if (category != null)
                NewProduct.Category = category;

            await _dbContext.Products!.AddAsync(NewProduct);
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
            var product = await _dbContext.Products!.Include(p => p.Supplier).FirstOrDefaultAsync(p => p.Id == Id);
            return product == null ? null! : product;
        }

        public async Task<Product[]>? GetProducts()
        {
            var products = await _dbContext.Products!.ToArrayAsync();
            return products != null ? products : null!;
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
                product.EndOfShelfLife = request.EndOfShelfLife;
                product.Image = request.Image;
                product.Location = request.Location;
                product.LastCount = request.LastCount;
                // product.Supplier = request.Supplier;

                await _dbContext.SaveChangesAsync();
                return "Product was upated successfully";
            }
            return "Error trying to update product";
        }
    }
}