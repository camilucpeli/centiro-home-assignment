using CentiroHomeAssignment.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.DataReader
{
    public class CSVFileReader : IFileReader
    {

        public string[] GetFiles(string orderFilePath)
        {
            return Directory.GetFiles(orderFilePath);
        }

        public async Task<List<OrderDTO>> GetOrdersDTOAsync(string orderFilePath)
        {
            var orderDTOList = new List<OrderDTO>();

            foreach (var file in GetFiles(orderFilePath))
            {
                orderDTOList.AddRange(await ReadFileAsync(file));
            }

            return orderDTOList;
        }

        public async Task<List<OrderDTO>> ReadFileAsync(string fileName)
        {
            var orderDTOList = new List<OrderDTO>();

            var orderData = await File.ReadAllLinesAsync(fileName);

            var columnNames = orderData[0].Split("|");

            var orderColumnDictionary = GetColumnOrderDictionary(columnNames);

            foreach (var row in orderData.Skip(1))
            {
                orderDTOList.Add(ParseOrderDTO(row, orderColumnDictionary));
            }

            return orderDTOList;
        }

        public Dictionary<int, string> GetColumnOrderDictionary(string[] columnNames)
        {
            var orderColumnDictionary = new Dictionary<int, string>();

            for (int i = 0; i < columnNames.Length; i++)
            {
                orderColumnDictionary.Add(i, columnNames[i]);
            }

            return orderColumnDictionary;
        }

        public OrderDTO ParseOrderDTO(string row, Dictionary<int, string> orderColumnDictionary)
        {
            var orderDTO = new OrderDTO();
            var values = row.Split("|");
            for (int i = 0; i < values.Length; i++)
            {
                SetValue(orderColumnDictionary[i], values[i], orderDTO);
            }
            return orderDTO;
        }

        public void SetValue(string columnName, string value, OrderDTO orderDTO)
        {
            if (Enum.TryParse<OrderDTOColumns>(columnName, out var column))
            {
                switch (column)
                {
                    case OrderDTOColumns.OrderNumber:
                        orderDTO.OrderNumber = int.Parse(value);
                        break;
                    case OrderDTOColumns.OrderLineNumber:
                        orderDTO.OrderLineNumber = int.Parse(value);
                        break;
                    case OrderDTOColumns.ProductNumber:
                        orderDTO.ProductNumber = value;
                        break;
                    case OrderDTOColumns.Quantity:
                        orderDTO.Quantity = int.Parse(value);
                        break;
                    case OrderDTOColumns.Name:
                        orderDTO.ProductName = value;
                        break;
                    case OrderDTOColumns.Description:
                        orderDTO.Description = value;
                        break;
                    case OrderDTOColumns.Price:
                        orderDTO.Price = double.Parse(value);
                        break;
                    case OrderDTOColumns.ProductGroup:
                        orderDTO.ProductGroup = value;
                        break;
                    case OrderDTOColumns.OrderDate:
                        orderDTO.OrderDate = DateTime.Parse(value);
                        break;
                    case OrderDTOColumns.CustomerName:
                        orderDTO.CustomerName = value;
                        break;
                    case OrderDTOColumns.CustomerNumber:
                        orderDTO.CustomerNumber = int.Parse(value);
                        break;
                }
            }
        }

    }
}
