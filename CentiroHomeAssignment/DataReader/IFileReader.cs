using CentiroHomeAssignment.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.DataReader
{
    public interface IFileReader
    {
        string[] GetFiles(string orderFilePath);
        Task<List<OrderDTO>> GetOrdersDTOAsync(string orderFilePath);
        Task<List<OrderDTO>> ReadFileAsync(string fileName);
    }
}