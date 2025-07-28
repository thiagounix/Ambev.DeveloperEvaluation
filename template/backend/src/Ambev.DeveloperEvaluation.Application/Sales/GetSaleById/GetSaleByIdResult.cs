namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleById
{
    /// <summary>
    /// Result DTO for the GetSaleById query.
    /// </summary>
    public class GetSaleByIdResult
    {
        public Guid Id { get; set; }
        public string SaleNumber { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Customer { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }

        public List<GetSaleItemResult> Items { get; set; } = new();
    }
}
