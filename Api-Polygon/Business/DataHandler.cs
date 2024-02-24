using System;
using System.Threading.Tasks;
using Api_Polygon.Models;
using Api_Polygon.ContractManager;

namespace Api_Polygon.Business
{
    public interface IDataHandler
    {
        Task<TransactionResult> ProcessData(DataModel inputData);
    }

    public class DataHandler : IDataHandler
    {
        private readonly ContractSaveInteraction _contractInteraction; // Cambia a ContractSaveInteraction

        public DataHandler(ContractSaveInteraction contractInteraction)
        {
            _contractInteraction = contractInteraction; // Cambia a ContractSaveInteraction
        }

        public async Task<TransactionResult> ProcessData(DataModel inputData)
        {
            try
            {
                // Llama al método en ContractSaveInteraction para guardar los datos en la blockchain
                var transactionHash = await _contractInteraction.InteractWithContract(inputData); // Cambia el método según tu implementación
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
