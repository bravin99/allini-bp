using Microsoft.EntityFrameworkCore;
using allinibp.Data;
using allinibp.Data.Models;

namespace allinibp.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ApplicationDbContext _dbContext;

        public SupplierService(ApplicationDbContext dbContext, IUtilsService myUtils)
        {
            _dbContext = dbContext;
        }

        public async Task<string> CreateSupplier(SupplierDto request)
        {
            var supplierExists = await _dbContext.Suppliers!.FirstOrDefaultAsync(s => s.Email == request.Email);
            
            if (supplierExists != null) return "Supplier already exists";
           
            var newSupplier = new Supplier(){
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Active = request.Active,
                InceptionDate = request.InceptionDate,
            };

            await _dbContext.Suppliers!.AddAsync(newSupplier);
            await _dbContext.SaveChangesAsync();

            return "Supplier created!";
            
        }
        
        public async Task<Supplier>? GetSupplierById(int id)
        {
            var supplier = await _dbContext.Suppliers!.Include(p => p.Products).FirstOrDefaultAsync(s => s.Id == id);
            return supplier!;
        }

        public async Task<string> DeleteSupplier(int id)
        {
            var supplier = await GetSupplierById(id)!;
            
            if (supplier == null) return "Supplier with id does not exist";

            // Remove the supplier from the database.
            _dbContext.Suppliers!.Remove(supplier);
            
            // Keep the products in the database.
            foreach (var product in supplier.Products!)
            {
                _dbContext.Products!.Attach(product);
            }
            
            await _dbContext.SaveChangesAsync();
            
            return "Supplier details deleted";
        }

        public async Task<Supplier[]>? GetSuppliers()
        {
            var supplierList = await _dbContext.Suppliers!.ToArrayAsync();
            return supplierList;
        }

        public async Task<string> UpdateSupplier(int id, SupplierDto request)
        {
            var supplier = await GetSupplierById(id)!;

            if (supplier == null) return "Supplier does not exist";
            
            supplier.Name = request.Name;
            supplier.Email = request.Email;
            supplier.PhoneNumber = request.PhoneNumber;
            supplier.Active = request.Active;
            supplier.InceptionDate = request.InceptionDate;

            await _dbContext.SaveChangesAsync();
            return "Update was successful";
        }
    }
}