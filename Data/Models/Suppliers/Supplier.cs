using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allinibp.Data.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
        public DateTime InceptionDate { get; set; }
    }
}