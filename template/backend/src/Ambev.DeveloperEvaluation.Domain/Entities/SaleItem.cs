using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents an individual item within a sale transaction,
/// including quantity, unit price, and applied discount rules.
/// </summary>
public class SaleItem : BaseEntity
{
    /// <summary>
    /// Gets the unique identifier of the parent sale.
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    /// Gets the unique identifier of the product sold.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets the name of the product sold.
    /// Stored for denormalization.
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Gets the quantity of the product sold.
    /// Must be between 1 and 20.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets the unit price of the product.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets the discount applied based on the quantity.
    /// </summary>
    public decimal Discount => CalculateDiscount();

    /// <summary>
    /// Gets the total amount for the item (quantity * unit price - discount).
    /// </summary>
    public decimal Total => (Quantity * UnitPrice) - Discount;

    /// <summary>
    /// Initializes a new instance of the SaleItem class.
    /// </summary>
    public SaleItem() { }

    /// <summary>
    /// Calculates the discount according to the defined business rules:
    /// - 10% for 4-9 items
    /// - 20% for 10-20 items
    /// - 0% otherwise
    /// </summary>
    /// <returns>The discount value</returns>
    private decimal CalculateDiscount()
    {
        if (Quantity >= 10 && Quantity <= 20)
            return Quantity * UnitPrice * 0.20m;

        if (Quantity >= 4)
            return Quantity * UnitPrice * 0.10m;

        return 0;
    }
}
