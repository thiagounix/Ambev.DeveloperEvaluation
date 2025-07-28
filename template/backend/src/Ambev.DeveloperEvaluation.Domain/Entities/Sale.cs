using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a sales transaction within the system,
/// containing customer, branch and item details,
/// along with business logic for total amount and cancellation.
/// </summary>
public class Sale : BaseEntity
{
    /// <summary>
    /// Gets the sale number that uniquely identifies the sale.
    /// </summary>
    public string SaleNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets the date and time when the sale was made.
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// Gets the name of the customer associated with this sale.
    /// </summary>
    public string CustomerName { get; set; } = string.Empty;

    /// <summary>
    /// Gets the name of the branch where the sale occurred.
    /// </summary>
    public string BranchName { get; set; } = string.Empty;

    /// <summary>
    /// Indicates whether the sale has been cancelled.
    /// </summary>
    public bool IsCancelled { get; set; }

    /// <summary>
    /// Gets the collection of items included in this sale.
    /// </summary>
    public List<SaleItem> Items { get; set; } = new();

    /// <summary>
    /// Calculates the total amount of the sale,
    /// including discounts applied to each item.
    /// </summary>
    public decimal TotalAmount => Items.Sum(i => i.Total);

    /// <summary>
    /// Initializes a new instance of the Sale class.
    /// Sets the sale date to UTC now.
    /// </summary>
    public Sale()
    {
        SaleDate = DateTime.UtcNow;
        IsCancelled = false;
    }

    /// <summary>
    /// Cancels the sale by setting the IsCancelled flag.
    /// </summary>
    public void Cancel()
    {
        IsCancelled = true;
    }

    /// <summary>
    /// Performs validation on the Sale entity.
    /// </summary>
    /// <returns>A detailed validation result for the sale.</returns>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}