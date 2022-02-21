using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CentiroHomeAssignment.Models
{
    public class Order
    {
        [Key]
        public int OrderNumber { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        
    }
}
