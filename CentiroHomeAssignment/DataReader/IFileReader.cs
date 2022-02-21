using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentiroHomeAssignment.DTOs;

namespace CentiroHomeAssignment.DataReader
{
    public interface IFileReader
    {
        string[] GetFiles(string orderFilePath);
        Task<List<OrderDTO>> GetOrdersDTOAsync(string orderFilePath);
        Task<List<OrderDTO>> ReadFileAsync(string fileName);
    }
}