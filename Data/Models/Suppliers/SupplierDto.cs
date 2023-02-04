using System.ComponentModel.DataAnnotations;

namespace allinibp.Data.Models
{
    public class SupplierDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
        public DateTime InceptionDate { get; set; }
        
    }
}