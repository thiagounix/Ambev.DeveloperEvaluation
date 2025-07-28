namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// DTO representing an item within a sale.
/// </summary>
public class SaleItem
{
    public string ProductName { get; init; } = string.Empty;
    public int Quantity { get; init; }
    public decimal UnitPrice { get; init; }
}