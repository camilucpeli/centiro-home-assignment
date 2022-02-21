using CentiroHomeAssignment.DTOs;
using CentiroHomeAssignment.Models;
using CentiroHomeAssignment.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.Services
{
    public class OrderDTOFromFileToDB
    {
        private readonly IRepository<Customer> _cusRepo;
        private readonly IRepository<Product> _prodRepo;
        private readonly IRepository<OrderDetail> _ordDetRepo;
        private readonly IRepository<Order> _orderRepo;

        public OrderDTOFromFileToDB(IRepository<Customer> cusRepo, IRepository<Product> prodRepo, IRepository<OrderDetail> ordDetRepo, IRepository<Order> orderRepo)
        {
            _cusRepo = cusRepo;
            _prodRepo = prodRepo;
            _ordDetRepo = ordDetRepo;
            _orderRepo = orderRepo;
        }

        public async Task InsertOrdersDTOs(List<OrderDTO> ordersDTOs)
        {
            var orderDTOsGroups = ordersDTOs.GroupBy(order => order.OrderNumber).ToList();
            foreach (var orderDTOGroup in orderDTOsGroups)
            {
                var orderDTOList = orderDTOGroup.Select(o => o).ToList();
                await InsertOrderDTO(orderDTOList);
            }
        }

        private async Task InsertOrderDTO(List<OrderDTO> orderDTOs)
        {
            var firstOrder = orderDTOs.FirstOrDefault();
            var orderNumber = firstOrder.OrderNumber;
            var orderDate = firstOrder.OrderDate;
            var customerName = firstOrder.CustomerName.ToString();
            var customerNumber = firstOrder.CustomerNumber;

            var orderDetails = new List<OrderDetail>();
            var products = new List<Product>();


            foreach (var orderDTO in orderDTOs)
            {
                var product = new Product()
                {
                    ProductName = orderDTO.ProductName,
                    ProductNumber = orderDTO.ProductNumber,
                    Description = orderDTO.Description,
                    Price = orderDTO.Price
                };

                if(!products.Contains(product)) products.Add(product);

                orderDetails.Add(new OrderDetail
                {
                    OrderNumber = orderDTO.OrderNumber,
                    Product = product,
                    OrderLineNumber = orderDTO.OrderLineNumber,
                    Quantity = orderDTO.Quantity
                });
            }

            var customer = new Customer()
            {
                CustomerName = customerName,
                CustomerNumber = customerNumber
            };

            var order = new Order()
            {
                OrderNumber = orderNumber,
                OrderDetails = orderDetails,
                OrderDate = orderDate,
                Customer = customer
            };

            await InsertCustomer(customer);
            await InsertProducts(products);
            await InsertOrderDetails(orderDetails);
            await InsertOrder(order);
        }

        private async Task InsertOrder(Order order)
        {
            await _orderRepo.InsertAsync(order);
        }

        private async Task InsertOrderDetails(List<OrderDetail> orderDetails)
        {
            foreach (var orderDetail in orderDetails)
            {
                await _ordDetRepo.InsertAsync(orderDetail);
            }
        }

        public async Task InsertCustomer(Customer customer)
        {
            await _cusRepo.InsertAsync(customer);
        }

        public async Task InsertProducts(List<Product> products)
        {
            foreach (var product in products)
            {
                await _prodRepo.InsertAsync(product);
            }
        }
    }
}
