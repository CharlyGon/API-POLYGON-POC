using System;
using System.Threading.Tasks;
using Api_Polygon.Models;
using Api_Polygon.ContractManager;

namespace Api_Polygon.Business
{
    /// <summary>
    /// This interface defines the contract for the DataHandler class.
    /// </summary>
    public interface IDataHandler
    {
        Task<TransactionResult> ProcessData(DataModel inputData);
    }

    /// <summary>
    /// This class is responsible for processing the input data and interacting with the smart contract.
    /// It uses the ContractSaveInteraction class to send the data to the blockchain.
    /// </summary>
    public class DataHandler : IDataHandler
    {
        private readonly ContractSaveInteraction _contractInteraction;

        public DataHandler(ContractSaveInteraction contractInteraction)
        {
            _contractInteraction = contractInteraction;
        }

        /// <summary>
        /// Processes the input data and returns the transaction result.
        /// </summary>
        /// <param name="inputData">The data model to be processed.</param>
        /// <returns>The transaction result.</returns>
        public async Task<TransactionResult> ProcessData(DataModel inputData)
        {
            try
            {
                var transactionHash = await _contractInteraction.InteractWithContract(inputData);
                Console.WriteLine($"Data sent successfully to blockchain. Transaction Hash: {transactionHash}");

                return transactionHash;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing data: {ex.Message}");
                throw;
            }
        }
    }
}
