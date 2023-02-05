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
            var SupplierExists = await _dbContext.Suppliers!.FirstOrDefaultAsync(s => s.Email == request.Email);
            if (SupplierExists != null)
                {return "Creation proocess stopped! Supplier already exists";}
            else
            {
                Supplier NewSupplier = new Supplier(){
                    Name = request.Name,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    Active = request.Active,
                    InceptionDate = request.InceptionDate,
                };

                await _dbContext.Suppliers!.AddAsync(NewSupplier);
                await _dbContext.SaveChangesAsync();

                return "Supplier created!";
            }
        }

        public Task<string> DeleteSupplier(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Supplier>? GetSupplierById(int Id)
        {
            var supplier = await _dbContext.Suppliers!.FirstOrDefaultAsync(s => s.Id == Id);
            return supplier != null ? supplier : null!;
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