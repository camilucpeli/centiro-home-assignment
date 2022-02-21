using System.ComponentModel.DataAnnotations;

namespace CentiroHomeAssignment.Models
{
    public class Product
    {
        [Key]
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public ProductGroup ProductGroup { get; set; }
    }
}
