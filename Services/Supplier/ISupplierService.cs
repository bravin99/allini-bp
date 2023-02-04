using Microsoft.EntityFrameworkCore;
using allinibp.Data.Models;

namespace allinibp.Services
{
    public interface ISupplierService
    {
        public Task<string> CreateSupplier(SupplierDto request);
        public Task<string> UpdateSupplier(int Id, SupplierDto request);
        public Task<Supplier>? GetSupplierById(int Id);
        public Task<Supplier[]>? GetSuppliers();
        public Task<string> DeleteSupplier(int Id);
    }
}