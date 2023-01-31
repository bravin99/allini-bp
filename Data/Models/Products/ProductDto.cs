using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace allinibp.Data.Models
{
    public class CategoryDto
    {
        [Required]
        [StringLength(45, ErrorMessage = "The name is too long")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Display { get; set; } = true;
    }

    public class ProductDto
    {
        // unique identifier: randomly generated
        // public string Sku { get; set; } = string.Empty;
        [Required]
        public string BarCode { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        public Category? Category { get; set; }
        [Required]
        public double Quantity { get; set; }
        // minimum stock: reoder point
        [Required]
        public double MinimumStock { get; set; }
        // This is the extra inventory that is kept on hand to ensure that items are available
        [Required]
        public double SafetyStock { get; set; }
        [Required]
        // Cost of an Item including relevant taxes
        public double Cost { get; set; }
        [Required]
        public double SalesPrice { get; set; }
        [Required]
        public DateTime? EndOfShelfLife { get; set; }
        public string Image { get; set; } = string.Empty;
        public Location Location { get; set; }
        public DateTime LastCount { get; set; } = DateTime.UtcNow;
    }
}