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

        public Task<string> CreateSupplier(SupplierDto request)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteSupplier(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Supplier>? GetSupplierById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Supplier[]>? GetSuppliers()
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateSupplier(int Id, SupplierDto request)
        {
            throw new NotImplementedException();
        }
    }
}