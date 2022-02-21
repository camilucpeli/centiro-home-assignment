using CentiroHomeAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.Repositories
{
    public class CentiroHomeAssignmentContext : DbContext
    {
        public CentiroHomeAssignmentContext(DbContextOptions<CentiroHomeAssignmentContext> options): base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(order => order.OrderDetails);
            
            modelBuilder.Entity<Order>()
                .HasOne(order => order.Customer)
                .WithMany(customer => customer.Orders);


            modelBuilder.Entity<OrderDetail>()
                .HasOne(orderDetail => orderDetail.Product);

            modelBuilder.Entity<OrderDetail>()
                .Property(orderDetail => orderDetail.OrderDetailNumber)
                .ValueGeneratedOnAdd();



        }
    }
}
