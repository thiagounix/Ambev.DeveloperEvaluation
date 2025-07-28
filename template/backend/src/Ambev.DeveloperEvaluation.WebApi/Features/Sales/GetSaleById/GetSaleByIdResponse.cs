namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSaleById;

/// <summary>
/// Response DTO for retrieving a sale by ID
/// </summary>
public class GetSaleByIdResponse
{
    public Guid Id { get; set; }
    public string SaleNumber { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; }
    public string Customer { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public string Branch { get; set; } = string.Empty;
    public bool IsCancelled { get; set; }

    public List<SaleItemResponse> Items { get; set; } = new();
}