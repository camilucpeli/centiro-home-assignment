using CentiroHomeAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace CentiroHomeAssignment.Repositories
{
    public class CentiroHomeAssignmentContext : DbContext
    {
        public CentiroHomeAssignmentContext(DbContextOptions<CentiroHomeAssignmentContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Order>()
                .HasMany(order => order.OrderDetails);

            modelBuilder.Entity<Order>()
                .HasOne(order => order.Customer);


            modelBuilder.Entity<OrderDetail>()
                .HasOne(orderDetail => orderDetail.Product);

            modelBuilder.Entity<OrderDetail>()
                .Property(orderDetail => orderDetail.OrderDetailNumber)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Order>()
                .Property(order => order.OrderNumber)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>()
                .Property(product => product.ProductNumber)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Customer>()
                .Property(customer => customer.CustomerNumber)
                .ValueGeneratedOnAdd();



        }
    }
}
