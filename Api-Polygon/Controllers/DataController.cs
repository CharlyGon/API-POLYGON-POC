using Microsoft.AspNetCore.Mvc;
using System;
using Api_Polygon.Business;
using Api_Polygon.Models;

namespace Api_Polygon.Controllers
{
    /// <summary>
    /// Controller class responsible for handling data-related requests.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IDataHandler _dataHandler;

        /// <summary>
        /// Constructor for initializing the DataController with an instance of the data handler.
        /// </summary>
        /// <param name="dataHandler">The data handler used for processing data.</param>
        public DataController(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }

        /// <summary>
        /// GET endpoint for retrieving information about a transaction using its hash.
        /// </summary>
        /// <param name="transactionHash">The hash of the transaction to retrieve information for.</param>
        /// <returns>An IActionResult containing information about the transaction.</returns>
        [HttpGet("{transactionHash}")]
        public IActionResult Get(string transactionHash)
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

        /// <summary>
        /// POST endpoint for saving data to the blockchain.
        /// </summary>
        /// <param name="inputData">The data to be saved to the blockchain.</param>
        /// <returns>An asynchronous task representing the HTTP response.</returns>
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
