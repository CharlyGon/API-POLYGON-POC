namespace Api_Polygon.Models
{
    /// <summary>
    /// This class represents the result of a transaction processed by the API.
    /// It contains properties that provide information about the transaction.
    /// </summary>
    public class TransactionResult
    {
        public string TransactionHash { get; set; }
        public decimal? TransactionCost { get; set; }
        public string? TransactionStatus { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
