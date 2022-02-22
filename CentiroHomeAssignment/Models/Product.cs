using System.ComponentModel.DataAnnotations;

namespace CentiroHomeAssignment.Models
{
    public class Product
    {
        [Key]
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductGroup { get; set; }
    }
}
