namespace Api_Polygon.Models
{
    public class TransactionResult
    {
        public string TransactionHash { get; set; }
        public decimal? TransactionCost { get; set; }
        public string? TransactionStatus { get; set; }
    }
}
