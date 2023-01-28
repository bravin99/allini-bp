using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace allinibp.Data.Models
{
    public class ProductDto
    {
        [Required]
        [StringLength(45, ErrorMessage = "The name is too long")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}