using Microsoft.EntityFrameworkCore;
using allinibp.Data;
using allinibp.Data.Models;

namespace allinibp.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUtilsService _myUtils;

        public SupplierService(ApplicationDbContext dbContext, IUtilsService myUtils)
        {
            _dbContext = dbContext;
            _myUtils = myUtils;
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

        public async Task<string> DeleteSupplier(int id)
        {
            var supplier = await _dbContext.Suppliers!.Include(p => p.Products).FirstOrDefaultAsync(
                s => s.Id == id);
            
            if (supplier == null) return "Supplier with id does not exist";

            _dbContext.Suppliers!.Remove(supplier);
            await _dbContext.SaveChangesAsync();
            
            return "Supplier details deleted";
        }

        public async Task<Supplier>? GetSupplierById(int id)
        {
            var supplier = await _dbContext.Suppliers!.FirstOrDefaultAsync(s => s.Id == id);
            return supplier!;
        }

        public async Task<Supplier[]>? GetSuppliers()
        {
            var SupplierList = await _dbContext.Suppliers!.ToArrayAsync();
            return SupplierList != null ? SupplierList : null!;
        }

        public async Task<string> UpdateSupplier(int Id, SupplierDto request)
        {
            var supplier = await GetSupplierById(Id)!;
            if (supplier != null)
            {
                supplier.Name = request.Name;
                supplier.Email = request.Email;
                supplier.PhoneNumber = request.PhoneNumber;
                supplier.Active = request.Active;
                supplier.InceptionDate = request.InceptionDate;

                await _dbContext.SaveChangesAsync();
                return "Update to supplier was successful";
            }
            return "An error occured while performing the supplier update";
        }
    }
}