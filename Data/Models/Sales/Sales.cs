using allinibp.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace allinibp.Data.Models
{
    public class Sales
    {
        [Required]
        public string SalesCode { get; set; } = string.Empty;
        public ICollection<Product>? ProductList { get; set; }
        public string customerName { get; set; } = string.Empty;
        [Required]
        public string PaymentMethod { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime? Updated { get; set; }
        [Required]
        public SalesStatus SalesStatus { get; set; }
    }

    public enum SalesStatus
    {
        completed,
        pending,
        failed,
    }

}