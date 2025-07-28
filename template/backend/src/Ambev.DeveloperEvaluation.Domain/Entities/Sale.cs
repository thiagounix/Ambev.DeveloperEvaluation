using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
    public string SaleNumber { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;
    public bool IsCancelled { get; set; }
    public List<SaleItem> Items { get; set; } = new();

    public decimal TotalAmount { get; set; }  
    public decimal TotalDiscount { get; set; } 

    public Sale()
    {
        SaleDate = DateTime.UtcNow;
        IsCancelled = false;
    }

    public void Cancel()
    {
        IsCancelled = true;
    }

    public void CalculateTotals()
    {
        foreach (var item in Items)
        {
            item.CalculateValues();
        }

        TotalAmount = Items.Sum(i => i.TotalAmount);
        TotalDiscount = Items.Sum(i => i.Discount);
    }

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