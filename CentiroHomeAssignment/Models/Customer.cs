using System.ComponentModel.DataAnnotations;

namespace CentiroHomeAssignment.Models
{
    public class Customer
    {
        [Key]
        public int CustomerNumber { get; set; }
        public string CustomerName { get; set; }
    }
}
