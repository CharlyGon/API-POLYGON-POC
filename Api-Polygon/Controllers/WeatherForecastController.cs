using Microsoft.AspNetCore.Mvc;
using System;
using Api_Polygon.Business;

namespace Api_Polygon.Controllers
{
 [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IDataHandler _dataHandler;


        public DataController(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }


        [HttpGet("{transactionHash}")] // Adjust the route of the HttpGet attribute
        public IActionResult Get(string transactionHash) // Add the transactionHash parameter
        {
            try
            {
                // Build the complete link to the transaction on PolygonScan
                string polygonScanLink = $"https://mumbai.polygonscan.com/search?f=0&q={transactionHash}";

                // Return the complete link as part of the response
                Console.WriteLine($"Transaction found on PolygonScan: {polygonScanLink}");
                return Ok($"Transaction found on PolygonScan: {polygonScanLink}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("save")]
        public async Task<IActionResult> SaveToBlockchain([FromBody] DataModel inputData)
        {
            try
            {
                // Validate that the Message field is not empty
                if (string.IsNullOrEmpty(inputData.Message))
                {
                    return BadRequest("The Message field is mandatory");
                }

                // Process the data and get the transaction result
                TransactionResult result = await _dataHandler.ProcessData(inputData);

                if (result == null || string.IsNullOrEmpty(result.TransactionHash))
                {
                    return StatusCode(422, "Data processing failed");
                }

                // Return transaction information
                var response = new
                {
                    message = "Transaction sent successfully.",
                    transaction = result
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
