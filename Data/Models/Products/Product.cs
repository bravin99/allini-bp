using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using allinibp.Data.Models.Suppliers;

namespace allinibp.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(45, ErrorMessage = "The name is too long")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Product>? Proucts { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        // unique identifier: randomly generated
        public string Sku { get; set; } = string.Empty;
        public string BarCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Quantity { get; set; }
        // minimum stock: reoder point
        public double MinimumStock { get; set; }
        // This is the extra inventory that is kept on hand to ensure that items are available
        public double SafetyStock { get; set; }
        // Cost of an Item including relevant taxes
        public double Cost { get; set; }
        public double SalesPrice { get; set; }
        public DateTime? EndOfShelfLife { get; set; }
        public string Image { get; set; } = string.Empty;
        public Location Location { get; set; } = Location.store;
        public DateTime Recieved { get; set; } = DateTime.UtcNow;
        public DateTime LastCount { get; set; } = DateTime.UtcNow;
        public Supplier? Supplier { get; set; }
    }

    public enum Location
    {
        warehouse,
        store,
    }
}