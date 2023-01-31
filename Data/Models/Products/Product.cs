using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using allinibp.Data.Models;

namespace allinibp.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(45, ErrorMessage = "The name is too long")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Product>? Products { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime Updated { get; set; } = DateTime.UtcNow;
        public bool Display { get; set; } = true;
    }

    public class Product
    {
        public int Id { get; set; }
        // unique identifier: randomly generated
        public string Sku { get; set; } = string.Empty;
        public string BarCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public Category? Category { get; set; }
        // minimum stock: reoder point
        public double MinimumStock { get; set; }
        // This is the extra inventory that is kept on hand to ensure that items are available
        public double SafetyStock { get; set; }
        // Cost of an Item including relevant taxes
        public double Cost { get; set; }
        public double SalesPrice { get; set; }
        public DateOnly? EndOfShelfLife { get; set; }
        public string Image { get; set; } = string.Empty;
        public Location Location { get; set; } = Location.store;
        public DateTime Recieved { get; set; } = DateTime.UtcNow;
        public DateOnly LastCount { get; set; }
        public Supplier? Supplier { get; set; }
        public Double? AdjustedCount { get; set; }
    }

    public enum Location
    {
        warehouse,
        store,
    }
}