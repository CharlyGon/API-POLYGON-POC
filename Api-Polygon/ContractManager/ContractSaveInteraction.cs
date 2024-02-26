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

                // Get the account balance
                var balance = await web3.Eth.GetBalance.SendRequestAsync(account.Address);
                Console.WriteLine($"current Balance: {balance.Value}");

                // Get the gas price recommended by the network
                var gasPrice = await web3.Eth.GasPrice.SendRequestAsync();
                Console.WriteLine($"Current GasPrice: {gasPrice.Value}");

                // Estimate the gas required for the transaction
                var gasLimitEstimate = await setFunction.EstimateGasAsync(account.Address, null, null, data.Message);
                Console.WriteLine($"Estimation of GasLimit: {gasLimitEstimate.Value}");

                // Calculate the estimated total cost of the transaction (gasLimit * gasPrice)
                var totalCostEstimate = gasLimitEstimate.Value * gasPrice.Value;

                if (balance.Value < totalCostEstimate)
                {
                    return new TransactionResult
                    {
                        TransactionStatus = "Fail",
                        ErrorMessage = $"Insufficient funds to send transaction.  Balance: {balance.Value}, Estimated cost: {totalCostEstimate}"
                    };
                }

                // Send transaction and get hash
                var transactionHash = await setFunction.SendTransactionAsync(account.Address, new HexBigInteger(gasLimitEstimate.Value), gasPrice, null, data.Message);
                Console.WriteLine($"Send transaction. Hash: {transactionHash}");

                // Wait for transaction confirmation
                TransactionReceipt receipt = null;
                while (receipt == null)
                {
                    receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionHash);
                    await Task.Delay(1000); // Wait 1 second before retry receipt
                }

                var transactionStatus = receipt.Status.Value == 1 ? "Success" : "Fail";
                Console.WriteLine($"Transaction status: {transactionStatus}");

                // Get the transaction cost
                var transactionCost = UnitConversion.Convert.FromWei(totalCostEstimate);
                Console.WriteLine($"transaction cost: {transactionCost} MATIC");

                return new TransactionResult
                {
                    TransactionHash = transactionHash,
                    TransactionCost = transactionCost,
                    TransactionStatus = transactionStatus
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when interacting with the contract: {0}", ex.Message);

                return new TransactionResult
                {
                    TransactionStatus = "Fail",
                    ErrorMessage = $"Error when interacting with the contract: {ex.Message}"
                };
            }
        }
    }
}
