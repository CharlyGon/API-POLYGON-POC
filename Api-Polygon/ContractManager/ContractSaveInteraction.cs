using System;
using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Util;
using Api_Polygon.Models;

namespace Api_Polygon.ContractManager
{
    /// <summary>
    /// This class manages the interaction with the smart contract deployed on the Polygon network.
    /// It provides methods to interact with the contract, such as sending transactions and retrieving transaction receipts.
    /// </summary>
    public class ContractSaveInteraction
    {
        private readonly string _polygonUrl = Environment.GetEnvironmentVariable("PolygonURL");
        private readonly string _privateKey = Environment.GetEnvironmentVariable("PrivateKey");
        private readonly string _contractAddress = Environment.GetEnvironmentVariable("ContractAddress");
        private readonly string _abi = Environment.GetEnvironmentVariable("ContractABI");

        /// <summary>
        /// Interacts with the smart contract to send a transaction with the provided data.
        /// </summary>
        /// <param name="data">The data to be sent to the smart contract.</param>
        /// <returns>A Task representing the asynchronous operation, containing the transaction result.</returns>
        public async Task<TransactionResult> InteractWithContract(DataModel data)
        {
            try
            {
                var account = new Account(_privateKey);
                var web3 = new Web3(account, _polygonUrl);

                var contract = web3.Eth.GetContract(_abi, _contractAddress);
                var setFunction = contract.GetFunction("set");

                // Obtener el balance de la cuenta
                var balance = await web3.Eth.GetBalance.SendRequestAsync(account.Address);
                Console.WriteLine($"Balance actual: {balance.Value}");

                // Obtener el precio del gas recomendado por la red
                var gasPrice = await web3.Eth.GasPrice.SendRequestAsync();
                Console.WriteLine($"GasPrice actual: {gasPrice.Value}");

                // Estimar el gas necesario para la transacción
                var gasLimitEstimate = await setFunction.EstimateGasAsync(account.Address, null, null, data.Message);
                Console.WriteLine($"Estimación de GasLimit: {gasLimitEstimate.Value}");

                // Calcular el costo total estimado de la transacción (gasLimit * gasPrice)
                var totalCostEstimate = gasLimitEstimate.Value * gasPrice.Value;

                // Verificar si el balance es suficiente para cubrir el costo de la transacción
                if (balance.Value < totalCostEstimate)
                {
                    return new TransactionResult
                    {
                        TransactionStatus = "Fail",
                        ErrorMessage = $"Fondos insuficientes para enviar la transacción. Balance: {balance.Value}, Costo estimado: {totalCostEstimate}"
                    };
                }

                // Enviar la transacción y obtener el hash
                var transactionHash = await setFunction.SendTransactionAsync(account.Address, new HexBigInteger(gasLimitEstimate.Value), gasPrice, null, data.Message);
                Console.WriteLine($"Transacción enviada. Hash: {transactionHash}");

                // Esperar la confirmación de la transacción
                TransactionReceipt receipt = null;
                while (receipt == null)
                {
                    receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionHash);
                    await Task.Delay(1000); // Esperar 1 segundo antes de volver a intentar obtener el recibo
                }

                // Verificar el estado de la transacción
                var transactionStatus = receipt.Status.Value == 1 ? "Success" : "Fail";
                Console.WriteLine($"Estado de la transacción: {transactionStatus}");

                // Obtener el costo de la transacción
                var transactionCost = UnitConversion.Convert.FromWei(totalCostEstimate);
                Console.WriteLine($"Costo de la transacción: {transactionCost} MATIC");

                return new TransactionResult
                {
                    TransactionHash = transactionHash,
                    TransactionCost = transactionCost,
                    TransactionStatus = transactionStatus
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al interactuar con el contrato: {0}", ex.Message);

                return new TransactionResult
                {
                    TransactionStatus = "Fail",
                    ErrorMessage = $"Error al interactuar con el contrato: {ex.Message}"
                };
            }
        }
    }
}
