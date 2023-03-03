using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using allinibp.Data.Models;

namespace allinibp.Data.Models
{
    public class SalesDto
    {
        public ICollection<Product>? ProductList { get; set; }
        public string customerName { get; set; }
        [Required(ErrorMessage="The field is required")]
        public string PaymentMethod { get; set; }
        [Required(ErrorMessage="This field is required")]
        public SalesStatus SalesStatus { get; set; }        
    }
}