using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.Models
{
    public class Customer
    {
        [Key]
        public int CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public List<Order> Orders { get; set; }
    }
}
