using CentiroHomeAssignment.DataReader;
using CentiroHomeAssignment.DTOs;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CentiroHomeAssignment.Tests
{
    [TestFixture]
    class CSVFileReaderTests
    {
        [Test]
        [TestCase("OrderNumber", "17890", @"{'OrderNumber': 17890}")]
        [TestCase("OrderLineNumber", "3", @"{'OrderLineNumber': 3}")]
        [TestCase("OrderDate", "25-01-2014", @"{'OrderDate': '25-Jan-14 12:00:00 AM'}")]
        [TestCase("Quantity", "5", @"{'Quantity': 5}")]
        [TestCase("Name", "Small House", @"{'ProductName': 'Small House'}")]
        [TestCase("Description", "something", @"{'Description': 'something'}")]
        [TestCase("Description", "", @"{'Description': ''}")]
        [TestCase("Price", "0.34", @"{'Price': 0.34}")]
        [TestCase("ProductGroup", "Normal", @"{'ProductGroup': 'Normal'}")]
        public void SetValueTest(string columnName, string value, string orderDTOTxt)
        {
            var csv = new CSVFileReader();

            var orderDTO = new OrderDTO();

            csv.SetValue(columnName, value, orderDTO);

            Assert.AreEqual(JsonConvert.SerializeObject( orderDTO), 
                JsonConvert.SerializeObject(JsonConvert.DeserializeObject<OrderDTO>(orderDTOTxt)));
        }
    }
}
