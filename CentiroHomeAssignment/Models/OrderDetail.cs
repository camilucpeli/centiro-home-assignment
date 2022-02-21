using System.ComponentModel.DataAnnotations;

namespace CentiroHomeAssignment.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailNumber { get; set; }
        [Required]
        public int OrderNumber { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
        public int OrderLineNumber { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
