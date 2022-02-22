using System;

namespace CentiroHomeAssignment.DTOs
{
    public class OrderDTO
    {
        public int OrderNumber { get; set; }
        public int OrderLineNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public int CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductGroup { get; set; }
    }
}
