using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleItem : BaseEntity
{
    public Guid SaleId { get; set; }
    public Sale? Sale { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    public decimal Discount { get; set; }  
    public decimal TotalAmount { get; set; } 

    public void CalculateValues()
    {
        Discount = CalculateDiscount();
        TotalAmount = (Quantity * UnitPrice) - Discount;
    }

    private decimal CalculateDiscount()
    {
        if (Quantity > 20)
            throw new InvalidOperationException("Cannot sell more than 20 items.");

        if (Quantity >= 10 && Quantity <= 20)
            return Quantity * UnitPrice * 0.20m;

        if (Quantity >= 4)
            return Quantity * UnitPrice * 0.10m;

        return 0;
    }
}
