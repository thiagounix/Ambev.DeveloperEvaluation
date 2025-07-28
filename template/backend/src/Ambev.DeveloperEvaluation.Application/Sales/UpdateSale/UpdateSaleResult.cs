namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleResult
{
    public Guid Id { get; set; }
    public decimal? TotalAmount { get; set; }
    public decimal? Discount { get; set; }
    public bool IsCancelled { get; set; }
}
